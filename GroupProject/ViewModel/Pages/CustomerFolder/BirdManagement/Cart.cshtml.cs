using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModelsV6.DAOs;
using ModelsV6.DTOs;
using ModelsV6.DTOs.State;
using Repositories.IRepository;
using ViewModel.Pages.Other;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class CartModel : PageModel
    {
        private static IOrderRepository _orderRepo;
        private static IBirdRepository _birdRepo;
        private static IOrderDetailRepository _orderDetailRepo;
        private static IPaymentRepository _paymentRepo;

        [BindProperty]
        public IFormFile[] file { get; set; }
        [BindProperty]
        public Order order { get;set; }
        public List<Item> cart { get; set; }
        [BindProperty]
        public Payment payment { get; set; }

        public decimal Total { get; set; }
        public CartModel(IOrderRepository orderRepository,IBirdRepository birdRepo,IOrderDetailRepository orderDetailRepo,IPaymentRepository paymentRepo)
        {
            _orderRepo = orderRepository;
            _birdRepo = birdRepo;
            _orderDetailRepo = orderDetailRepo;
            _paymentRepo = paymentRepo;
        }
        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Total = cart.Sum(i => i.Quantity);
        }
        public IActionResult OnGetBuyNow(string id)
        {

            var productModel = _birdRepo.FindById(int.Parse(id));
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item
                {
                    bird = productModel,
                    Quantity = 1
                });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                    cart.Add(new Item { bird = _birdRepo.FindById(int.Parse(id)), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("./Cart");

        }


        public IActionResult OnGetDelete(string id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("./Cart");

        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("./Cart");
        }

        public IActionResult OnPostSave(string[] selectCage, string[] chooseOrderItems,  int[] quantities, IFormFile[] file)
        {

            return RedirectToPage("./Cart");
        }

        private int Exists(List<Item> cart, string id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].bird.BirdId.ToString() == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult OnGetDelivery(int total)
        {

            return RedirectToPage("/CustomerFolder/BirdManagement/OrderProcess");
        }
       
        public async Task<IActionResult> OnPostAddOrder()
        {
            ModelState.ClearValidationState(nameof(Order));
            if (!TryValidateModel(order, nameof(Order)))
            {
                return Page();
            }
            Payment newPayment = new Payment
            {
                PaymentType = payment.PaymentType,
                PaymentId = _paymentRepo.getLastIDinPayment() + 1,
            };
            Order newOrder = new Order
            {
                OrderId = _orderDetailRepo.GetLastOrder() + 1,
                CustomerId = int.Parse(HttpContext.Session.GetString("UserID") ?? "0"),
                Note = order.Note,
                PaymentId = newPayment.PaymentId,
                ReceivingAddress = order.ReceivingAddress,
                SendingAddress = order.SendingAddress,
                Status = TrackingState.UnProcessing.ToString(),
                OrderType = order.OrderType,
            };
            _orderRepo.AddAsync(newOrder);

            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for(int i = 0; i < cart.Count(); i++)
            {
               
                OrderDetail newOrderDetails = new OrderDetail
                {
                    BirdCage = "Big Bird Cage",
                    BirdId = cart[i].bird.BirdId,
                    Certificate = "Not have",
                    OrderId = newOrder.OrderId,
                    DeliveryStatus = TrackingState.UnProcessing.ToString(),
                    Price = 10000,
                    OrderDetailId = _orderDetailRepo.GetLastOrderDetailId() +1,
                    OtherItems = "None"

                };
           await     _orderDetailRepo.AddNewOrderDetail(newOrderDetails);
                
            }

            return RedirectToPage("/CustomerFolder/OrderHistories");
        }



    }
}

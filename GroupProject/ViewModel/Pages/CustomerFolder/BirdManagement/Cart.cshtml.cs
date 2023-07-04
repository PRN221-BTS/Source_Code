using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV4.DAOs;
using ModelsV4.DTOs;
using Repositories.IRepository;
using ViewModel.Pages.Other;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class CartModel : PageModel
    {
        private static IOrderRepository _orderRepo;
        private static IBirdRepository _birdRepo;
        private static IOrderDetailRepository _orderDetailRepo;
        [BindProperty]
        public Order order { get;set; }
        public List<Item> cart { get; set; }

        public decimal Total { get; set; }
        public CartModel(IOrderRepository orderRepository,IBirdRepository birdRepo,IOrderDetailRepository orderDetailRepo)
        {
            _orderRepo = orderRepository;
            _birdRepo = birdRepo;
            _orderDetailRepo = orderDetailRepo;
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
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item { bird = _birdRepo.FindById(int.Parse(id)), Quantity = 1 });

                }
                else
                {
                    cart[index].Quantity++;
                }
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
       
        public IActionResult OnPostAddOrder()
        {
            ModelState.ClearValidationState(nameof(Order));
            if (!TryValidateModel(order, nameof(Order)))
            {
                return Page();
            }
            Order newOrder = new Order
            {
                OrderId = _orderDetailRepo.GetLastOrder() + 1,
                CustomerId = int.Parse(HttpContext.Session.GetString("UserID")),
                Note = order.Note,
                PaymentId = 1,
                ReceivingAddress = order.ReceivingAddress,
                SendingAddress = order.SendingAddress,
                Status = TrackingState.UnProcessing.ToString(),
                


            };
            _orderRepo.AddAsync(newOrder);

            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for(int i = 0; i < cart.Count(); i++)
            {
                Order newOrder1 = newOrder;
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
            }

            return RedirectToPage();
        }



    }
}

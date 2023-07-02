using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV2.DTOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class CartModel : PageModel
    {
        private static IOrderRepository _orderRepo;
        private static IBirdRepository _birdRepo;

        public List<Item> cart { get; set; }

        public decimal Total { get; set; }
        public CartModel(IOrderRepository orderRepository,IBirdRepository birdRepo)
        {
            _orderRepo = orderRepository;
            _birdRepo = birdRepo;
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



    }
}

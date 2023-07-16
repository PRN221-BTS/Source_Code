using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV6.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder.OrderHandle
{
    public class CancelOrderModel : PageModel
    {
        private static IOrderDetailRepository _orderDetailRepo;
        public CancelOrderModel(IOrderDetailRepository orderDetailRepo)
        {
            _orderDetailRepo = orderDetailRepo;
        }

        [BindProperty]
        public Order order { get; set; }
        public void OnGet(int id)
        {
            order = _orderDetailRepo.GetOrderById(id);
        }

        public IActionResult OnPost(int id)
        {
            _orderDetailRepo.CancelOrderbyOrderID(id);
            return RedirectToPage("/CustomerFolder/OrderHistories");
        }
    }
}

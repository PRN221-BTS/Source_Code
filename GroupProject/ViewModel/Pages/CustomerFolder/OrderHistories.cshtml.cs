using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV4.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder
{
    public class OrderHistoriesModel : PageModel
    {
        private static IOrderDetailRepository _orderDetailRepository;
        public OrderHistoriesModel(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        [BindProperty]
        public List<Order> orders { get; set; }
        public void OnGet()
        {
            orders = _orderDetailRepository.GetAllOrderByCusotmetID(int.Parse(HttpContext.Session.GetString("UserID"))); 
        }
        
    }
}

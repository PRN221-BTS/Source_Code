using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV6.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder.OrderHandle
{
    public class OrderDetailHistoriesModel : PageModel
    {
        
        private static IOrderDetailRepository _orderDetailRepo;
        public OrderDetailHistoriesModel(IOrderDetailRepository orderDetailRepo)
        {
            _orderDetailRepo = orderDetailRepo;
        }

        [BindProperty]
        public List<OrderDetail> orderDetail { get; set; }
        public void OnGet(int id)
        {
            orderDetail = _orderDetailRepo.GetOrderDetailByOrderId(id);
        }
    }
}

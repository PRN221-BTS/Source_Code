using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.LogisticsHandle
{
    public class OrderBatchManagementModel : PageModel
    {
        private static IOrderRepository _context;

        public List<Order> order { get;set; }
        public OrderBatchManagementModel(IOrderRepository context)
        {
            _context = context;
        }
        public void OnGet()
        {
            order = _context.UnProcessingOrder();
        }
    }
}

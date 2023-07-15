using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV6.DTOs;
using Repositories.HandleViewFormat;
using Repositories.IRepository;

namespace ViewModel.Pages.Shippers
{
    public class RouteManagerModel : PageModel
    {
        private static IRouteRepository _context;

        RouteViewFormat _viewFormat;

        [BindProperty]
        public List<ReceivingOrder> receivingOrder { get; set; }

        [BindProperty]
        public List<SendingOrder> sendingOrder { get; set; }

        public Route route { get; set; }

        public RouteManagerModel(IRouteRepository context, RouteViewFormat routeViewFormat  )
        {
            _context = context;
            _viewFormat = routeViewFormat;
        }
        public void OnGet(int id)
        {

            receivingOrder = _viewFormat.receivingOrders(int.Parse(HttpContext.Session.GetString("UserID")));
            sendingOrder = _viewFormat.sendingOrders(int.Parse(HttpContext.Session.GetString("UserID")));
        }

        public IActionResult OnGetUpdate(int id)
        {
           
            _context.UpdateRouteStatusToDoneById(id);
            receivingOrder = _viewFormat.receivingOrders(int.Parse(HttpContext.Session.GetString("UserID")));
            sendingOrder = _viewFormat.sendingOrders(int.Parse(HttpContext.Session.GetString("UserID")));
            return Page();
        }



    }
}

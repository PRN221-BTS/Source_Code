using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV4.DTOs;
using Repositories.HandleViewFormat;
using Repositories.IRepository;

namespace ViewModel.Pages.Shippers
{
    public class RouteManagerModel : PageModel
    {
        private static IRouteRepository _context;

        RouteViewFormat _viewFormat;
        public List<ReceivingOrder> receivingOrder { get; set; }

        public List<SendingOrder> sendingOrder { get; set; }

        public Route route { get; set; }

        public RouteManagerModel(IRouteRepository context, RouteViewFormat routeViewFormat  )
        {
            _context = context;
            _viewFormat = routeViewFormat;
        }
        public void OnGet(int id)
        {
            receivingOrder = _viewFormat.receivingOrders(id);
            sendingOrder = _viewFormat.sendingOrders(id);
        }
    }
}

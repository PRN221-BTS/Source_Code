using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV4.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Shippers
{
    public class ProfileModel : PageModel
    {
        private static IShipperRepository _context;
        
        public Shipper shipper { get; set; }
        public Warehouse warehouse { get; set; }  
        public ProfileModel(IShipperRepository context)
        {
            _context = context;
        }
        public void OnGet()
        {
            int value = Int32.Parse(HttpContext.Session.GetString("UserID").ToString());
        shipper =  _context.GetShipperById(value);
            warehouse =_context.GetWarehouseById((int)shipper.WarehouseId);


            
            
        }
    }
}

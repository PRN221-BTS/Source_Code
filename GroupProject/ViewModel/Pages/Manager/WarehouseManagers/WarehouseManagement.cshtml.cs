using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV4.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Manager.WarehouseManagers
{
    public class WarehouseManagementModel : PageModel
    {
     
        private static IWarehouseManagerRepository _context;
        public WarehouseManager warehouseManager { get; set; }
        public WarehouseManagementModel(IWarehouseManagerRepository context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
           warehouseManager = _context.getWarehouseManagementByWarehouseID(id);
        }
    }
}

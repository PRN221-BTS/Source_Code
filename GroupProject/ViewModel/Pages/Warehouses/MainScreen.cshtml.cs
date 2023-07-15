using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV6.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Warehouses
{
    public class MainScreenModel : PageModel
    {

        private IWarehouseManagerRepository _wareManagerhouseRepo;
        private IWarehouseRepository _warehouseRepository;
        public MainScreenModel(IWarehouseManagerRepository warehouseMangerRepo,IWarehouseRepository warehouseRepo)
        {
            _wareManagerhouseRepo = warehouseMangerRepo;
            _warehouseRepository = warehouseRepo;
        }
        [BindProperty]
        public Warehouse warehouse { get; set; }

        [BindProperty]
        public WarehouseManager warehouseManager { get; set; }
        public void OnGet()
        {
            warehouse = _warehouseRepository.getWarehouseInfoByWarehouseManagerID(int.Parse(HttpContext.Session.GetString("UserID")));
            warehouseManager = _wareManagerhouseRepo.GetByIdAsync(int.Parse(HttpContext.Session.GetString("UserID")));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV5.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Warehouses
{
    public class MainScreenModel : PageModel
    {

        private static IWarehouseManagerRepository _wareManagerhouseRepo;
        private static IWarehouseRepository _warehouseRepository;
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
            _warehouseRepository.getWarehouseInfoByWarehouseManagerID(int.Parse(HttpContext.Session.GetString("UserID")));
            _wareManagerhouseRepo.GetByIdAsync(int.Parse(HttpContext.Session.GetString("UserID")));
        }
    }
}

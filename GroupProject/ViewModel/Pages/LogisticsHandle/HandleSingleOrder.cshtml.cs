using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DAOs;
using Model.DTOs;
using Repositories.HandleViewFormat;
using Repositories.IRepository;

namespace ViewModel.Pages.LogisticsHandle
{
    public class HandleSingleOrderModel : PageModel
    {
       
    
        private static IWarehouseRepository _warehouseRepo;
        private static IOrderRepository _orderRepository;   
        private static IShipperRepository _shipperRepo;
        private static ShipperViewFormat _viewFormat;

        [BindProperty]
        public List<Warehouse> warehouse { get; set; }
        public List<Shipper> shippers { get; set; }

        [BindProperty]
        public Order order { get; set; }
        
        public InformationShipper informationShipper { get; set; }
     
        public HandleSingleOrderModel(IWarehouseRepository warehouseRepo,IOrderRepository orderRepository,IShipperRepository shipperRepo,ShipperViewFormat viewFormat)
        {
            
            _viewFormat = viewFormat;
            _warehouseRepo = warehouseRepo;
            _orderRepository = orderRepository;
            _shipperRepo = shipperRepo;
        }
        public void OnGet(int id)
        {
            order = _orderRepository.GetByIdAsync(id);
            warehouse = _warehouseRepo.GetAllAsync();
        }
       
        public IActionResult OnPostInfoShipper(string warehouseKeyWord) 
        {
           shippers = _shipperRepo.GetShippersByWarehouseID(int.Parse(warehouseKeyWord));
            return Page();
        }

        //public IActionResult OnGetSearch()
        //{
        //    shippers = _shipperRepo.GetShippersByWarehouseID(int.Parse(warehouseKeyWord));
        //    return Page();
        //}


        //public IActionResult OnPostAddShipper() { }
    }
}

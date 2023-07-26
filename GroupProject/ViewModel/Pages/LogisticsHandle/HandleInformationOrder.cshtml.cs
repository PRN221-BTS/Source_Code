using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV6.DAOs;
using ModelsV6.DTOs.State;
using Repositories.IRepository;

namespace ViewModel.Pages.LogisticsHandle
{
    public class HandleInformationOrderModel : PageModel
    {

        private static IOrderRepository _orderRepo;
        private static IOrderDetailRepository _orderDetailRepo;
        public HandleInformationOrderModel(IOrderRepository orderRepo, IOrderDetailRepository orderDetailRepo)
        {
            _orderRepo = orderRepo;
            _orderDetailRepo = orderDetailRepo;
        }
        [BindProperty]
        public List<OrderDetail> Details { get; set; }
        public void OnGet(int id)
        {
            Details = _orderDetailRepo.GetOrderDetailByOrderId(id);
            TempData["orderID"] = id;
        }

        public  async Task<IActionResult> OnPostUpdateInformation(string[] optionsoutlined, int[] Idcheck)
        {
            bool check = true;
          
            for (int i = 0; i < Idcheck.Count(); i++)
            {
                if (optionsoutlined[i] == OrderType.Rejected.ToString())
                {
                    check = false;
                }
              await  _orderDetailRepo.UpdateOrderDetailStatus(Idcheck[i], optionsoutlined[i]);
          
            }
            if (!check)
            {
                var order = _orderRepo.GetByIdAsync(int.Parse(TempData["orderID"].ToString()));
                order.Status = OrderType.Rejected.ToString();
                _orderDetailRepo.UpdateOrder(order);
                return RedirectToPage("/LogisticsHandle/OrderBatchManagement");
            }
            return RedirectToPage("/LogisticsHandle/OrderBatchManagement");
          
        }



    }
}

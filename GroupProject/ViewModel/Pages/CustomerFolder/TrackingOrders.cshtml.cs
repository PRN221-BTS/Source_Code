using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV5.DTOs.TrackingOrderObject;
using Repositories.HandleViewFormat;

namespace ViewModel.Pages
{
    public class TrackingOrdersModel : PageModel
    {
        private static OrderTrackingFormat _orderTracking;
        public SendingShipperInfo ShipperInfo { get; set; }
        public TrackingOrdersModel(OrderTrackingFormat orderTracking)
        {
            _orderTracking = orderTracking;
        }
      
        public TrackingViewObject viewObject { get; set; }
        public void OnGet(int id)
        {
          
        
            //viewObject.sendingShipperInfo = new SendingShipperInfo
            //{
            //    ShipperEmail = sendingShipperInfo.ShipperEmail,
            //    ShipperName = sendingShipperInfo.ShipperName,
            //    ShipperPhone = sendingShipperInfo.ShipperPhone,
            //    ShipperVehicle = sendingShipperInfo.ShipperVehicle
            //};
            viewObject = new TrackingViewObject
            {
                sendingShipperInfo = _orderTracking.getSendingShipperInfoByOrderID(id),
                receivingShipperInfo = _orderTracking.getReceivingShipperInfoByOrderID(id),
                warehouseTrackingInfo = _orderTracking.getWarehouseTrackingInfo(id)

            };
                
            
     
           

        }
    }
}

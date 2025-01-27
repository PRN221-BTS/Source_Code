using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV6.DTOs.State;
using ModelsV6.DTOs.TrackingOrderObject;
using Repositories.HelperRepository.HandleViewFormat;

namespace ViewModel.Pages.CustomerFolder.OrderHandle
{
    public class TrackingOrdersModel : PageModel
    {
        private static string DoneProperties = "#86DC3D";
        private static string NotYetProperties = "#808080";
        private static string ComingProperties = "#0000FF";
        private static OrderTrackingFormat _orderTracking;
        public SendingShipperInfo sendingInfo { get; set; }
        public ReceivingShipperInfo receivingInfo { get; set; }

        public List<WarehouseTrackingInfo> warehouseTrackingInfos { get; set; }
        public TrackingOrdersModel(OrderTrackingFormat orderTracking)
        {
            _orderTracking = orderTracking;
        }
      
        public TrackingViewObject viewObject { get; set; }
        public void OnGet(int id)
        {
            receivingInfo = _orderTracking.getReceivingShipperInfoByOrderID(id);
            sendingInfo = _orderTracking.getSendingShipperInfoByOrderID(id);
            warehouseTrackingInfos = _orderTracking.getWarehouseTrackingInfo(id);
            TempData["LastSequenceNumber"] = warehouseTrackingInfos.OrderByDescending(x => x.SequenceNumber).FirstOrDefault().SequenceNumber;
            AddColorPropertyProcess();
            viewObject = new TrackingViewObject
            {
                sendingShipperInfo = sendingInfo,
                receivingShipperInfo = receivingInfo,
                warehouseTrackingInfo = warehouseTrackingInfos
            };
        }

        public void AddColorPropertyProcess()
        {
  
           receivingInfo.ColorProperty = receivingInfo.RouteStatus == OrderInRouteState.Done.ToString() ?  DoneProperties :NotYetProperties;
            if(receivingInfo.RouteStatus == OrderInRouteState.Coming.ToString())
            {
                receivingInfo.ColorProperty = ComingProperties.ToString();
            }
            sendingInfo.ColorProperty = sendingInfo.RouteStatus == OrderInRouteState.Done.ToString() ? DoneProperties : NotYetProperties;
            if(sendingInfo.RouteStatus == OrderInRouteState.Coming.ToString())
            {
                sendingInfo.ColorProperty = ComingProperties.ToString();
            }
            foreach (var item in warehouseTrackingInfos)
            {
                if(item.WarehouseStatus == TrackingState.Shipped.ToString() || item.WarehouseStatus == TrackingState.InWarehouse.ToString())
                {
                    item.ColorProperty = DoneProperties.ToString();
                }
                if(item.WarehouseStatus == TrackingState.Coming.ToString()) {
                    item.ColorProperty = ComingProperties.ToString();
                }
                if(item.WarehouseStatus == TrackingState.InRoute.ToString() || item.WarehouseStatus == TrackingState.Delivery.ToString())
                {
                    item.ColorProperty = NotYetProperties.ToString();
                }
            }
        }
    }
}

﻿using ModelsV5.DAOs;
using ModelsV5.DTOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private static BirdTransportationSystemContext _context = new BirdTransportationSystemContext();
      

        public bool AddNewOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return true;
        }

           
        public List<Order> GetAllOrderByCusotmetID(int id) => _context.Orders.Where(x => x.CustomerId == id).ToList();

        public bool CancelOrderbyOrderID(int id)
        {
           if(_context.Orders.Where( x=> x.OrderId == id &&(x.Status == TrackingState.UnProcessing.ToString() || x.Status == TrackingState.Pending.ToString())) is not null)
            {
               var processOrder =  GetOrderById(id);
                processOrder.Status = TrackingState.Canceling.ToString();
                _context = new BirdTransportationSystemContext();
                _context.Orders.Update(processOrder);
                _context.SaveChanges();
                return false;
            }
            return false;

        }
        public Order GetOrderById(int id) => _context.Orders.FirstOrDefault(x => x.OrderId == id);
        public int GetLastOrder() => _context.Orders.OrderByDescending(x => x.OrderId).FirstOrDefault().OrderId;
   

        public List<OrderDetail> GetOrderDetailByOrderId(int id) => _context.OrderDetails.Where(x => x.OrderId == id).ToList();
    

        public bool Remove(int id)
        {
            _context.Orders.Remove(GetOrderById(id));
            _context.SaveChanges();
            return true;
        }

        public bool UpdateOrder(Order order)
        {
            _context = new BirdTransportationSystemContext();
            _context.Orders.Update(order);
            _context.SaveChanges();
            return true;
        }

        public int GetLastOrderDetailId() => _context.OrderDetails.OrderByDescending(x => x.OrderDetailId).FirstOrDefault().OrderDetailId;
      
    }
}

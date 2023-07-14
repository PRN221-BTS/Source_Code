using BusinessObjects.Models;
using DataAccessLayers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public Task<bool> AddAsync(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}

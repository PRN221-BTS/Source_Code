using ModelsV6.DAOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class PaymentRepository : IPaymentRepository
    {
        BirdTransportationSystemContext _context = new BirdTransportationSystemContext();
        public bool AddAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges(); 
            return true;
        }

        public Task<IEnumerable<Payment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int getLastIDinPayment() => _context.Payments.OrderByDescending(x => x.PaymentId).FirstOrDefault().PaymentId;
        

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Payment payment)
        {
            _context = new BirdTransportationSystemContext();
           _context.Payments.Update(payment);
            _context.SaveChanges();
            return true;
        }
    }
}

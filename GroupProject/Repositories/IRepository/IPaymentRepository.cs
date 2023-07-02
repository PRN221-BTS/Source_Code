using ModelsV2.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IPaymentRepository
    {
        Task<bool> AddAsync(Payment payment);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Payment payment);
    }
}

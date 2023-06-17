using Model.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ICustomerRepository
    {
        bool Register(Customer customer); 
        bool Login(string email, string password);
        Task<bool> AddAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Customer customer);
    }
}

using ModelsV6.DAOs;
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
        Customer Login(string email, string password);
        Task<bool> AddAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Customer customer);

        public bool LoginByAdminAccount(string email, string password);

        Customer GetCustomerById(int id);

        public bool LoginByLogicticsAccount(string email, string password);
        public int GetLastID();

    }
}

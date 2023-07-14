using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICustomerServices
    {
        public Task<bool> AddAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Customer? Login(string email, string password);
        bool Register(Customer customer);
        bool Remove(int id);
        bool Update(Customer customer);
        bool LoginByAdminAccount(string email, string password);
        Customer GetCustomerById(int id);
        bool LoginByLogicticsAccount(string email, string password);
        int GetLastID();
    }
}

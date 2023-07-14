using BusinessObjects.Models;
using DataAccessLayers.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<bool> AddAsync(Customer customer) => _customerRepository.AddAsync(customer);

        public Task<List<Customer>> GetAllAsync() => _customerRepository.GetAllAsync();

        public Task<Customer?> GetByIdAsync(int id) => _customerRepository.GetByIdAsync(id);

        public Customer GetCustomerById(int id) => _customerRepository.GetCustomerById(id);

        public int GetLastID() => _customerRepository.GetLastID();

        public Customer? Login(string email, string password) => _customerRepository.Login(email, password);

        public bool LoginByAdminAccount(string email, string password) => _customerRepository.LoginByAdminAccount(email, password);

        public bool LoginByLogicticsAccount(string email, string password) => _customerRepository.LoginByLogicticsAccount(email, password);

        public bool Register(Customer customer) => _customerRepository.Register(customer);

        public bool Remove(int id) => _customerRepository.Remove(id);

        public bool Update(Customer customer) => _customerRepository.Update(customer);
    }
}

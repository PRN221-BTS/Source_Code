﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelsV6.DAOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class CustomerRepository : ICustomerRepository
    {
        private static BirdTransportationSystemContext _context = new BirdTransportationSystemContext();
        private readonly IConfiguration _configuration;
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
      
        public async Task<bool> AddAsync(Customer customer)
        {
          _context.Customers.Add(customer);
             _context.SaveChanges();
            return true;
        }

        public async Task<List<Customer>> GetAllAsync() => _context.Customers.ToList();   

        public Task<Customer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Customer? Login(string email, string password) {

            Customer? customet = _context.Customers.FirstOrDefault(x => x.Password == password && x.Email == email);
            if (customet is null)
            {
                return null;
            }
            return customet;
        }
        
            
        

        public bool Register(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return true;
        }

        public bool Remove(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerId ==  id);
            _context.Customers.Remove(customer);
            _context.SaveChanges() ;
            return true;
        }

        public bool Update(Customer customer)
        {
            _context = new BirdTransportationSystemContext();
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return true;
        }

        public  bool LoginByAdminAccount(string email,string password)
        {
            var adminEmail = _configuration["LoginAdmin:Email"].ToString();
            var adminPassword = _configuration["LoginAdmin:Password"].ToString();
            if (adminEmail == email && adminPassword == password)
            {
                return true;
            }
            return false;
        }

        public Customer GetCustomerById(int id) => _context.Customers.FirstOrDefault(x => x.CustomerId ==  id);

        public bool LoginByLogicticsAccount(string email, string password)
        {
            var adminEmail = _configuration["LogisticsAccount:Email"].ToString();
            var adminPassword = _configuration["LogisticsAccount:Password"].ToString();
            if (adminEmail == email && adminPassword == password)
            {
                return true;
            }
            return false;
        }

        public int GetLastID()=> (int)_context.Customers.OrderByDescending(x => x.CustomerId).FirstOrDefault()?.CustomerId;


       


        public bool CheckValidationEmail(string email) => !_context.Customers.Any(x => x.Email == email);

        public async Task<bool> EmailExists(int customerId, string email)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId != customerId && c.Email == email);
        }
    }
}

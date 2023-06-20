using Model.DAOs;
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

      
        public Task<bool> AddAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Customer? Login(string email, string password) => _context.Customers.FirstOrDefault(x => x.Password == password && x.Email == email);
        
            
        

        public bool Register(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public  bool LoginByAdminAccount(string email,string password)
        {
             string txt = @"C:\CSharp_Learning\Ki7\PRN221\YogaProject_Final\Source_Code\GroupProject\ViewModel\appsettings.json";
            //string txt = @"..\GroupProject\ViewModel\appsettings.json";
            string jsonString = File.ReadAllText(txt);
            var jo = JsonObject.Parse(jsonString);
            var adminEmail = jo["LoginAdmin"]["Email"].ToString();
            var adminPassword = jo["LoginAdmin"]["Password"].ToString();
            if (adminEmail == email && adminPassword == password)
            {

                return true;
            }
            return false;
        }

        public Customer GetCustomerById(int id) => _context.Customers.FirstOrDefault(x => x.CustomerId ==  id);  
        
    }
}

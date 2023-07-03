using ModelsV4.DAOs;
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

        public Customer? Login(string email, string password) => _context.Customers.FirstOrDefault(x => x.Password == password && x.Email == email);
        
            
        

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

        public bool LoginByLogicticsAccount(string email, string password)
        {
            string txt = @"C:\CSharp_Learning\Ki7\PRN221\YogaProject_Final\Source_Code\GroupProject\ViewModel\appsettings.json";
            //string txt = @"..\GroupProject\ViewModel\appsettings.json";
            string jsonString = File.ReadAllText(txt);
            var jo = JsonObject.Parse(jsonString);
            var adminEmail = jo["LogisticsAccount"]["Email"].ToString();
            var adminPassword = jo["LogisticsAccount"]["Password"].ToString();
            if (adminEmail == email && adminPassword == password)
            {

                return true;
            }
            return false;
        }

        public int GetLastID()=> (int)_context.Customers.OrderByDescending(x => x.CustomerId).FirstOrDefault()?.CustomerId;  
    }
}

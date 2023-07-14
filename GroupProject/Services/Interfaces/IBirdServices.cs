using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBirdServices
    {
        public bool AddAsync(Bird bird);
        public Bird FindById(int id);
        public List<Bird> GetAllAsync();
        public List<Bird> GetByCustomerID(int CustomerID);
        public Bird? GetByIdAsync(int id);
        public int GetLastID();
        public bool Remove(int id);
        public bool Update(Bird bird);
    }
}

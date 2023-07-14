using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.Interfaces
{
    public interface IBirdRepository
    {
        bool AddAsync(Bird bird);
        List<Bird> GetAllAsync();
        Bird? GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Bird bird);

        Bird FindById(int id);

        List<Bird> GetByCustomerID(int CustomerID);

        public int GetLastID();
    }
}

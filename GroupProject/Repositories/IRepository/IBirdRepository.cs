using ModelsV2.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBirdRepository
    {
        Task<bool> AddAsync(Bird bird);
        Task<IEnumerable<Bird>> GetAllAsync();
        Task<Bird?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Bird bird);

        Bird FindById(int id);
    }
}

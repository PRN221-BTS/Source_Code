using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.DAOs;

namespace ViewModel.Pages.Manager.WarehouseManagers
{
    public class IndexModel : PageModel
    {
        private readonly Model.DAOs.BirdTransportationSystemContext _context;

        public IndexModel(Model.DAOs.BirdTransportationSystemContext context)
        {
            _context = context;
        }

        public IList<Warehouse> Warehouse { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Warehouses != null)
            {
                Warehouse = await _context.Warehouses
                .Include(w => w.WarehouseManager).ToListAsync();
            }
        }
    }
}

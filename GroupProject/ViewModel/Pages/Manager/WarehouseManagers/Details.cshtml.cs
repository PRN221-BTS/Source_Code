using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV2.DAOs;

namespace ViewModel.Pages.Manager.WarehouseManagers
{
    public class DetailsModel : PageModel
    {
        private readonly ModelsV2.DAOs.BirdTransportationSystemContext _context;

        public DetailsModel(ModelsV2.DAOs.BirdTransportationSystemContext context)
        {
            _context = context;
        }

      public Warehouse Warehouse { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Warehouses == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(m => m.WarehouseId == id);
            if (warehouse == null)
            {
                return NotFound();
            }
            else 
            {
                Warehouse = warehouse;
            }
            return Page();
        }
    }
}

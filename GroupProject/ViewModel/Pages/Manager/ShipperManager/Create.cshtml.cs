using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsV6.DAOs;

namespace ViewModel.Pages.Manager.ShipperManager
{
    public class CreateModel : PageModel
    {
        private readonly ModelsV6.DAOs.BirdTransportationSystemContext _context;

        public CreateModel(ModelsV6.DAOs.BirdTransportationSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId");
            return Page();
        }

        [BindProperty]
        public Shipper Shipper { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Shippers == null || Shipper == null)
            {
                return Page();
            }

            var checkExistedShipper = await _context.Shippers.FindAsync(Shipper.ShipperId);

            while (checkExistedShipper != null)
            {
                Shipper.ShipperId++;
                checkExistedShipper = await _context.Shippers.FindAsync(Shipper.ShipperId);
            }

            _context.Shippers.Add(Shipper);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

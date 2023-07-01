using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Manager.WarehouseManagers
{
    public class CreateModel : PageModel
    {
        private readonly Model.DAOs.BirdTransportationSystemContext _context;
        private static IWarehouseManagerRepository _warehouseManager;

        [BindProperty]
        public WarehouseManager warehouseManager { get; set; }
        public CreateModel(Model.DAOs.BirdTransportationSystemContext context,IWarehouseManagerRepository warehouseManager)
        {
            _context = context;
            _warehouseManager = warehouseManager;   
        }

        public IActionResult OnGet()
        {
        ViewData["WarehouseManagerId"] = new SelectList(_context.WarehouseManagers, "WarehouseManagerId", "WarehouseManagerId");
            return Page();
        }

        [BindProperty]
        public Warehouse Warehouse { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Warehouses == null || Warehouse == null)
            {
                return Page();
            }
            Warehouse.WarehouseManagerId = warehouseManager.WarehouseManagerId;
            _context.Warehouses.Add(Warehouse);
            await _warehouseManager.AddAsync(warehouseManager);
            await _context.SaveChangesAsync();
            

            return RedirectToPage("./Index");
        }
    }
}

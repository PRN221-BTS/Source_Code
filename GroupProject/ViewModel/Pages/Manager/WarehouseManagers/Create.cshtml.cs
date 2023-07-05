using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsV5.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Manager.WarehouseManagers
{
    public class CreateModel : PageModel
    {
        private readonly ModelsV5.DAOs.BirdTransportationSystemContext _context;
        private static IWarehouseManagerRepository _warehouseManager;

        [BindProperty]
        public WarehouseManager warehouseManager { get; set; }
        public CreateModel(ModelsV5.DAOs.BirdTransportationSystemContext context, IWarehouseManagerRepository warehouseManager)
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
        public WarehouseManager WarehouseManager { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Warehouses == null || Warehouse == null)
            {
                return Page();
            }

            var checkExistedWarehouse = await _context.Warehouses.FindAsync(Warehouse.WarehouseId);
            while (checkExistedWarehouse != null)
            {
                Warehouse.WarehouseId++;
                checkExistedWarehouse = await _context.Warehouses.FindAsync(Warehouse.WarehouseId);
            }

            var warehouseManager = new WarehouseManager();

            Warehouse.WarehouseManagerId = Warehouse.WarehouseId;
            warehouseManager.WarehouseManagerId = Warehouse.WarehouseId;

            _context.Warehouses.Add(Warehouse);
            await _warehouseManager.AddAsync(warehouseManager);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

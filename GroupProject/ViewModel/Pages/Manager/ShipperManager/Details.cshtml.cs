﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV4.DAOs;

namespace ViewModel.Pages.Manager.ShipperManager
{
    public class DetailsModel : PageModel
    {
        private readonly ModelsV4.DAOs.BirdTransportationSystemContext _context;

        public DetailsModel(ModelsV4.DAOs.BirdTransportationSystemContext context)
        {
            _context = context;
        }

      public Shipper Shipper { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shippers == null)
            {
                return NotFound();
            }

            var shipper = await _context.Shippers.FirstOrDefaultAsync(m => m.ShipperId == id);
            if (shipper == null)
            {
                return NotFound();
            }
            else 
            {
                Shipper = shipper;
            }
            return Page();
        }
    }
}
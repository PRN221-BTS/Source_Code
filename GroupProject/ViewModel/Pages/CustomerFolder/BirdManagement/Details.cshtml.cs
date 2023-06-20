﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.DAOs;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class DetailsModel : PageModel
    {
        private readonly Model.DAOs.BirdTransportationSystemContext _context;

        public DetailsModel(Model.DAOs.BirdTransportationSystemContext context)
        {
            _context = context;
        }

      public Bird Bird { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Birds == null)
            {
                return NotFound();
            }

            var bird = await _context.Birds.FirstOrDefaultAsync(m => m.BirdId == id);
            if (bird == null)
            {
                return NotFound();
            }
            else 
            {
                Bird = bird;
            }
            return Page();
        }
    }
}

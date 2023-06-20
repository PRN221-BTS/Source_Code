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
    public class DeleteModel : PageModel
    {
        private readonly Model.DAOs.BirdTransportationSystemContext _context;

        public DeleteModel(Model.DAOs.BirdTransportationSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Birds == null)
            {
                return NotFound();
            }
            var bird = await _context.Birds.FindAsync(id);

            if (bird != null)
            {
                Bird = bird;
                _context.Birds.Remove(Bird);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

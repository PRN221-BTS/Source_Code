using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsV2.DAOs;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class CreateModel : PageModel
    {
        private readonly ModelsV2.DAOs.BirdTransportationSystemContext _context;

        public CreateModel(ModelsV2.DAOs.BirdTransportationSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Birds == null || Bird == null)
            {
                return Page();
            }

            _context.Birds.Add(Bird);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsV6.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class EditModel : PageModel
    {
        private static IBirdRepository _birdRepo;

        public EditModel(IBirdRepository birdRepo)
        {
            _birdRepo = birdRepo;
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            

            var bird =  _birdRepo.GetByIdAsync((int)id);
            if (bird == null)
            {
                return NotFound();
            }
            Bird = bird;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Bird).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!BirdExists(Bird.BirdId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            _birdRepo.Update(Bird);

            return RedirectToPage("./Index");
        }

        //private bool BirdExists(int id)
        //{
        //  return (_context.Birds?.Any(e => e.BirdId == id)).GetValueOrDefault();
        //}
    }
}

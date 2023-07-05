using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV5.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class DeleteModel : PageModel
    {
        private static IBirdRepository _birdRepo;

        public DeleteModel(IBirdRepository birdRepo)
        {
            _birdRepo = birdRepo;
        }

        [BindProperty]
      public Bird Bird { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _birdRepo.GetByIdAsync((int)id) == null)
            {
                return NotFound();
            }

            var bird = _birdRepo.GetByIdAsync((int)id);

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
            _birdRepo.Remove((int)id);

            return RedirectToPage("./Index");
        }
    }
}

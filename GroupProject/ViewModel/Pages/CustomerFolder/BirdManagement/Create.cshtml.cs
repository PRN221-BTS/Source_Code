using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsV6.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class CreateModel : PageModel
    {
        private static IBirdRepository _birdRepo;

        public CreateModel(IBirdRepository birdRepo)
        {
          _birdRepo = birdRepo; 
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
            if(!_birdRepo.CheckValidationBird(Bird.BirdName, int.Parse(HttpContext.Session.GetString("UserID"))))
            {
                ViewData["CheckBirdName"] = "Bird have existed in your list";
                return Page();
            }
          if (!ModelState.IsValid || Bird == null)
            {
                return Page();
            }
            Bird.BirdId = _birdRepo.GetLastID()+1; 
            Bird.CustomerId = int.Parse(HttpContext.Session.GetString("UserID"));
            _birdRepo.AddAsync(Bird);

            return RedirectToPage("./Index");
        }
    }
}

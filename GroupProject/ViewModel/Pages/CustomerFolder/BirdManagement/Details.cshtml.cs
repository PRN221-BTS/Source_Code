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
    public class DetailsModel : PageModel
    {
        private static IBirdRepository _birdRepo;
        private readonly ModelsV5.DAOs.BirdTransportationSystemContext _context;

        public DetailsModel(ModelsV5.DAOs.BirdTransportationSystemContext context,IBirdRepository birdRepo)
        {
            _birdRepo = birdRepo;
        }

      public Bird Bird { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Bird = _birdRepo.FindById((int)id);
            return Page();
        }
    }
}

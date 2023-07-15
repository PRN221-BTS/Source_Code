using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV6.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class IndexModel : PageModel
    {
        private static IBirdRepository _birdRepo;

        public IndexModel(IBirdRepository birdRepository)
        {
            _birdRepo = birdRepository;
        }
        [BindProperty]
        public List<Bird> Bird { get;set; } = default!;

        public void  OnGet()
        {
            Bird = _birdRepo.GetByCustomerID(int.Parse(HttpContext.Session.GetString("UserID")));

        }
    }
}

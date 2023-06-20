using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.DAOs;

namespace ViewModel.Pages.CustomerFolder.BirdManagement
{
    public class IndexModel : PageModel
    {
        private readonly Model.DAOs.BirdTransportationSystemContext _context;

        public IndexModel(Model.DAOs.BirdTransportationSystemContext context)
        {
            _context = context;
        }

        public IList<Bird> Bird { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Birds != null)
            {
                Bird = await _context.Birds.ToListAsync();
            }
        }
    }
}

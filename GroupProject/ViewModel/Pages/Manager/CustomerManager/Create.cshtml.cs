using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsV2.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Manager.CustomerManager
{
    public class CreateModel : PageModel
    {
        private readonly ModelsV2.DAOs.BirdTransportationSystemContext _context;

        private static ICustomerRepository _customerRepository;
        public CreateModel(ModelsV2.DAOs.BirdTransportationSystemContext context,ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Customers == null || Customer == null)
            {
                return Page();
            }
          await _customerRepository.AddAsync(Customer);
            //_context.Customers.Add(Customer);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

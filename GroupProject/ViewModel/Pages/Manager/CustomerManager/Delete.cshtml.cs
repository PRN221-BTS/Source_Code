using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV6.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Manager.CustomerManager
{
    public class DeleteModel : PageModel
    {
        private readonly ModelsV6.DAOs.BirdTransportationSystemContext _context;

        private static ICustomerRepository _customerRepo;
        public DeleteModel(ModelsV6.DAOs.BirdTransportationSystemContext context,ICustomerRepository customerRepo)
        {
            _context = context;
            _customerRepo = customerRepo;
        }

        [BindProperty]
      public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }
            //var customer = await _context.Customers.FindAsync(id);

            //if (customer != null)
            //{
            //    Customer = customer;
            //    _context.Customers.Remove(Customer);
            //    await _context.SaveChangesAsync();
            //}

             _customerRepo.Remove(id);

            return RedirectToPage("./Index");
        }
    }
}

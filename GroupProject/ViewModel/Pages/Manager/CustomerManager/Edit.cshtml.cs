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

namespace ViewModel.Pages.Manager.CustomerManager
{
    public class EditModel : PageModel
    {
        private readonly ModelsV6.DAOs.BirdTransportationSystemContext _context;
        private static ICustomerRepository _customerRepo;
        public EditModel(ModelsV6.DAOs.BirdTransportationSystemContext context,ICustomerRepository customerRepo)
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

            var customer =  await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                bool emailExists = await _customerRepo.EmailExists(Customer.CustomerId, Customer.Email);
                if (emailExists)
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");
                    return Page();
                } 
                else
                {
                    _customerRepo.Update(Customer);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}

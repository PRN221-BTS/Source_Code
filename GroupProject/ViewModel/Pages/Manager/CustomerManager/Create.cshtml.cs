using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ModelsV5.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Manager.CustomerManager
{
    public class CreateModel : PageModel
    {
        private readonly ModelsV5.DAOs.BirdTransportationSystemContext _context;

        private static ICustomerRepository _customerRepository;
        public CreateModel(ModelsV5.DAOs.BirdTransportationSystemContext context, ICustomerRepository customerRepository)
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
                
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.Email == Customer.Email);

            if (existingCustomer != null)
            {
                ModelState.AddModelError(string.Empty, "Email already exists.");
                return Page();
            }

            var checkExistedCustomer = await _context.Customers.FindAsync(Customer.CustomerId);
            
            while (checkExistedCustomer != null)
            {
                Customer.CustomerId++;
                checkExistedCustomer = await _context.Customers.FindAsync(Customer.CustomerId);
            }

            //await _customerRepository.AddAsync(Customer);
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

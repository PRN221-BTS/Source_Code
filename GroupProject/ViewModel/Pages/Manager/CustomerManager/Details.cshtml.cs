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
    public class DetailsModel : PageModel
    {
        private readonly ModelsV6.DAOs.BirdTransportationSystemContext _context;
        private static ICustomerRepository _customerRepo;
        public DetailsModel(ModelsV6.DAOs.BirdTransportationSystemContext context,ICustomerRepository customerRepo)
        {
            _context = context;
            _customerRepo = customerRepo;
        }

      public Customer Customer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer =  _customerRepo.GetCustomerById(id);

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
    }
}

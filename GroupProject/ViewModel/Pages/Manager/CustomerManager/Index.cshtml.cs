using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV5.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Manager.CustomerManager
{
    public class IndexModel : PageModel
    {
        private readonly ModelsV5.DAOs.BirdTransportationSystemContext _context;
        private static ICustomerRepository _customerRepo;
        public IndexModel(ModelsV5.DAOs.BirdTransportationSystemContext context,ICustomerRepository customerRepo)
        {
            _context = context;
            _customerRepo = customerRepo;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                //Customer = await _context.Customers.ToListAsync();
                Customer = await _customerRepo.GetAllAsync();
            }
        }
    }
}

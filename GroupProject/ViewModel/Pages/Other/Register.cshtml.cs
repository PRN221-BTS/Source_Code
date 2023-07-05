using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ModelsV5.DAOs;
using ModelsV5.DTOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Other
{
    public class Register : PageModel
    {
        private static ICustomerRepository _customerRepo;
        public Register(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;   
        }

      
        [BindProperty]
        public RegisterCustomerForm register { get;set; }
        public void OnGet()
        {
        }

        public IActionResult OnPostCustomerRegister()
        {
          
            if(register.Password != register.ConfirmPassword)
            {
                TempData["CheckPassword"] = " your Password and Confirm Password are not match";
                return Page();

            }
            ModelState.ClearValidationState(nameof(RegisterCustomerForm));
            if (!TryValidateModel(register, nameof(RegisterCustomerForm)))
            {
                return Page();
            }
            Customer customer = new Customer
            {
                CustomerId = _customerRepo.GetLastID(),
                CustomerName = register.CustomerName,
                Email = register.CustomerEmail,
                Password = register.Password,
                Phone = register.Phone,
            };
            _customerRepo.AddAsync(customer);
            return RedirectToPage("/Other/Login");
        }
    }
}
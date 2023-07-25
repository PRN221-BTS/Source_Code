using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ModelsV6.DAOs;
using ModelsV6.DTOs;
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
            bool CheckValidation = true;
            if(register.Password != register.ConfirmPassword)
            {
                ViewData["CheckPassword"] = " your Password and Confirm Password are not match";
                CheckValidation = false;
                

            }
            if(!_customerRepo.CheckValidationEmail(register.CustomerEmail))
            {
                ViewData["CheckValidationEmail"] = "The Email have been registered before";
                CheckValidation = false;
             
            }
           // ModelState.ClearValidationState(nameof(RegisterCustomerForm));
            if (!TryValidateModel(register, nameof(RegisterCustomerForm)))
            {
                CheckValidation = false;
            }
            if (!CheckValidation)
            {
                return Page();
            }

            Customer customer = new Customer
            {
                CustomerId = _customerRepo.GetLastID()+1,
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ModelsV4.DAOs;
using ModelsV4.DTOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Other
{
    
    public class Login : PageModel
    {
        ICustomerRepository _customerRepository;
        IShipperRepository _shipperRepository;

        public Login(ICustomerRepository customerRepository, IShipperRepository shipperRepository)
        {
            _customerRepository = customerRepository;
            _shipperRepository = shipperRepository;

        }
        //   private readonly ILogger<Login> _logger;

        [BindProperty]
        public LoginForm loginForm { get; set; }
        //public Login(ILogger<Login> logger)
        //{
        //    _logger = logger;
        //}

        public void OnGet()
        {
        }


        public  IActionResult  OnPost()
        {

            var user = new Object();
            if( _customerRepository.Login(loginForm.Email, loginForm.Password) is not null)
            {
                TempData["ErrorInLogin"] = null;
                Customer customer = _customerRepository.Login(loginForm.Email, loginForm.Password);
                HttpContext.Session.SetString("UserID", customer.CustomerId.ToString());
                return RedirectToPage("/CustomerFolder/Profile");
            }

            if (_shipperRepository.Login(loginForm.Email, loginForm.Password) is not null)
            {
                TempData["ErrorInLogin"] = null;
                Shipper shipper = _shipperRepository.Login(loginForm.Email, loginForm.Password);
                HttpContext.Session.SetString("UserID", shipper.ShipperId.ToString());
                return RedirectToPage("/Shippers/Profile");
            }

            if (_customerRepository.LoginByAdminAccount(loginForm.Email, loginForm.Password))
            {
                TempData["ErrorInLogin"] = null;
                return RedirectToPage("/Manager/MainScreen");
            }

            if(_customerRepository.LoginByLogicticsAccount(loginForm.Email,loginForm.Password))
            {
                TempData["ErrorInLogin"] = null;
                return RedirectToPage("/LogisticsHandle/OrderBatchManagement");
            }

            TempData["ErrorInLogin"] = "Please,Check your email and password ";
            return Page();
        }
    }
}
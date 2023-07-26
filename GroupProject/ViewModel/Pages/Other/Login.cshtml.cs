using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ModelsV6.DAOs;
using ModelsV6.DTOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Other
{
    
    public class Login : PageModel
    {
        ICustomerRepository _customerRepository;
        IShipperRepository _shipperRepository;
        IWarehouseManagerRepository _warehouseManagerRepository;

        public Login(ICustomerRepository customerRepository, IShipperRepository shipperRepository, IWarehouseManagerRepository warehouseManagerRepository)
        {
            _customerRepository = customerRepository;
            _shipperRepository = shipperRepository;
            _warehouseManagerRepository = warehouseManagerRepository;
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
            HttpContext.Session.SetString("Role", "Guest");
        }


        public  IActionResult  OnPost()
        {

            var user = new Object();
            
            if ( _customerRepository.Login(loginForm.Email, loginForm.Password) is not null)
            {
                TempData["ErrorInLogin"] = null;
                Customer customer = _customerRepository.Login(loginForm.Email, loginForm.Password);
                HttpContext.Session.SetString("UserID", customer.CustomerId.ToString());
                HttpContext.Session.SetString("Role", "Customer");
                return RedirectToPage("/CustomerFolder/MainPage");
            }

            if (_shipperRepository.Login(loginForm.Email, loginForm.Password) is not null)
            {
                Shipper shipper = _shipperRepository.Login(loginForm.Email, loginForm.Password);
                HttpContext.Session.SetString("UserID", shipper.ShipperId.ToString());
                HttpContext.Session.SetString("Role", "Shipper");
                TempData["ErrorInLogin"] = null;
                return RedirectToPage("/Shippers/Profile");
            }

            if (_customerRepository.LoginByAdminAccount(loginForm.Email, loginForm.Password))
            {
                HttpContext.Session.SetString("Role", "Admin");
                TempData["ErrorInLogin"] = null;
                return RedirectToPage("/Manager/MainScreen");
            }

            if(_customerRepository.LoginByLogicticsAccount(loginForm.Email,loginForm.Password))
            {
                HttpContext.Session.SetString("Role", "Logistic");
                TempData["ErrorInLogin"] = null;
                return RedirectToPage("/LogisticsHandle/OrderBatchManagement");
            }

            if(_warehouseManagerRepository.LoginWithRoleWarehouseManager(loginForm.Email, loginForm.Password))
            {
                WarehouseManager warehouseManager = _warehouseManagerRepository.Login(loginForm.Email, loginForm.Password);
                HttpContext.Session.SetString("UserID", warehouseManager.WarehouseManagerId.ToString());
                HttpContext.Session.SetString("WarehouseID", warehouseManager.WarehouseManagerId.ToString());
                HttpContext.Session.SetString("Role", "WarehouseManager");
                TempData["ErrorInLogin"] = null;
                return RedirectToPage("/Warehouses/MainScreen");
            }

            TempData["ErrorInLogin"] = "Please,Check your email and password ";
            return Page();
        }
    }
}
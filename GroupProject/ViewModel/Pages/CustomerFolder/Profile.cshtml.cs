using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV5.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder
{
    public class ProfileModel : PageModel
    {
        private static ICustomerRepository _customerRepo;

       
       public Customer customer { get ; set; }   
        public ProfileModel(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public void OnGet()
        {
            int value = Int32.Parse(HttpContext.Session.GetString("UserID").ToString());
            customer = _customerRepo.GetCustomerById(value);
        }
    }
}

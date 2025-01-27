using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV6.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.CustomerFolder
{
    public class MainPageModel : PageModel
    {
        private static ICustomerRepository _customerRepo;
        public Customer customer { get; set; }
        public MainPageModel(ICustomerRepository customerRepo)
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

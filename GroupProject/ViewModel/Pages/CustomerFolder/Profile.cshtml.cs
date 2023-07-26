using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsV6.DAOs;
using Repositories.IRepository;
using System.Threading.Tasks;

namespace ViewModel.Pages.CustomerFolder
{
    public class ProfileModel : PageModel
    {
        private readonly ICustomerRepository _customerRepo;

        [BindProperty]
        public Customer Customer { get; set; }

        public ProfileModel(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public IActionResult OnGet()
        {
            if (!int.TryParse(HttpContext.Session.GetString("UserID"), out int userId))
            {
                return RedirectToPage("/Login");
            }

            Customer = _customerRepo.GetCustomerById(userId);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateUser()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool emailExists = await _customerRepo.EmailExists(Customer.CustomerId, Customer.Email);

            if (emailExists)
            {
                ModelState.AddModelError(nameof(Customer.Email), "Email already exists.");
                return Page();
            }
            else
            {
                _customerRepo.Update(Customer);
            }

            return RedirectToPage("/CustomerFolder/Profile");
        }
    }
}

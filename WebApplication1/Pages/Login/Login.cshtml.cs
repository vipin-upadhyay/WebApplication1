using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IRegistration appDbContext;
        public LoginModel(IRegistration _appDbContext)
        {
            this.appDbContext = _appDbContext;
        }
        [BindProperty]
        public Registrations registration { get; set; }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost(string Email, string Password, string returnUrl=null)
        {

            var userEmail = appDbContext.GetFirstOrDefault(r => r.Email == Email && r.Password == Password);
            
                if (userEmail != null && userEmail?.Email == Email && userEmail?.Password == Password)
                {
                    var firstName = appDbContext.GetFirstOrDefault(x => x.Email == Email && x.Password == Password);
                    TempData["Success"] = "Login Successfull";
                    TempData["FirstName"] = firstName?.FirstName + " " + firstName?.LastName;
                returnUrl= returnUrl ?? "/UserDetails/Details";
                return RedirectToPage(returnUrl);
            }
            
            TempData["Error"] = "Email and password is invalid";
            return Page();

        }
        

    }
}

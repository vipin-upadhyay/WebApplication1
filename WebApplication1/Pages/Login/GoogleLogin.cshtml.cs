using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging.Console;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Pages.Login
{
    public class GoogleLoginModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signinManager;

        private readonly IRegistration appDbContext;
        public GoogleLoginModel(IRegistration _appDbContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager)
        {
            this.appDbContext = _appDbContext;
            this.userManager = userManager;
            this.signinManager = signinManager; 
        }
        [BindProperty]
        public Registrations registration { get; set; }
        public IActionResult OnGet()
        {
            var properties = new AuthenticationProperties { RedirectUri = "/UserDetails/Details"};
            TempData["Success"] = "Login successfull";
             return  Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
    }
}

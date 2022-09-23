using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace WebApplication1.Pages.Login
{
    public class FacebookLoginModel : PageModel
    {
        public IActionResult OnGet()
        { 

          var properties = new AuthenticationProperties { RedirectUri = "/UserDetails/Details" };
        TempData["Success"] = "Login successfull";
             return  Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }
    }
}

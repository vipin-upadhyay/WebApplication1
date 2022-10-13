using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Pages.Registration
{
    public class AddNewUserModel : PageModel
    {
        public readonly IRegistration appDbContext;

        public AddNewUserModel(IRegistration _appdbContext)
        {
            appDbContext = _appdbContext;
        }
        [BindProperty]
        public Registrations registration { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(IFormCollection form)
        {
            try
            {
                
                var email = form["registration.Email"];
                var userEmail = appDbContext.GetFirstOrDefault(x => x.Email == email.ToString());
                if (userEmail?.Email == email.ToString())
                {
                    ModelState.AddModelError("Email", "Email already exist ");
                }
                if (ModelState.IsValid)
                {

                    appDbContext.Add(registration);
                    appDbContext.Save();

                    var msg = "Registration successfull";
                    TempData["Success"] = msg;
                    var isValid = true;
                    return new JsonResult(isValid);

                }
                    return Page();
            }
            catch (Exception ex)
            {
                ex.Data.Add("Id", registration.Id);
                ex.Data.Add("FirstName", registration.FirstName);
                ex.Data.Add("LastName", registration.LastName);
                ex.Data.Add("Email", registration.Email);
                return RedirectToPage("Error");
            }

        }
        }
}

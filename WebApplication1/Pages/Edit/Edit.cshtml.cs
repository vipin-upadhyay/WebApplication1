using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Pages.Edit
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public readonly IRegistration appDbContext;

        public EditModel(IRegistration _appdbContext)
        {
            appDbContext = _appdbContext;
        }
        [BindProperty]

        public Registrations registration { get; set; }
        public void OnGet(int id)
        {
            registration = appDbContext.GetFirstOrDefault(x=> x.Id == id);
            if (registration != null)
                TempData["FirstName"] = registration.FirstName + " " + registration.LastName;
            TempData["Success"] = "Edited Successfull";
        }
        public async Task<IActionResult> OnPost(int id)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    registration.IsDataEdited = true;
                    appDbContext.Update(registration);
                    appDbContext.Save();
                    TempData["FirstName"] = registration.FirstName + " " + registration.LastName;
                    TempData["Success"] = "Updated Successfull";
                    return RedirectToPage("/UserDetails/Details");
                }
                return Page();
            }
            catch (Exception ex)
            {
                ex.Data.Add("FirstName", registration.FirstName);
                ex.Data.Add("LastName", registration.LastName);
                ex.Data.Add("Email", registration.Email);
                return RedirectToPage("Error");
            }

        }
    }
}

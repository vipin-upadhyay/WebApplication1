using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Pages.Delete
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public readonly IRegistration appDbContext;

        public DeleteModel(IRegistration _appdbContext)
        {
            appDbContext = _appdbContext;
        }
        [BindProperty]

        public Registrations registration { get; set; }
        public void OnGet(int id)
        {
            registration = appDbContext.GetFirstOrDefault(x=>x.Id == id);
            if (registration != null)
                TempData["FirstName"] = registration.FirstName + " " + registration.LastName;
            TempData["Success"] = "Deleted Successfull";
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var detailsFromDb = appDbContext.GetFirstOrDefault(x=>x.Id == registration.Id);
                if (detailsFromDb != null)
                {
                    appDbContext.Remove(detailsFromDb);
                     appDbContext.Save();
                    TempData["FirstName"] = registration.FirstName + " " + registration.LastName;
                    TempData["Success"] = "Deleted Successfull";

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

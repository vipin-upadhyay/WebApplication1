using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;

namespace WebApplication1.Pages.Registration
{
    public class IndexModel : PageModel
    {
        public readonly AppDbContext appDbContext;
        public IndexModel(AppDbContext context)
        {
            appDbContext = context;
        }
        public void OnGet()
        {
           var allUserList = appDbContext.Registrations.ToList();
           // return RedirectToPage("AddNewUser");
        }
    }
}

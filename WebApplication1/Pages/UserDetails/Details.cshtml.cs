using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Domain.Repositories;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Pages.UserDetails
{
    //[Authorize]
    public class DetailsModel : PageModel
    {
        public readonly IRegistration appDbContext;

        public DetailsModel(IRegistration _appdbContext)
        {
            appDbContext = _appdbContext;
        }
        [BindProperty]
        public IEnumerable<Registrations> registration { get; set; }
        
        public void OnGet()
        {
            
            registration = appDbContext.GetAll().OrderBy(x=>x.FirstName).ThenBy(x=>x.LastName);
            TempData["FirstName"] = TempData["FirstName"];
            TempData["Success"] = TempData["Success"];

        }

    }
}

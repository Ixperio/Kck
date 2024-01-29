using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Services.Interfaces;
namespace ProjektArtykuly.Pages
{
    public class AdminPanelModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService userService;

        public AdminPanelModel(IHttpContextAccessor _contextAccessor, IUserService userService)
        {
            this._contextAccessor = _contextAccessor;
            this.userService = userService;
        }
       
        public IActionResult OnGet()
        {
            string wartosc = _contextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            string role = _contextAccessor.HttpContext.Session.GetString("LoggedUserRole");
            if (wartosc != null)
            {
                if (role == "1")
                {
                    return Page();
                }
                else
                {
                    return RedirectToPage("Index");
                }
            }
            
            return RedirectToPage("Index");
        }
    }
}

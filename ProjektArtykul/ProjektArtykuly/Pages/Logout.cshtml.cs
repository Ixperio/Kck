using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektArtykuly.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using DB;
using System.Dynamic;

namespace ProjektArtykuly.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LogoutModel(IHttpContextAccessor _contextAccessor)
        {
            this._contextAccessor = _contextAccessor;
        }
        public IActionResult OnGet()
        {

            _contextAccessor.HttpContext.Session.Remove("LoggedUserRole");
            _contextAccessor.HttpContext.Session.Remove("UserHavingAvatar");
            _contextAccessor.HttpContext.Session.Remove("LoggedInUserId");
            _contextAccessor.HttpContext.Session.Remove("LoggedInUser");
            return RedirectToPage("Index");
        }

    }
}

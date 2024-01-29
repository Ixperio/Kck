using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Services.Interfaces;
using ProjektArtykuly.Models;
using System.Text.Json;
using DB;
using Logic.Enums;
using System.Diagnostics;
using System.Text;
using System.Net.Http;

namespace ProjektArtykuly.Pages
{
    public class AdminUserPanelModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService userService;
        private readonly HttpClient httpClient;
        public string error { get; set; }
        public List<User> users { get; set; }

        public AdminUserPanelModel(IHttpContextAccessor _contextAccessor, IUserService userService)
        {
            this._contextAccessor = _contextAccessor;
            this.userService = userService;
        }
        public void OnPostDelete(int id)
        {
            

            string role = _contextAccessor.HttpContext.Session.GetString("LoggedUserRole");
            
                if (role == "1")
                {
                    var ret = userService.Delete(id);
                        
                    if(ret == UserDeleteStatus.Ok)
                    {
                        error = null;
                    }
                    else
                    {
                        error = "Nie uda³o siê usun¹æ !";
                    }
                OnGet();
            }
            OnGet();
        }

        public void OnPostUpdateRole(int id, string updaterole)
        {
            string role = _contextAccessor.HttpContext.Session.GetString("LoggedUserRole");
            if (role == "1")
            {
                int roleid = int.Parse(updaterole);
                if (roleid > 0)
                {
                    if (userService.UpdateRole(id, roleid))
                     {
                        error = null;
                    }
                    else
                    {
                        error = "Nie uda³o siê zmieniæ roli!";
                    }
                }
            }
            OnGet();
        }
        public IActionResult OnGet()
        {
            string wartosc = _contextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            string role = _contextAccessor.HttpContext.Session.GetString("LoggedUserRole");
            if (wartosc != null)
            {
                if (role == "1")
                {
                   users = userService.GetAllUserAdmin();

                    ViewData["users"] = users;
                    ViewData["error"] = error;

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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Services.Interfaces;
using ProjektArtykuly.Models;

namespace ProjektArtykuly.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService userService;

        public AccountModel(IHttpContextAccessor _contextAccessor, IUserService userService)
        {
            this._contextAccessor = _contextAccessor;
            this.userService = userService;
        }
        public UserModel userModel { get; set; }
        public IActionResult OnGet()
        {
            string wartoscId = _contextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            if (wartoscId != null)
            {
                int userId = int.Parse(wartoscId);

                var UserModel = userService.GetUser(userId);

                var Model = new UserModel()
                {
                    id = UserModel.Id,
                    name = UserModel.Name,
                    email = UserModel.Email,
                    surname = UserModel.Surname,
                    havingavatar = UserModel.HavingAvatar
                };

                userModel = Model;

                ViewData["UserData"] = userModel;   

                return Page();
            }
            
            return RedirectToPage("Index");
        }
    }
}

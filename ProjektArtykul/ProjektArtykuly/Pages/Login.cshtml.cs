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
    public class LoginModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginModel(IHttpContextAccessor _contextAccessor)
        {
            this._contextAccessor = _contextAccessor;
        }
        public string Error { get; set; }
        public class LoginForm
        {
            public string email { get; set; }
            public string password { get; set; }

        }
        public IActionResult OnGet()
        {
            string wartosc = _contextAccessor.HttpContext.Session.GetString("LoggedInUser");
            if (wartosc != null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostLogin(LoginForm loginmodel)
        {
            string url = "https://localhost:7261/api/User/Login/";

            if (!string.IsNullOrEmpty(loginmodel.email) && !string.IsNullOrEmpty(loginmodel.password))
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonSerializer.Serialize(loginmodel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var js = JsonSerializer.Deserialize<UserModel>(responseContent);
                        int userId = js.id;
                        string userName = js.name;
                        int userRole = js.role;
                        bool isAvatar = js.havingavatar;

                        string havingAvatar;
                        if(isAvatar)
                        {
                            havingAvatar = "1";
                        }
                        else
                        {
                            havingAvatar = "0";
                        }
                       
                        if (userName != null)
                        {
                            HttpContext.Session.SetString("LoggedInUser", userName);
                            HttpContext.Session.SetString("LoggedInUserId", userId.ToString());
                            HttpContext.Session.SetString("UserHavingAvatar", havingAvatar);
                            HttpContext.Session.SetString("LoggedUserRole", userRole.ToString());
                            return RedirectToPage("Index");
                        }
                    }

                    Error = "Dane logowania s¹ niepoprawne! - Spróbuj ponownie";
                }
            }

            return Page();
        }

    }
}

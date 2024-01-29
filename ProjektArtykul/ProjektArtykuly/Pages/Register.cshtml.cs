using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektArtykuly.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Azure;
using System.Text.Json.Serialization;

namespace ProjektArtykuly.Pages
{
    public class RegisterModel : PageModel
    {
        
        public string Error { get; set; }
        public class RegisterForm
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string email { get; set; }
            public string emailconfirm { get; set; }
            public string password { get; set; }
            public string passwordconfirm { get; set; }

        }

        public void OnGet()
        {

        }

        public IActionResult OnPostRegister(RegisterForm registermodel)
        {
        
                string url = "https://localhost:7261/api/User/Add";

                if (registermodel.email == registermodel.emailconfirm && registermodel.password == registermodel.passwordconfirm)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var json = JsonSerializer.Serialize(registermodel);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var request = new HttpRequestMessage(HttpMethod.Post, url);
                        request.Content = content;

                        HttpResponseMessage response = client.Send(request);
                        var responseContent = response.Content.ReadAsStringAsync().Result;

                        int js = JsonSerializer.Deserialize<int>(responseContent);
                       
                        if (js > 0)
                        {
                           return RedirectToPage("AdminUserPanel");
                        }
                        else
                        {
                            Error = "Dane rejestracji s¹ nie poprawne! - Spróbuj ponownie";
                          return RedirectToPage("Register");
                        }
                   return RedirectToPage("AdminUserPanel");
                }
                  
            }
            return RedirectToPage("Register");
        }
            
      }
}


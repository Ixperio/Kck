using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektArtykuly.Models;
using System.Text.Json;
using Logic.Services.Interfaces;
using Logic.Services;
using Logic.Dto.Coment;

namespace ProjektArtykuly.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService userService;
        private readonly IComentService comentService;

        public ArticleModel(IHttpClientFactory httpClientFactory, IHttpContextAccessor _contextAccessor,
            IUserService userService, IComentService comentService)
        {
            httpClient = httpClientFactory.CreateClient();
            this._contextAccessor = _contextAccessor;
            this.userService = userService;
            this.comentService = comentService;
        }
        public ArticleModelBig JsonData { get; set; }
        public bool isLogged { get; set; }

        public int articleId { get; set; } = 0;
        public async Task<IActionResult> OnGet(int id)
        {
            articleId = id;
            string name = _contextAccessor.HttpContext.Session.GetString("LoggedInUser");
            if(name != null)
            {
                isLogged = true;
            }

            var response = await httpClient.GetAsync("https://localhost:7261/api/Article/GetArticle/" + id.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            JsonData = JsonSerializer.Deserialize<ArticleModelBig>(content);
            ViewData["JsonData"] = JsonData;
            
            return Page();
        }

        public void OnPostComent(int id,string comenttext){
            if(id > 0){
                int userId = int.Parse(_contextAccessor.HttpContext.Session.GetString("LoggedInUserId"));
                var user = userService.GetUser(userId);
                if (user != null)
                {

                    var coment = new ComentAddDto()
                    {
                        ArticleId = id,
                        AuthorId = user.Id,
                        Description = comenttext
                    };

                    if (comentService.Add(coment) > 0)
                    {
                        Page();
                    }
                    else
                    {
                        Page();
                    }

                }
 
            }
            RedirectToPage("/Articles");

        }
    }
}

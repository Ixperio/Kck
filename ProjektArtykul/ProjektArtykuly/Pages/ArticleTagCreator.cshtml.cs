using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using Logic.Dto.Article;

namespace ProjektArtykuly.Pages
{
    public class ArticleTagCreatorModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService userService;
        private readonly IArticleService articleService;


        public ArticleTagCreatorModel(IHttpContextAccessor _contextAccessor, IUserService userService, IArticleService articleService)
        {
            this._contextAccessor = _contextAccessor;
            this.userService = userService;
            this.articleService = articleService;
        }
        public string error { get; set; } = string.Empty;
        public class ArticleModel
        {
            [Required]
            [StringLength(50)]
            public string title { get; set; }
            [Required]
            [StringLength(500)]
            public string intro { get; set; }
        }
        private bool tryUser()
        {
            string wartosc = _contextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            string role = _contextAccessor.HttpContext.Session.GetString("LoggedUserRole");
            if (wartosc != null)
            {
                if (role == "1" || role == "2")
                {
                    return true;
                }
            }
            return false;
        }
        public IActionResult OnGet()
        {
                if (this.tryUser()) { 
                    return Page();
                }
            
            return RedirectToPage("Index");
        }

        public void OnPostArticle(ArticleModel article)
        {
            if (this.tryUser())
            {
                var articleNew = new ArticleAddEditDto() { Author = int.Parse(_contextAccessor.HttpContext.Session.GetString("LoggedInUserId")), Intro = article.intro, Title = article.title };
                int idNowegoArtykułu = articleService.Add(articleNew);
                if(idNowegoArtykułu > 0)
                {
                    RedirectToPage("ArticleCreateSection?id=" + idNowegoArtykułu);
                    error = "Poprawnie dodano artykuł jego id to : "+idNowegoArtykułu;
                }
                else
                {
                    error = "Nie udało się dodać artykułu - spróbuj ponownie";
                    OnGet();
                }
                
            }
            else
            {
                OnGet();
            }
        }
    }
}

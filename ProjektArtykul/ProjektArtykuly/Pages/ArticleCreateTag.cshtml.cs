using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using Logic.Dto.Article;
using Logic.Dto.Sections;
using ProjektArtykuly.Models;
using Logic.Dto.ArticleParagraph;
using Logic.Dto.Tag; 

namespace ProjektArtykuly.Pages
{
    public class ArticleCreateTagModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService userService;
        private readonly IArticleService articleService;
        private readonly IArticleSectionService articleSectionService;
        private readonly IArticleParagraphService articleParagraphService;
        private readonly ITagService tagService;

        public ArticleCreateTagModel(IHttpContextAccessor _contextAccessor, IUserService userService, IArticleService articleService,
            IArticleSectionService articleSectionService, IArticleParagraphService articleParagraphService, ITagService tagService)
        {
            this._contextAccessor = _contextAccessor;
            this.userService = userService;
            this.articleService = articleService;
            this.articleSectionService = articleSectionService;
            this.articleParagraphService = articleParagraphService;
            this.tagService = tagService;
        }
        public string error { get; set; } = string.Empty;
        public int articleId { get; set; } = 0;

        public List<TagDto> tags { get; set; }

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
        public IActionResult OnGet(int articleId)
        {
            if (this.tryUser())
            {

                //sprawdŸ czy u¿ytkownik jest autorem artyku³u i czy artyku³ istnieje
                var article = articleService.GetArticle(articleId);
                if (article != null)
                {
                    this.articleId = article.Id;
                    int userId = int.Parse(_contextAccessor.HttpContext.Session.GetString("LoggedInUserId"));

                    if (article.Author.Id != userId)
                    {
                        return RedirectToPage("Index");
                    }

                    tags = tagService.GetAllByArticleId(articleId);

                    ViewData["Tags"] = tags;
                    return Page();
                }
            }

            return RedirectToPage("Index");
        }

        public void OnPostAddTag(string tagName, int articleId)
        {
            if (this.tryUser())
            {
                int userId = int.Parse(_contextAccessor.HttpContext.Session.GetString("LoggedInUserId"));
                var article2 = articleService.GetArticle(articleId);
                if (article2 != null)
                {
                    if (article2.Author.Id != userId)
                    {
                        OnGet(articleId);
                    }
                }
                int tagId;
                if (tagService.GetTagsByName(tagName).Count() > 0)
                {

                    //tag istnieje , pobierz jego id
                   tagId = tagService.GetTagsByName(tagName).First().Id;

                }
                else
                {
                    //stworz nowy tag i pobierz jego id
                    TagAddDto tagAddDto = new TagAddDto()
                    {
                        AuthorId = userId,
                        Name = tagName
                    };

                   tagId = tagService.Add(tagAddDto);

                }

                //przydziel ten tag do artyku³u
                tagService.AddTagToArticle(userId,articleId, tagId);
                OnGet(articleId);
            }
        }

        public void OnPostDeleteTag(int articleId, int tagId)
        {
            if (this.tryUser())
            {
                int userId = int.Parse(_contextAccessor.HttpContext.Session.GetString("LoggedInUserId"));
                var article2 = articleService.GetArticle(articleId);
                if (article2 != null)
                {
                    if (article2.Author.Id != userId)
                    {
                        OnGet(articleId);
                    }
                }

                if(tagService.DeleteFromArticle(tagId))
                {

                }
                else
                {
                    error = "Nie uda³o siê usun¹æ !";
                }
                OnGet(articleId);

            }
        }
    }
}

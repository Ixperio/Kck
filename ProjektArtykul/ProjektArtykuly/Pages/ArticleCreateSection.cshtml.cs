using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using Logic.Dto.Article;
using Logic.Dto.Sections;
using ProjektArtykuly.Models;
using Logic.Dto.ArticleParagraph;

namespace ProjektArtykuly.Pages
{
    public class ArticleCreateSectionModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService userService;
        private readonly IArticleService articleService;
        private readonly IArticleSectionService articleSectionService;
        private readonly IArticleParagraphService articleParagraphService;


        public ArticleCreateSectionModel(IHttpContextAccessor _contextAccessor, IUserService userService, IArticleService articleService,
            IArticleSectionService articleSectionService, IArticleParagraphService articleParagraphService)
        {
            this._contextAccessor = _contextAccessor;
            this.userService = userService;
            this.articleService = articleService;
            this.articleSectionService = articleSectionService;
            this.articleParagraphService = articleParagraphService;
        }
        public string error { get; set; } = string.Empty;
        public int articleId { get; set; } = 0;
        public class ArticleSectionModel
        {
            public long SectionId { get; set; }
            public int Position { get; set; }

            public List<ArticleParagraphModel> Paragraphs { get; set; }

        }

        public class ArticleForm
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public List<ArticleSectionModel> ArticleSection { get; set; } = new List<ArticleSectionModel>();
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
                    var articleSections = articleSectionService.GetAllByArticleId(articleId);

                    foreach (var section in articleSections)
                    {
                        List<ArticleParagraphModel> paragraf = new List<ArticleParagraphModel>();
                        List<ArticleParagraphDto> get = articleParagraphService.GetAllBySectionId(section.Id);
                        foreach (var paragraph in get)
                        {
                            paragraf.Add(new ArticleParagraphModel()
                            {

                                id = get.First().Id,
                                title = get.First().Title,
                                description = get.First().Description,
                                position = get.First().position,
                                authorId = get.First().authorId

                            });
                        }
                        ArticleSectionModel artsectmod = new ArticleSectionModel()
                        {
                            SectionId = section.Id,
                            Position = section.position,
                            Paragraphs = paragraf
                        };

                        this.ArticleSection.Add(artsectmod);

                    }

                    ViewData["articleSections"] = this.ArticleSection;
                    return Page();
                }
            }

            return RedirectToPage("Index");
        }

        public void OnPostAddSection(ArticleForm article, int articleId)
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

                SectionAddDto nowaSekcja = new SectionAddDto()
                {
                    articleId = articleId,
                    authorId = userId,
                    position = 1
                };

                long idSekcji = articleSectionService.Add(nowaSekcja, userId);

                ArticleParagraphAddDto nowyParagraf = new ArticleParagraphAddDto()
                {
                    authorId = userId,
                    Description = article.Description,
                    Title = article.Title,
                    idSekcji = idSekcji
                };

                articleSectionService.AddParagraph(idSekcji, 1, userId, nowyParagraf);
                OnGet(articleId);
            }
        }

        public void OnPostUpdateSection(ArticleForm article, int articleId, long idParagrafu)
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

                ArticleParagraphAddDto nowyParagraf = new ArticleParagraphAddDto()
                {
                    Title = article.Title,
                    Description = article.Description
                };

                if(articleParagraphService.Update(idParagrafu, nowyParagraf, userId))
                {
                    OnGet(articleId);
                }
                else
                {
                    this.error = "Nie uda³o siê zaktualizowaæ!";
                    OnGet(articleId);
                }


            }
        }
    }
}

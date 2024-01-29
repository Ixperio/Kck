using Logic.Services.Interfaces;
using Logic.Repos.Intrefaces;
using Logic.Dto.Article;
using Logic.Dto.Sections;
using Logic.Dto.User;
using Logic.Dto.Tag;
using Logic.Enums;
using DB.Entities;
using Logic.Dto.Coment;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Logic.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;
        private readonly IUserRepository userRepository;
        private readonly IComentsRepository comentsRepository;
        private readonly IMarksRepository markRepository;
        private readonly ITagRepository tagRepository;
        private readonly IArticleSectionService articleSectionService;

        public ArticleService(IArticleRepository articleRepository, IUserRepository userRepository, 
            IComentsRepository comentsRepository, IMarksRepository marksRepository, ITagRepository tagRepository,
            IArticleSectionService articleSectionService)
        {
            this.articleRepository = articleRepository;
            this.userRepository = userRepository;
            this.comentsRepository = comentsRepository;
            this.markRepository = marksRepository;
            this.tagRepository = tagRepository;
            this.articleSectionService = articleSectionService;
          
        }

        //pobranie listy wszystkich artykułów
        public List<ArticleDto> GetList()
        {
            var articles = articleRepository.GetAll();

            var result = new List<ArticleDto>();
            foreach (var article in articles)
            {
                var author = userRepository.GetUser(article.Author);
                List<Coments> coments = comentsRepository.GetAllByArticleId(article.Id);
                List<SectionViewDto> sections = articleSectionService.GetAllByArticleId(article.Id);

                var comentsDto = new List<ComentDto>();
                var tagDto = new List<TagDto>();
                var sectionDto = sections;
                //tagi

                var tags = tagRepository.GetAllByArticleId(article.Id);

                foreach (var tag in tags)
                {
                    tagDto.Add(new TagDto()
                    {
                        Id = tag.Id,
                        Name = tag.Name
                    });
                }
                //sekcje

                sectionDto.OrderBy(section => section.position);            

                //autor

                var articleAuthorDto = new UserDto()
                {
                    Id = author.Id,
                    Name = author.Name,
                    Surname = author.Surname,
                    Email = author.Email,
                    Havingavatar = author.HavingAvatar
                };
                //komentarze
                foreach (var coment in coments)
                {
                    var comentAuthor = userRepository.GetUser(coment.AuthorId);
                    short comentMark = markRepository.GetMarkByUserIdAndArticleId(comentAuthor.Id, article.Id);
                    var comentAuthorDto = new UserDto()
                    {
                        Id = comentAuthor.Id,
                        Name = comentAuthor.Name,
                        Surname = comentAuthor.Surname,
                        Email = comentAuthor.Email,
                        Mark = comentMark,
                        Havingavatar = comentAuthor.HavingAvatar
                    };

                    comentsDto.Add(new ComentDto()
                    {
                        Id = coment.Id,
                        Description = coment.Description,
                        CreationDate = coment.Created,
                        Author = comentAuthorDto,
                        Dislikes = coment.DisLikes,
                        Likes = coment.Likes,
                       
                    }); 
                }
                //oceny
                var marks = markRepository.GetAllByArticleId(article.Id);
                double markCount = 0;
                int sum = 0;
                foreach (var mark in marks)
                {
                    markCount += mark.Mark;
                    sum++;
                }
                if(sum != 0)
                {
                    markCount = Math.Round((markCount/sum), 1);
                }
                else
                {
                    markCount = 0;
                }
                //artykuł
                result.Add(new ArticleDto()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Intro = article.Intro,
                    Sekcje = sectionDto,
                    Viewers = article.Viewers,
                    CreationDate = article.CreationDate,
                    Author = articleAuthorDto,
                    Coments = comentsDto,
                    Markmean = markCount,
                    Tagi = tagDto
                });
            }
            return result;
        }
        //pobiera artykuł o okreslonym id
        public ArticleDto GetArticle(int id)
        {
            var articles = this.GetList();
            foreach(var article in articles)
            {
                if(article.Id == id)
                {
                    articleRepository.UpdateViews(id);

                    return article;
                }
            }
            return null;
        }
        //pobiera 3 artykuly z największą liczbą wyświetleń
        public List<ArticleDto> GetBest()
        {
            //pobiera najlepsze z siedmiu ostatnich dni
            DateTime sevenDaysAgo = DateTime.Now.AddDays(-7);
            return this.GetList().OrderByDescending(x => x.Viewers).Where( x => x.CreationDate > sevenDaysAgo).Take(3).ToList();

        }

        //pobiera 3 najnowsze artykuły
        public List<ArticleDto> GetNewest()
        {
            return this.GetList().OrderByDescending(x => x.CreationDate).Take(3).ToList();

        }

        //usuniecie z repozytorium konkretnego artykułu

       
        public ArticleDeleteStatus Delete(int id)
        {
            bool canDeleteArticle = CheckCanDeleteArticle(id);
            if (!canDeleteArticle)
            {
                return ArticleDeleteStatus.ArticleCannotBeDeleted;
            }
            articleRepository.Delete(id);
            return ArticleDeleteStatus.Ok;
        }
        //funkcja zwraca true/false w zależności od pozwolenia na usunięcie.
        private bool CheckCanDeleteArticle(int id)
        {
            return true;
        }

        //dodawnaie do repozytorium
        public int Add(ArticleAddEditDto article)
        {
            var newArticle = new Article()
            {
                Title = article.Title,
                Intro = article.Intro,
                Viewers = 0,
                Author = article.Author,
                CreationDate = DateTime.Now
            };
            articleRepository.Add(newArticle);
            return newArticle.Id;
        }
        //aktualizacja w repozytorium
        public bool Update(int id, ArticleAddEditDto article)
        {
            var existingArticle = articleRepository.GetOne(id);
            if(existingArticle == null)
            {
                return false;
            }
            existingArticle.Title = article.Title;
            existingArticle.Intro = article.Intro;
            bool ret = articleRepository.Update(existingArticle);
            return ret;
         
        }

    }
}

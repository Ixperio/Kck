using Logic.Services.Interfaces;
using Logic.Repos.Intrefaces;
using Logic.Dto.Sections;
using Logic.Dto.ArticleParagraph;
using Logic.Enums;
using DB.Entities;
using DB;
using System.Text;
using Logic.Dto.Tag;
using Azure;
using Logic.Repos.DbImplementations;
using DB.Enums;
using System.Net;

namespace Logic.Services
{
    public class ArticleParagraphService : IArticleParagraphService
    {
        private readonly IArticleParagraphRepository articleParagraphRepository;
        private readonly ISectionRepository sectionRepository;
        private readonly IUserRepository userRepository;

        public ArticleParagraphService(IArticleParagraphRepository articleParagraphRepository, ISectionRepository sectionRepository,
            IUserRepository userRepository)
        {
            this.articleParagraphRepository = articleParagraphRepository;
            this.sectionRepository = sectionRepository;
            this.userRepository = userRepository;
         
        }
       
        //usuniecie z repozytorium konkretnego komentarza
        public ArticleParagraphDeleteStatus Delete(long id)
        {
            bool canDeleteParagraph = CheckCanDeleteParagraph(id);
            if (!canDeleteParagraph)
            {
                return ArticleParagraphDeleteStatus.ArticleParagraphCannotBeDeleted;
            }
            articleParagraphRepository.Delete(id);
            return ArticleParagraphDeleteStatus.Ok;
        }
        //funkcja zwraca true/false w zależności od pozwolenia na usunięcie.
        private bool CheckCanDeleteParagraph(long id)
        {
            return true;
        }

        public ArticleParagraphDto GetOne(long id)
        {
            var ret = articleParagraphRepository.GetOne(id);
            if(ret != null)
            {
                ArticleParagraphDto art = new ArticleParagraphDto()
                {
                    Id = ret.Id,
                    Title = ret.Title,
                    Description = ret.Description,
                    position = ret.position,
                    sectionId = ret.IdSekcji,
                    authorId = ret.AuthorId
                };
                return art;
            }
            return null;
        }

        public List<ArticleParagraphDto> GetAllBySectionId(long id)
        {
            var ret = articleParagraphRepository.GetAllBySectionId(id);
            List<ArticleParagraphDto> listaParagrafow = new List<ArticleParagraphDto>();
            if (ret != null)
            {

                foreach (var item in ret)
                {
                    ArticleParagraphDto art = new ArticleParagraphDto()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        position = item.position,
                        sectionId = item.IdSekcji,
                        authorId = item.AuthorId
                    };
                    listaParagrafow.Add(art);
                }
               
                return listaParagrafow;
            }
            return null;

        }

        //dodawnaie do repozytorium
        public long Add(ArticleParagraphAddDto paragraph, int position, int sessionUserId)
        {
            //session get author id
            var usr = userRepository.GetUser(sessionUserId);
            if ( usr.Rola == DB.Enums.UserRole.Redaktor || usr.Rola == DB.Enums.UserRole.Admin)
            {
                var newParagraph = new ArticleParagraph()
                {
                    Title = paragraph.Title,
                    Description = paragraph.Description,
                    AuthorId = usr.Id,
                    position = position,
                    IsDeleted = false,
                    IdSekcji = paragraph.idSekcji
                };
                if (articleParagraphRepository.Add(newParagraph))
                {
                    return newParagraph.Id;
                }
                else
                {
                    return -1;
                }
            }
            return -1;     

        }

        //aktualizacja w repozytorium
        public bool Update(long id, ArticleParagraphAddDto article, int AuthorId)
        {
            var existingArticle = articleParagraphRepository.GetOne(id);
            if(existingArticle == null || existingArticle.AuthorId != AuthorId)
            {
                return false;
            }
            existingArticle.Title = article.Title;
            existingArticle.Description = article.Description;

            articleParagraphRepository.Update(existingArticle);
            return true;
        }

    }
}

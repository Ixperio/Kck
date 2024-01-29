using Logic.Services.Interfaces;
using Logic.Repos.Intrefaces;
using Logic.Dto.Sections;
using Logic.Dto.ArticleParagraph;
using Logic.Enums;
using DB.Entities;
using DB;
using System.Text;
using Logic.Dto.Tag;
using Logic.Repos;

namespace Logic.Services
{
    public class ArticleSectionService : IArticleSectionService
    {
        private readonly ISectionRepository sectionRepository;
        private readonly IArticleParagraphRepository articleParagraphRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IUserRepository userRepository;

       // private readonly IPhotoParagraphRepository photoRepository;

        public ArticleSectionService(ISectionRepository sectionRepository, IArticleRepository articleRepository, 
            IArticleParagraphRepository articleParagraphRepository, IUserRepository userRepository)
        {
            this.articleRepository = articleRepository;
            this.sectionRepository = sectionRepository;
            this.articleParagraphRepository = articleParagraphRepository;
            this.userRepository = userRepository;
         
        }

        public SectionViewDto GetOne(long id)
        {

            var sect = sectionRepository.GetSectionById(id);

            List<ArticleParagraphDto> listaParagrafow = new List<ArticleParagraphDto>();
            var articleParagraphs = articleParagraphRepository.GetAllBySectionId(sect.Id);

            foreach (var articleParagraph in articleParagraphs)
            {
                ArticleParagraphDto apd = new ArticleParagraphDto()
                {
                    Id = articleParagraph.Id,
                    authorId = articleParagraph.AuthorId,
                    Description = articleParagraph.Description,
                    position = articleParagraph.position,
                    Title = articleParagraph.Title
                };

                listaParagrafow.Add(apd);
            }

            SectionViewDto section = new SectionViewDto()
            {
                Id = sect.Id,
                articleId = sect.articleId,
                position = sect.position,
                articleParagraph = listaParagrafow

            };

            return section;
        }

        //pobranie listy wszystkich użytkownikow

        public List<SectionViewDto> GetAllByArticleId(int articleid)
        {
            var sections = sectionRepository.GetAllByArticleId(articleid);
            var result = new List<SectionViewDto>();

            foreach (var section in sections)
            {
                var list = this.GetOne(section.Id);
                result.Add(list);
            }

            return result;
        }
       
        //usuniecie z repozytorium konkretnego komentarza
        public ArticleSectionDeleteStatus Delete(long id)
        {
            bool canDeleteTag = CheckCanDeleteSection(id);
            if (!canDeleteTag)
            {
                return ArticleSectionDeleteStatus.ArticleSectionCannotBeDeleted;
            }
            sectionRepository.Delete(id);
            return ArticleSectionDeleteStatus.Ok;
        }
        //funkcja zwraca true/false w zależności od pozwolenia na usunięcie.
        private bool CheckCanDeleteSection(long id)
        {
            return true;
        }

        //dodawnaie do repozytorium
        public long Add(SectionAddDto section, int sessionUserId)
        {
            var usr = userRepository.GetUser(sessionUserId);
            if (usr.Rola == DB.Enums.UserRole.Redaktor || usr.Rola == DB.Enums.UserRole.Admin)
            {
                var newSection = new ArticleSections()
                {
                    position = section.position,
                    articleId = section.articleId,
                    IsDeleted = false,
                    authorId = section.authorId

                };
                sectionRepository.Add(newSection);
                return newSection.Id;
            }
            return -1;
            
        }

        public long AddParagraph(long sectionId,int position, int sessionUserId, ArticleParagraphAddDto article)
        {
            var usr = userRepository.GetUser(sessionUserId);
            if (usr.Rola == DB.Enums.UserRole.Redaktor || usr.Rola == DB.Enums.UserRole.Admin)
            {
                if(this.GetOne(sectionId) != null)
                {
                    ArticleParagraph cos = new ArticleParagraph()
                    {
                        IdSekcji = sectionId,
                        Description = article.Description,
                        position = position,
                        Title = article.Title,
                        AuthorId = usr.Id,
                        IsDeleted=false
                    };
                    if (articleParagraphRepository.Add(cos))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                }

            }
            return -1;
        }

        //aktualizacja w repozytorium
        public bool Update(long id, SectionAddDto section, int AuthorId)
        {
            var existingSection = sectionRepository.GetSectionById(id);
            var article = articleRepository.GetOne(existingSection.articleId);
            if(existingSection == null || article.Author != AuthorId)
            {
                return false;
            }
            existingSection.position = section.position;
            sectionRepository.Update(existingSection);
            return true;
        }

    }
}

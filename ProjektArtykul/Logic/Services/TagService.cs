using Logic.Services.Interfaces;
using Logic.Repos.Intrefaces;
using Logic.Dto.Coment;
using Logic.Enums;
using DB.Entities;
using DB;
using System.Text;
using Logic.Dto.Tag;
using Logic.Repos.DbImplementations;

namespace Logic.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;
        private readonly IArticleService articleService;

        public TagService(ITagRepository tagRepository, IArticleService articleService)
        {
            this.tagRepository = tagRepository;
            this.articleService = articleService;
        }

        //pobranie listy wszystkich użytkownikow
        public List<TagDto> GetList()
        {
            var tags = tagRepository.GetAll();
            var result = new List<TagDto>();
            foreach (var tag in tags)
            {

                result.Add(new TagDto()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    AuthorId = tag.AuthorId,
                    Created = tag.CreatedDate
                });
            }
            return result;
        }

        public List<TagDto> GetAllByIds(List<int> ids)
        {
            var tags = tagRepository.GetAll();
            var result = new List<TagDto>();
            foreach (var tag in tags)
            {
                foreach(var id in ids)
                {
                    if(tag.Id == id)
                    {
                        result.Add(new TagDto()
                        {
                            Id = tag.Id,
                            Name = tag.Name,
                            AuthorId = tag.AuthorId,
                            Created = tag.CreatedDate
                        });
                    }
                }
                
            }
            return result;
        }

        public List<TagDto> GetAllByArticleId(int articleid)
        {
            var tags = tagRepository.GetAllByArticleId(articleid);
            var result = new List<TagDto>();
            foreach(var tag in tags)
            {
                result.Add(new TagDto()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    AuthorId = tag.AuthorId,
                    Created = tag.CreatedDate
                });
            }
            return result;
        }
        public List<TagDto> GetTagsByName(string name)
        {
            var tags = tagRepository.GetAll();
            var result = new List<TagDto>();
            foreach (var tag in tags)
            {
               
                    if (tag.Name == name)
                    {
                        result.Add(new TagDto()
                        {
                            Id = tag.Id,
                            Name = tag.Name,
                            AuthorId = tag.AuthorId,
                            Created = tag.CreatedDate
                        });
                    }
            }
            return result;
        }
        //usuniecie z repozytorium konkretnego komentarza
        public TagDeleteStatus Delete(int id)
        {
            bool canDeleteTag = CheckCanDeleteTag(id);
            if (!canDeleteTag)
            {
                return TagDeleteStatus.TagCannotBeDeleted;
            }
            tagRepository.Delete(id);
            return TagDeleteStatus.Ok;
        }
        //funkcja zwraca true/false w zależności od pozwolenia na usunięcie.
        private bool CheckCanDeleteTag(int id)
        {
            return true;
        }

        public TagDto GetTag(int id)
        {
            var ret = tagRepository.GetTag(id);
            if(ret != null)
            {
                TagDto tag = new TagDto()
                {
                    Id = ret.Id,
                    Name = ret.Name,
                    Created = ret.CreatedDate,
                    AuthorId = ret.AuthorId
                };
                return tag;
            }
            return new TagDto();
        }
        //dodawnaie do repozytorium
        public int Add(TagAddDto tag)
        {
            var newTag = new Tag()
            {
                Name = tag.Name,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            tagRepository.Add(newTag);
            return newTag.Id;
            
        }
        //dodawanie tagu do li
        public int AddTagToArticle(int authorId,int articleId, int TagId)
        {
            //sprawdz czy użytkownik dodający jest twórcą artykułu

            if(articleService.GetArticle(articleId).Author.Id != authorId)
            {
                return -1;
            }
            //sprawdz czy taki tag istnieje
            if(tagRepository.GetTag(TagId) == null) { return  -1; }
            //dodaj
            ArticleTags tag = new ArticleTags() { ArticleId = articleId, TagId = TagId};
            return tagRepository.AddArticleTag(tag);

        } 

        public bool DeleteFormArticle(int tagId)
        {
            return tagRepository.DeleteArticleTag(tagId);
        }

        //aktualizacja w repozytorium
        public bool Update(int id, TagAddDto tag, int AuthorId)
        {
            var existingTag = tagRepository.GetTag(id);
            if(existingTag == null || existingTag.AuthorId != AuthorId)
            {
                return false;
            }
            existingTag.Name = tag.Name;
            tagRepository.Update(existingTag);
            return true;
        }

    }
}

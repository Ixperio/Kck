using Logic.Services.Interfaces;
using Logic.Repos.Intrefaces;
using Logic.Dto.Coment;
using Logic.Enums;
using DB.Entities;
using DB;
using System.Text;
using Logic.Dto.User;

namespace Logic.Services
{
    public class ComentService : IComentService
    {
        private readonly IComentsRepository comentRepository;
        private readonly IUserRepository userRepository;

        public ComentService(IComentsRepository comentRepository, IUserRepository userRepository)
        {
            this.comentRepository = comentRepository;
            this.userRepository = userRepository;
        }

        //pobranie listy wszystkich użytkownikow
        public List<ComentDto> GetList()
        {
            var coments = comentRepository.GetAll();
            var result = new List<ComentDto>();
            foreach (var coment in coments)
            {
                var author = userRepository.GetUser(coment.AuthorId);
                var authorDto = new UserDto()
                {
                    Id = author.Id,
                    Name = author.Name,
                    Surname = author.Surname,
                    Email = author.Email,
                    Havingavatar = author.HavingAvatar
                };
                result.Add(new ComentDto()
                {
                    Id = coment.Id,
                    Description = coment.Description,
                    ArticleId = coment.ArticleId,
                    Author = authorDto,
                    Likes = coment.Likes,
                    Dislikes = coment.DisLikes,
                    CreationDate = coment.Created
                }) ;
            }
            return result;
        }
        //usuniecie z repozytorium konkretnego komentarza
        public ComentDeleteStatus Delete(long id)
        {
            bool canDeleteUser = CheckCanDeleteComent(id);
            if (!canDeleteUser)
            {
                return ComentDeleteStatus.ComentCannotBeDeleted;
            }
            comentRepository.Delete(id);
            return ComentDeleteStatus.Ok;
        }
        //funkcja zwraca true/false w zależności od pozwolenia na usunięcie.
        private bool CheckCanDeleteComent(long id)
        {
            return true;
        }

        public ComentDto GetComent(long id)
        {
            var ret = comentRepository.GetOne(id);

            var author = userRepository.GetUser(ret.AuthorId);
            var authorDto = new UserDto()
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
                Email = author.Email,
                Havingavatar = author.HavingAvatar
            };

            ComentDto coment = new ComentDto()
            {
                Id = ret.Id,
                Description = ret.Description,
                ArticleId = ret.ArticleId,
                Author = authorDto,
                Likes = ret.Likes,
                Dislikes = ret.DisLikes,
                CreationDate = ret.Created
            };
            return coment;
        }
        //dodawnaie do repozytorium
        public long Add(ComentAddDto coment)
        {
            var newComent = new Coments()
            {
                Description = coment.Description,
                ArticleId = coment.ArticleId,
                AuthorId = coment.AuthorId,
                Created = DateTime.Now,
                IsDeleted = false,
                Likes = 0,
                DisLikes = 0

            };
            comentRepository.Add(newComent);
            return newComent.Id;
            
        }

        //aktualizacja w repozytorium
        public bool Update(long id, ComentAddDto coment, int AuthorId)
        {
            var existingComent = comentRepository.GetOne(id);
            if(existingComent == null || existingComent.AuthorId != AuthorId)
            {
                return false;
            }
            existingComent.Description = coment.Description;
            comentRepository.Update(existingComent);
            return true;
        }

    }
}

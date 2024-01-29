using Logic.Services.Interfaces;
using Logic.Repos.Intrefaces;
using Logic.Dto.Mark;
using Logic.Enums;
using DB.Entities;
using DB;
using System.Text;

namespace Logic.Services
{
    public class MarkService : IMarkService
    {
        private readonly IMarksRepository markRepository;

        public MarkService(IMarksRepository markRepository)
        {
            this.markRepository = markRepository;
           
        }

        //pobranie listy wszystkich ocen
        public List<MarkDto> GetList()
        {
            var marks = markRepository.GetAll();
            var result = new List<MarkDto>();
            foreach (var mark in marks)
            {
                result.Add(new MarkDto()
                {
                   Id = mark.Id,
                   UserId = mark.UserId,
                   Mark = mark.Mark,
                   ArticleId = mark.ArticleId
                }) ;
            }
            return result;
        }
        //usuniecie z repozytorium konkretnej oceny
        public MarkDeleteStatus Delete(long id)
        {
            bool canDeleteUser = CheckCanDeleteMark(id);
            if (!canDeleteUser)
            {
                return MarkDeleteStatus.MarkCannotBeDeleted;
            }
            markRepository.Delete(id);
            return MarkDeleteStatus.Ok;
        }
        //funkcja zwraca true/false w zależności od pozwolenia na usunięcie.
        private bool CheckCanDeleteMark(long id)
        {
            return true;
        }
        public double CountAllMarksMeanByArticleId(int ArticleId)
        {
            double val = markRepository.CountAllMarksMeanByArticleId(ArticleId);
            return val;
          
        }
        public MarkDto GetMark(long id)
        {
            var ret = markRepository.GetOne(id);

            MarkDto mark = new MarkDto()
            {
                Id = ret.Id,
                Mark = ret.Mark,
                ArticleId = ret.ArticleId,
                UserId = ret.UserId
            };
            return mark;
        }

        public short GetMarkByUserIdAndArticleId(int userId, int articleId)
        {
            return markRepository.GetMarkByUserIdAndArticleId(userId, articleId);
        }

        //dodawnaie do repozytorium
        public long Add(MarkAddDto mark)
        {
            var newMark = new Marks()
            {
                Mark = mark.Mark,
                ArticleId = mark.ArticleId,
                UserId = mark.UserId
            };
            markRepository.Add(newMark);
            return newMark.Id;
            
        }

        //aktualizacja w repozytorium
        public bool Update(long id, MarkAddDto mark, int UserId)
        {
            var existingMark = markRepository.GetOne(id);
            if(existingMark == null || existingMark.UserId != UserId)
            {
                return false;
            }
            existingMark.Mark = mark.Mark;
            markRepository.Update(existingMark);
            return true;
        }

    }
}

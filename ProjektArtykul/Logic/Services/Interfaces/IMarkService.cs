using DB.Entities;
using Logic.Dto.Mark;
using Logic.Enums;

namespace Logic.Services.Interfaces
{
    public interface IMarkService
    {
        List<MarkDto> GetList();
        MarkDto GetMark(long id);
        MarkDeleteStatus Delete(long id);
        short GetMarkByUserIdAndArticleId(int userId, int articleId);
        double CountAllMarksMeanByArticleId(int articleId);
        long Add(MarkAddDto mark);
        bool Update(long id, MarkAddDto mark, int AuthorId);
      
    }
}

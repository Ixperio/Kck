using DB.Entities;

namespace Logic.Repos.Intrefaces
{
    public interface IMarksRepository
    {
        List<Marks> GetAllByIds(List<long> ids);
        List<Marks> GetAll();
        Marks GetOne(long id);
        List<Marks> GetAllByUserId(int id);
        List<Marks> GetAllByArticleId(int id);
        short GetMarkByUserIdAndArticleId(int userId, int articleId);
        double CountAllMarksMeanByArticleId(int articleId);
        bool Update(Marks mark);
        long Add(Marks mark);
        bool Delete(long id);
    }
}

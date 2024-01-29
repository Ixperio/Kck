using DB.Entities;

namespace Logic.Repos.Intrefaces
{
    public interface IComentsRepository
    {
        List<Coments> GetAllByIds(List<long> ids);
        List<Coments> GetAll();
        Coments GetOne(long id);
        List<Coments> GetAllByAuthorId(int id);
        List<Coments> GetAllByArticleId(int id);
        bool Update(Coments article);
        long Add(Coments article);
        bool Delete(long id);
    }
}

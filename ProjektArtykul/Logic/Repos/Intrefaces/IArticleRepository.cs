using DB.Entities;

namespace Logic.Repos.Intrefaces
{
    public interface IArticleRepository
    {
        List<Article> GetAllByIds(List<int> ids);
        List<Article> GetAll();
        List<Article> GetBest();
        List<Article> GetNewest();
        Article GetOne(int id);
        bool Update(Article article);
        bool UpdateViews(int id); //updatowanie liczby wyświetleń
        int Add(Article article);
        bool Delete(int id);
    }
}

using DB.Entities;

namespace Logic.Repos.Intrefaces
{
    public interface ISectionRepository
    {
        List<ArticleSections> GetAllByArticleId(int articleId);
        long Add(ArticleSections section);
        ArticleSections GetSectionById(long id);
        bool Update(ArticleSections section);
        bool Delete(long id);
    }
}

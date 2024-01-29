using DB.Entities;

namespace Logic.Repos.Intrefaces
{
    public interface IArticleParagraphRepository
    {
        ArticleParagraph GetOne(long id);

        List<ArticleParagraph> GetAllBySectionId(long id);
        bool Update(ArticleParagraph article);
        bool Add(ArticleParagraph article);
        bool Delete(long id);
    }
}

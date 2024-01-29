using Logic.Dto.Article;
using Logic.Enums;

namespace Logic.Services.Interfaces
{
    public interface IArticleService
    {
        List<ArticleDto> GetList();
        ArticleDto GetArticle(int id);
        List<ArticleDto> GetBest();
        List<ArticleDto> GetNewest();

        ArticleDeleteStatus Delete(int id);
        int Add(ArticleAddEditDto article);
        bool Update(int id, ArticleAddEditDto article);
    }
}

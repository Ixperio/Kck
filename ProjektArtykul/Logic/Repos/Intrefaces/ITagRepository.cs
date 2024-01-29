using DB.Entities;

namespace Logic.Repos.Intrefaces
{
    public interface ITagRepository
    {
        List<Tag> GetAllByIds(List<int> ids);
        List<Tag> GetAll();
        List<Tag> GetTagsByName(string name);

        List<Tag> GetAllByArticleId(int articleId);
        Tag GetTag(int id);

        List<ArticleTags> GetTagByArticleId(int articleId);
        List<ArticleTags> GetArticleByTagId(int articletagId);
        ArticleTags GetArticleTagById(int articleId);

        bool DeleteArticleTag(int articleId);
        int AddArticleTag(ArticleTags tag);

        bool Update(Tag tag);
        int Add(Tag tag);
        bool Delete(int id);
    }
}

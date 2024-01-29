using DB.Entities;
using Logic.Dto.Mark;
using Logic.Dto.Tag;
using Logic.Enums;

namespace Logic.Services.Interfaces
{
    public interface ITagService
    {
        List<TagDto> GetList();
        List<TagDto> GetAllByIds(List<int> ids);
        List<TagDto> GetTagsByName(string tag);
        List<TagDto> GetAllByArticleId(int articleId);
        TagDto GetTag(int id);
        TagDeleteStatus Delete(int id);
        int Add(TagAddDto mark);
        public int AddTagToArticle(int authorId, int articleId, int TagId);
        bool Update(int id, TagAddDto mark,int authorId);
        bool DeleteFromArticle(int tagId);
    
    }
}

using DB.Entities;
using Logic.Dto.ArticleParagraph;
using Logic.Dto.Sections;
using Logic.Enums;

namespace Logic.Services.Interfaces
{
    public interface IArticleParagraphService
    {
        List<ArticleParagraphDto> GetAllBySectionId(long id);
        ArticleParagraphDto GetOne(long id);
        ArticleParagraphDeleteStatus Delete(long id);
        long Add(ArticleParagraphAddDto section, int position, int sessionUserId);
        bool Update(long id, ArticleParagraphAddDto section,int authorId);
    }
}

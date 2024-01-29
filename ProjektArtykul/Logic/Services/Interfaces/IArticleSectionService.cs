using Logic.Dto.ArticleParagraph;
using Logic.Dto.Sections;
using Logic.Enums;

namespace Logic.Services.Interfaces
{
    public interface IArticleSectionService
    {
   
        List<SectionViewDto> GetAllByArticleId(int articleId);
        ArticleSectionDeleteStatus Delete(long id);
        long AddParagraph(long sectionId, int position, int sessionUserId, ArticleParagraphAddDto article);
        long Add(SectionAddDto section, int sessionUserId);
        bool Update(long id, SectionAddDto section,int authorId);
    }
}

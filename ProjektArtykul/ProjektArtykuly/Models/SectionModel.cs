using DB;


namespace ProjektArtykuly.Models
{
    public class SectionModel
    {
        public long Id { get; set; }

        public List<ArticleParagraphModel> articleParagraph { get; set; }
        public int position { get; set; }
        public int articleId { get; set; }
    }
}

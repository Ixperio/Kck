using DB;

namespace ProjektArtykuly.Models
{
    public class ArticleParagraphModel
    {
        public long id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int position { get; set; }
        public int authorId { get; set; }
    }
}

using DB;


namespace ProjektArtykuly.Models
{
    public class ArticleCreatorModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string intro { get; set; }
        public List<SectionModel> sekcje { get; set; }
        public int authorId { get; set; }
        public List<TagModel> tagi { get; set; }

    }
}

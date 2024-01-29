using DB;


namespace ProjektArtykuly.Models
{
    public class ArticleModelBig
    {
        public int id { get; set; }
        public string title { get; set; }
        public string intro { get; set; }
        public List<SectionModel> sekcje { get; set; }
        public int viewers { get; set; }
        public UserModel author { get; set; }
        public List<ComentsModel> coments { get; set; }
        public List<TagModel> tagi { get; set; }
        public double markmean { get; set; }
        public DateTime creationDate { get; set; }

    }
}

using DB;

namespace ProjektArtykuly.Models
{
    public class ComentsModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime creationDate { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public UserModel author { get; set; }
        

    }
}

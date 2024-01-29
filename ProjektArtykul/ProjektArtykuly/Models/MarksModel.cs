using DB;

namespace ProjektArtykuly.Models
{
    public class MarksModel
    {
        public int id { get; set; }
        public short mark { get; set; }
        public int userid { get; set; }
        public string articleid { get; set; }

    }
}

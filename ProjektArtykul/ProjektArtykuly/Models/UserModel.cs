using DB;

namespace ProjektArtykuly.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public int role { get; set; }
        public short mark { get; set; }
        public bool havingavatar { get; set; }
    }
}

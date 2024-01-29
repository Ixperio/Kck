using DB;
using DB.Enums;
using System.ComponentModel.DataAnnotations;

namespace Logic.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public short Mark { get; set; }

        public bool Havingavatar { get; set; }
    }
}

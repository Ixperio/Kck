using DB;
using DB.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Logic.Dto.User
{
    public class UserAddDto
    {
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [StringLength(64)]
        public string Surname { get; set; }
        [Required]
        [StringLength(256)]
        public string Email { get; set; }
        [Required]
        [StringLength(256)]
        public string EmailConfirm { get; set; }
        [Required]
        [StringLength(256)]
        public string Password { get; set; }
        [Required]
        [StringLength(256)]
        public string PasswordConfirm { get; set; }
        [Required]
        public bool Havingavatar { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dto.User
{
    public class UserLoginDto
    {
        [Required]
        [StringLength(256)]
        public string Email { get; set; }
        [Required]
        [StringLength(256)]
        public string Password { get; set; }

    }
}

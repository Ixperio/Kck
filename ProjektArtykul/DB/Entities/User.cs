using DB.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
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
        public string Password { get; set; }
        [Required]
        public UserRole Rola { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool HavingAvatar { get; set; }
    }
}


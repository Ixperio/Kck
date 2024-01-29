using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DB.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Intro { get; set; }
        [Required]
        public int Viewers { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        public int Author { get; set; }
        [Required]
        public bool IsHidden { get; set; } = true;


    }
}

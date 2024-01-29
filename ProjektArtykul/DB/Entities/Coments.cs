using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Coments
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public int ArticleId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }


    }
}

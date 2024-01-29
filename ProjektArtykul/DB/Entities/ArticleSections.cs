using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Enums;

namespace DB.Entities
{
    public class ArticleSections
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int articleId { get; set; }
        [Required]
        public int position { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
        [Required]
        public int authorId { get; set; }

    }
}

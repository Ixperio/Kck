using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Marks
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public int ArticleId { get; set; }

        [Required]
        [Range(1, 5)]
        public short Mark { get; set; }

        [Required]
        public int UserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}

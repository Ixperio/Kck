using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class ArticleParagraph
    {
        [Key]
        public long Id { get; set; }
        [StringLength(80)]
        public string Title { get; set; } = null;
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public long IdSekcji { get; set; }

        [Required]
        public int position { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}

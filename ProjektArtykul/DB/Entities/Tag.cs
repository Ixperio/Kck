using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Tag
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}

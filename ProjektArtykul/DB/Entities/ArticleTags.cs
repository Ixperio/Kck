using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DB.Entities
{
    public class ArticleTags
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TagId { get; set; }
        [Required]
        public int ArticleId { get; set; }
       
    }
}

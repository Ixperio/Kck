using System.ComponentModel.DataAnnotations;

namespace Logic.Dto.Article
{
    public class ArticleAddEditDto
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Intro{ get; set; }
        [Required]
        public int Author { get; set; }
        
    }
}

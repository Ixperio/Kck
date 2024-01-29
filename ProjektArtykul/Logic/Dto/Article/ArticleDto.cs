using System.ComponentModel.DataAnnotations;
using Logic.Dto.User;
using Logic.Dto.Coment;
using Logic.Dto.Mark;
using Logic.Dto.Tag;
using Logic.Dto.Sections;

namespace Logic.Dto.Article
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public List<SectionViewDto> Sekcje { get; set; }
        public int Viewers { get; set; }
        public UserDto Author { get; set; }
        public List<ComentDto> Coments { get; set; }
        public List<TagDto> Tagi { get; set; }
        public double Markmean { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dto.ArticleParagraph
{
    public class ArticleParagraphAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long idSekcji { get; set; }
        public int position { get; set; }
        public int authorId { get; set; }
    }
}

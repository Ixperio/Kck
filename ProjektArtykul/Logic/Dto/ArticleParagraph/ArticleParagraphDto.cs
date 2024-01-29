using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dto.ArticleParagraph
{
    public class ArticleParagraphDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int position { get; set; }
        public int authorId { get; set; }
        public long sectionId { get; set; }
    }
}

using DB.Entities;
using DB.Enums;
using Logic.Dto.ArticleParagraph;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dto.Sections
{
    public class SectionViewDto
    {
        public long Id { get; set; }

        public List<ArticleParagraphDto> articleParagraph { get; set; }
        public int position { get; set; }
        public int articleId { get; set; }

    }
}

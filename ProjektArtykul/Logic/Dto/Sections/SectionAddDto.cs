using DB.Entities;
using DB.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dto.Sections
{
    public class SectionAddDto
    {
        public int position { get; set; }
        public int articleId { get; set; }
        public int authorId { get; set; }
    }
}

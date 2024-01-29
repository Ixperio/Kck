using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Dto.User;

namespace Logic.Dto.Mark
{
    public class MarkAddDto
    {
        public int ArticleId { get; set; }

        public short Mark { get; set; }

        public int UserId { get; set; }
    }
}

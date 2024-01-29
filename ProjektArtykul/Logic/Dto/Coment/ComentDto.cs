using Logic.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Dto.Mark;

namespace Logic.Dto.Coment
{
    public class ComentDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public UserDto Author { get; set; }
        public int ArticleId { get; set; }

    }
}

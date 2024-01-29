using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Dto.User;

namespace Logic.Dto.Tag
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int AuthorId { get; set; }
    }
}

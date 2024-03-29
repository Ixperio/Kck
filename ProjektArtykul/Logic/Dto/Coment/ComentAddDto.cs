﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dto.Coment
{
    public class ComentAddDto
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public int ArticleId { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}

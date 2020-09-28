﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VirtualShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        [MinLength(4, ErrorMessage = "Insira no mínimo 4 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        [MinLength(4, ErrorMessage = "Insira no mínimo 4 caracteres")]
        public string Slug { get; set; }
        public int? FatherCategoryId { get; set; }

        [ForeignKey(nameof(FatherCategoryId))]
        public virtual Category CategoryFather { get; set; }
    }
}

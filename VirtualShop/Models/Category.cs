using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? FatherCategoryId { get; set; }

        [ForeignKey(nameof(FatherCategoryId))]
        public virtual Category CategoryFather { get; set; }
    }
}

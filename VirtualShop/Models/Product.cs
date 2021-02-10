using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VirtualShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name="Descrição")]
        public string Desc { get; set; }

        [Display(Name="Preço")]
        public decimal Value { get; set; }
        public int Qty { get; set; }

        #region Correios
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        #endregion
        
        [Display(Name="Código da categoria")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Image> Images { get; set; }

        public Product()
        {

        }

    }
}
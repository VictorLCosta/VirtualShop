using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VirtualShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Informe o nome do produto")]
        public string Name { get; set; }

        [Display(Name="Descrição")]
        [Required(ErrorMessage="Informe a descrição do produto")]
        public string Desc { get; set; }

        [Display(Name="Preço")]
        [Required(ErrorMessage="Informe o preço do produto")]
        public decimal Value { get; set; }

        [Required(ErrorMessage="Insira a quantidade do produto")]
        [Range(0, 1000000, ErrorMessage="O valor em estoque não pode ultrapassar 1000000 de unidades")]
        public int Qty { get; set; }

        #region Correios
        [Range(0, 1000000, ErrorMessage="O valor em estoque não pode ultrapassar 1000000 de unidades")]
        [Required(ErrorMessage="Informe o peso do produto")]
        public double Weight { get; set; }

        [Range(0, 1000000, ErrorMessage="O valor em estoque não pode ultrapassar 1000000 de unidades")]
        [Required(ErrorMessage="Informe a largura do produto")]
        public double Width { get; set; }

        [Range(0, 1000000, ErrorMessage="O valor em estoque não pode ultrapassar 1000000 de unidades")]
        [Required(ErrorMessage="Informe a altura do produto")]
        public double Height { get; set; }

        [Range(0, 1000000, ErrorMessage="O valor em estoque não pode ultrapassar 1000000 de unidades")]
        [Required(ErrorMessage="Informe o comprimento do produto")]
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
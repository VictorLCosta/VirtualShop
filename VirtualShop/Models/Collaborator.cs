using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualShop.Models
{
    public class Collaborator
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MinLength(4, ErrorMessage = "Insira no mínimo 4 caracteres")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(6, ErrorMessage = "Insira no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        public string PasswordConfirm { get; set; }

        /*
         Tipo
        - C = Comum
        - G = Gerente
         */
        public char Type { get; set; }

        public Collaborator()
        {

        }

    }
}

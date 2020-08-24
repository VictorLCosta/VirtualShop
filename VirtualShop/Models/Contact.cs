using System.ComponentModel.DataAnnotations;

namespace VirtualShop.Models
{
    public class Contact
    {
        // NOME
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MinLength(4, ErrorMessage = "O mínimo de caracteres exigidos é 4")]
        public string Name { get; set; }

        // EMAIL
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O texto informado não é um e-mail")]
        public string Email { get; set; }

        // TEXT
        [Required(ErrorMessage = "O campo Texto é obrigatório")]
        [MinLength(200, ErrorMessage = "Digite pelo menos 200 caracteres")]
        [MaxLength(2000)]
        public string Text { get; set; }

        public Contact()
        {
            
        }
    }
}
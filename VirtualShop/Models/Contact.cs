using System.ComponentModel.DataAnnotations;

namespace VirtualShop.Models
{
    public class Contact
    {
        // NOME
        [Required(ErrorMessage = "Preencha o campo do {0}")]
        [MinLength(4)]
        public string Name { get; set; }

        // EMAIL
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // TEXT
        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }

        public Contact()
        {
            
        }
    }
}
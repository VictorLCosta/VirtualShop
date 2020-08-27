using System.ComponentModel.DataAnnotations;

namespace VirtualShop.Models
{
    public class NewsletterEmail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O texto informado não é um e-mail")]
        public string Email { get; set; }

        public NewsletterEmail()
        {
            
        }
    }
}
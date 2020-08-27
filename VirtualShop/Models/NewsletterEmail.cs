using System.ComponentModel.DataAnnotations;

namespace VirtualShop.Models
{
    public class NewsletterEmail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Email � obrigat�rio")]
        [EmailAddress(ErrorMessage = "O texto informado n�o � um e-mail")]
        public string Email { get; set; }

        public NewsletterEmail()
        {
            
        }
    }
}
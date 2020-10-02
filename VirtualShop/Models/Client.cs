using System;
using System.ComponentModel.DataAnnotations;

namespace VirtualShop.Models
{
    public class Client
    {
        /*PK*/
        public int Id { get; set; }

        //DEFINIÇÕES DE NOME
        [Required(ErrorMessage ="Preencha o nome")]
        [MinLength(4, ErrorMessage ="Digite no mínimo 4 caracteres!")]
        public string Name { get; set; }

        //DEFINIÇÕES DE DATA DE NASCIMENTO
        [Required(ErrorMessage ="Preencha a data de nascimento", AllowEmptyStrings = false)]
        [DataType(DataType.Date, ErrorMessage ="Insira uma data válida!")]
        public DateTime BirthDate { get; set; }

        //DEFINIÇÕES DE CPF
        [Required(ErrorMessage ="Preencha o seu CPF")]
       //[RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Preencha seu CPF corretamente")]
        public string CPF { get; set; }

        //DEFINIÇÕES DE SEXO
        [Required(ErrorMessage ="Defina o seu sexo")]
        public string Gender { get; set; }

        //DEFINIÇÕES DE TELEFONE
        [Required(ErrorMessage ="Insira seu telefone")]
        public string Telephone { get; set; }

        //DEFINIÇÕES DE EMAIL
        [Required(ErrorMessage ="Preencha com o seu email")]
        [EmailAddress(ErrorMessage ="Informe um email válido!")]
        public string Email { get; set; }

        //DEFINIÇÕES DE SENHA
        [Required(ErrorMessage ="Informe sua senha")]
        [MinLength(8, ErrorMessage ="Digite no mínimo 8 caracteres")]
        public string Password { get; set; }

        public Client()
        {
            
        }
        
    }
}
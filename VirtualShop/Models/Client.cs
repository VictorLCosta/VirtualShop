using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualShop.Models
{
    public class Client
    {
        /*PK*/
        [Display(Name = "Código")]
        public int Id { get; set; }

        //DEFINI��ES DE NOME
        [Required(ErrorMessage ="Preencha o nome")]
        [MinLength(4, ErrorMessage ="Digite no m�nimo 4 caracteres!")]
        public string Name { get; set; }

        //DEFINI��ES DE DATA DE NASCIMENTO
        [Required(ErrorMessage ="Preencha a data de nascimento", AllowEmptyStrings = false)]
        [DataType(DataType.Date, ErrorMessage ="Insira uma data v�lida!")]
        public DateTime BirthDate { get; set; }

        //DEFINI��ES DE CPF
        [Required(ErrorMessage ="Preencha o seu CPF")]
       //[RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Preencha seu CPF corretamente")]
        public string CPF { get; set; }

        //DEFINI��ES DE SEXO
        [Required(ErrorMessage ="Defina o seu sexo")]
        public string Gender { get; set; }

        //DEFINI��ES DE TELEFONE
        [Required(ErrorMessage ="Insira seu telefone")]
        public string Telephone { get; set; }

        //DEFINI��ES DE EMAIL
        [Required(ErrorMessage ="Preencha com o seu email")]
        [EmailAddress(ErrorMessage ="Informe um email v�lido!")]
        public string Email { get; set; }

        //DEFINI��ES DE SENHA
        [Required(ErrorMessage ="Informe sua senha")]
        [MinLength(8, ErrorMessage ="Digite no m�nimo 8 caracteres")]
        public string Password { get; set; }

        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "A senha não confere com a informada")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Situação")]
        public string Situation { get; set; }

        public Client()
        {
            
        }
        
    }
}
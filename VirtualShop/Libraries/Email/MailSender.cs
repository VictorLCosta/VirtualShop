using VirtualShop.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace VirtualShop.Libraries.Email
{
    public class MailSender
    {
        private SmtpClient _client;
        private IConfiguration Config;

        public MailSender(SmtpClient client, IConfiguration configuration)
        {
            _client = client;
            Config = configuration;
        }

        public void SendContactByEmail (Contact contact)
        {    
            //Mensagem do corpo do email
            string Bodymsg = string.Format("<h2>Contato - Loja Virtual</h2>"
                        + "<b>Nome: </b>{0} <br/>"
                        + "<b>Email: </b>{1} <br/>"
                        + "<b>Texto: </b>{2} <br/>"
                        + "<br/> E-mail enviado automaticamente do site Loja Virtual",
                        contact.Name,
                        contact.Email,
                        contact.Text); 

            /*Construindo a msg de envio*/
            MailMessage message = new MailMessage();

            message.From = new MailAddress(Config.GetValue<string>("Email:UserName")); //configura o email que enviará
            message.To.Add(contact.Email); //destinatário
            message.Subject = $"Contato - Loja Virtual - Email: {contact.Email}"; //assunto do email
            message.Body = Bodymsg; //msg do corpo
            message.IsBodyHtml = true; //especifica que o email é do tipo html

            _client.Send(message); //envia o email
        }

        public void SendPasswordToCollaborator(Collaborator collaborator)
        {
            string Bodymsg = $"<h2>Colaborador - Virtual Shop</h2><br /> Sua senha é: <h3>{collaborator.Password}</h3>"; 

            /*Construindo a msg de envio*/
            MailMessage message = new MailMessage();

            message.From = new MailAddress(Config.GetValue<string>("Email:UserName")); //configura o email que enviará
            message.To.Add(collaborator.Email); //destinatário
            message.Subject = $"Collaborator - Loja Virtual - Senha do colaborador: {collaborator.Name}"; //assunto do email
            message.Body = Bodymsg; //msg do corpo
            message.IsBodyHtml = true; //especifica que o email é do tipo html

            _client.Send(message); //envia o email
        }
    }
}
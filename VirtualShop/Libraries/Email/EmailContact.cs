using VirtualShop.Models;
using System.Net.Mail;
using System.Net;

namespace VirtualShop.Libraries.Email
{
    public class EmailContact
    {
        public static void SendContactByEmail (Contact contact)
        {
            //Servidor de envio
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); //configuração do servidor (pode ser do gmail, outlook e yahoo)

            smtp.UseDefaultCredentials = false; //desabilita as credencias padrão para poder configurar para as credencias do email selecionado
            smtp.Credentials = new NetworkCredential("sandmanfunky@gmail.com", "OveryFucker0435"); //cria novas credencias e seleciona o email que realizara os envios
            smtp.EnableSsl = true; //habilita segurança
            
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

            message.From = new MailAddress("sandmanfunky@gmail.com"); //configura o email que enviará
            message.To.Add(contact.Email); //destinatário
            message.Subject = $"Contato - Loja Virtual - Email: {contact.Email}"; //assunto do email
            message.Body = Bodymsg; //msg do corpo
            message.IsBodyHtml = true; //especifica que o email é do tipo html

            smtp.Send(message); //envia o email
        }
    }
}
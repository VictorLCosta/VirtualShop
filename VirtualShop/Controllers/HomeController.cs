using VirtualShop.Libraries.Email;
using VirtualShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualShop.Repositories.Contracts;

namespace VirtualShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly INewsletterRepository _newsletterRepository;

        public HomeController(IClientRepository repository, INewsletterRepository newsletterRepository)
        {
            _clientRepository = repository;
            _newsletterRepository = newsletterRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm]NewsletterEmail news) 
        {
            if (ModelState.IsValid)
            {

                await _newsletterRepository.InsertAsync(news);
              
                TempData["MSG_S"] = "E-mail cadastrado! Agora você vai receber promoções especiais no seu email! Fique atento";
                
                return RedirectToAction(nameof(Index));
                
            }
            else
            {
                return View();
            }
        }

        public IActionResult ContactAction()
        {
            try
            {
                Contact contact = new Contact();

                contact.Name = HttpContext.Request.Form["name"];
                contact.Email = HttpContext.Request.Form["email"];
                contact.Text = HttpContext.Request.Form["text"];

                var messageList = new List<ValidationResult>();
                var context = new ValidationContext(contact);
                bool isValid = Validator.TryValidateObject(contact, context, messageList, true);

                if(isValid == true)
                {
                    EmailContact.SendContactByEmail(contact);

                    ViewData["MSG_S"] = "Email enviado com sucesso!";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var text in messageList)
                    {
                        sb.Append(text.ErrorMessage + "<br/>");

                        ViewData["MSG_E"] = sb.ToString();
                        ViewData["CONTACT"] = contact;
                    }
                }

            } catch(Exception e)
            {
                ViewData["MSG_E"] = "Ops! Ocorreu um erro, tente novamente mais tarde";
            }

            return View("Contact");
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] Client client) 
        {
            if (client.Email == "victorlc2019@outlook.com" && client.Password == "Icaronon9") 
            {
                HttpContext.Session.Set("Id", new byte[] { 52 });
                HttpContext.Session.SetString("Email", client.Email);
                HttpContext.Session.SetInt32("Idade", 25);

                return new ContentResult() { Content = "Logado!" };
            }
            else 
            {
                return new ContentResult() { Content = "Não logado!" };
            }
        }

        [HttpGet]
        public IActionResult Painel() 
        {
            byte[] UsuarioId; 
            if (HttpContext.Session.TryGetValue("ID", out UsuarioId)) 
            {
                return new ContentResult() { Content = "Usuário " + UsuarioId[0] + " Logado!" };
            }

            return View();
        }

        [HttpGet]
        public IActionResult CostumerRegister()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        [HttpPost]
        public async Task<IActionResult> CostumerRegister([FromForm] Client client) 
        {
            if (ModelState.IsValid) 
            {
                await _clientRepository.IncludeAsync(client);

                TempData["MSG_S"] = "Cadastro realizado com sucesso!";
                
                return RedirectToAction(nameof(CostumerRegister));
            }
            return View();
        }

        public IActionResult ShoppingCart()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }
    }
}
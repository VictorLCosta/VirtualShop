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
using VirtualShop.Libraries.Filter;
using VirtualShop.Libraries.Login;

namespace VirtualShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly INewsletterRepository _newsletterRepository;
        private LoginClient _loginClient;

        public HomeController(IClientRepository repository, INewsletterRepository newsletterRepository, LoginClient loginClient)
        {
            _clientRepository = repository;
            _newsletterRepository = newsletterRepository;
            _loginClient = loginClient;
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
        public async Task<IActionResult> Login([FromForm] Client client) 
        {
            Client clientDb = await _clientRepository.Login(client.Email, client.Password);

            if (clientDb != null) 
            {
                _loginClient.Login(clientDb);

                return RedirectToAction(nameof(Painel));
            }
            else 
            {
                ViewData["MSG_E"] = "Usuário não encontrado!";
                return View();
            }
        }

        [ClientAuthorization]
        [HttpGet]
        public IActionResult Painel() 
        {
            return new ContentResult { Content = "Este é o painel" };
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
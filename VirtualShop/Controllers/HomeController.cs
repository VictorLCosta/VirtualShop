using VirtualShop.Libraries.Email;
using VirtualShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualShop.Repositories;

namespace VirtualShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public HomeController(IClientRepository repository)
        {
            _clientRepository = repository;
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
                /*
                await _context.NewsletterEmails.AddAsync(news);
                await _context.SaveChangesAsync();
                TempData["MSG_S"] = "E-mail cadastrado! Agora você vai receber promoções especiais no seu email! Fique atento";
                */
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

        public IActionResult Login()
        {
          //TODO: Implement Realistic Implementation
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
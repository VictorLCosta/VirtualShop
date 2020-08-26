using VirtualShop.Libraries.Email;
using VirtualShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VirtualShop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]NewsletterEmail news) 
        {
            return View();
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

        public IActionResult CostumerRegister()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        public IActionResult ShoppingCart()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }
    }
}
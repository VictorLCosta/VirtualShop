using VirtualShop.Libraries.Email;
using VirtualShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace VirtualShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
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

                EmailContact.SendContactByEmail(contact);

                ViewData["MSG_S"] = "Email enviado com sucesso!";

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
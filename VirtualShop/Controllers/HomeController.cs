using VirtualShop.Libraries.Email;
using VirtualShop.Models;
using Microsoft.AspNetCore.Mvc;

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
            Contact contact = new Contact();

            contact.Name = HttpContext.Request.Form["name"];
            contact.Email = HttpContext.Request.Form["email"];
            contact.Text = HttpContext.Request.Form["text"];

            EmailContact.SendContactByEmail(contact);
            
            return new ContentResult() { Content = string.Format($"Dados recebidos com sucesso! Nome: {contact.Name}, Email: {contact.Email}, Text: {contact.Text}"),
                                          ContentType = "text/hmtl"};
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
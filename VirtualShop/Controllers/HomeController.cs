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
            string name = HttpContext.Request.Form["name"];
            string email = HttpContext.Request.Form["email"];
            string text = HttpContext.Request.Form["text"];

            return new ContentResult() { Content = string.Format($"Dados recebidos com sucesso! Nome: {name}, Email: {email}, Text: {text}"),
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
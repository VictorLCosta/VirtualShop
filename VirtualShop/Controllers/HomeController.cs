using Microsoft.AspNetCore.Mvc;

namespace VirtualShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
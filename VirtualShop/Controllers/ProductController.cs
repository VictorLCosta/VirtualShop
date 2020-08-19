using Microsoft.AspNetCore.Mvc;

namespace VirtualShop.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Visualize()
        {
            return View();
        }
    }
}
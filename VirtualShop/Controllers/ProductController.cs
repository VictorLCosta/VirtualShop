using Microsoft.AspNetCore.Mvc;

namespace VirtualShop.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Visualizar()
        {
            return new ContentResult() {Content = "<h1>Visualizar</h1>", ContentType = "text/html"};
        }
    }
}
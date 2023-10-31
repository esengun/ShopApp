using Microsoft.AspNetCore.Mvc;

namespace ShopApp.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // localhost:5000/product/list
        public string List()
        {
            return "product/list";
        }

        // localhost:5000/product/details
        public string Details()
        {
            return "product/details";
        }
    }
}

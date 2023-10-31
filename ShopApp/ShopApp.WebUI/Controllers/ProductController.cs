using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.Views.Product;

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

        // localhost:5000/product/details/id?
        public IActionResult Details(int id)
        {
            // name = "Samsung s6"
            // price = 2000
            // description = "android"

            var productDetails = new Product { Name = "samsung s6", Price = 2000, Description = "Android" };
            return View(productDetails);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.Views.Product;

namespace ShopApp.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
			// Methods to send data to view:
			// ViewBag
			// Model
			// ViewData

			var product = new Product { Name = "Iphone X", Price = 2000, Description = "IOS" };

            ViewData["Category"] = "Smartphones";
            ViewData["Product"] = product;

			ViewBag.Products = product;

			return View(product);
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

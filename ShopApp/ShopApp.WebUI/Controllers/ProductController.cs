using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.ViewModels;
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
        public IActionResult List()
        {
            var products = new List<Product>(){
                new Product { Name = "samsung s6", Price = 2000, Description = "Android" },
                new Product { Name = "samsung s7", Price = 3000, Description = "Android", IsApproved = true },
                new Product { Name = "samsung s8", Price = 4000, Description = "Android", IsApproved = true },
				new Product { Name = "samsung s9", Price = 5000, Description = "Android" }
            };

            var category = new Category
            {
                Name = "Smartphones",
                Description = "Android smartphones"
            };

            var productViewModel = new ProductViewModel()
			{
                Category = category,
                Products = products
            };
            
			return View(productViewModel);
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

using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Data;
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

		// localhost:5000/product/list => all products
		// localhost:5000/product/list/2 => all products in category with id=2
		public IActionResult List(int? id)
        {
            var products = ProductRepository.Products;

            if(id != null)
            {
                products =  products.Where(p => p.CategoryId == id).ToList();
            }

            var productViewModel = new ProductViewModel()
            {
                Products = products
            };
            
			return View(productViewModel);
        }

        // localhost:5000/product/details/id?
        public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProductById(id));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.ViewModels;

namespace ShopApp.WebUI.Controllers
{
    // localhost:5000/home
    public class HomeController : Controller
    {
        // localhost:5000/home/index
        public IActionResult Index()
        {
			var products = new List<Product>(){
				new Product { Name = "samsung s6", Price = 2000, Description = "Android" },
				new Product { Name = "samsung s7", Price = 3000, Description = "Android", IsApproved = true },
				new Product { Name = "samsung s8", Price = 4000, Description = "Android", IsApproved = true },
				new Product { Name = "samsung s9", Price = 5000, Description = "Android" }
			};


			var productViewModel = new ProductViewModel()
			{
				Products = products
			};

			return View(productViewModel);
		}

        // localhost:5000/home/about
        public IActionResult About()
        {
            return View();
        }

		// localhost:5000/home/contact
		public IActionResult Contact()
		{
			return View("Contact");
		}

	}
}

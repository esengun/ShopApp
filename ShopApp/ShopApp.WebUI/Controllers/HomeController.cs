using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Data;
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
			var productViewModel = new ProductViewModel()
			{
				Products = ProductRepository.Products
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

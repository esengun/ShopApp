using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    // localhost:5000/home
    public class HomeController : Controller
    {
		private IProductService _productService;

		public HomeController(IProductService productService)
		{
			this._productService = productService;
		}

        // localhost:5000/home/index
        public IActionResult Index()
        {
			var productViewModel = new ProductListViewModel()
			{
				Products = _productService.GetHomeProducts()
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

using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.WebUI.ViewModels;

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
			var productViewModel = new ProductViewModel()
			{
				Products = _productService.GetAll()
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

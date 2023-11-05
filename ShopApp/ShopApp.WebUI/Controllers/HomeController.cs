using Microsoft.AspNetCore.Mvc;
using ShopApp.Data.Abstract;
using ShopApp.WebUI.ViewModels;

namespace ShopApp.WebUI.Controllers
{
    // localhost:5000/home
    public class HomeController : Controller
    {
		private IProductRepository _productRepository;

		public HomeController(IProductRepository productRepository)
		{
			this._productRepository = productRepository;
		}

        // localhost:5000/home/index
        public IActionResult Index()
        {
			var productViewModel = new ProductViewModel()
			{
				Products = _productRepository.GetAll()
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

using Microsoft.AspNetCore.Mvc;

namespace ShopApp.WebUI.Controllers
{
    // localhost:5000/home
    public class HomeController : Controller
    {
        // localhost:5000/home/index
        public IActionResult Index()
        {
            return View();
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

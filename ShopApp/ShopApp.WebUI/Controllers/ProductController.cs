using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		public IActionResult List(int? id, string q)
        {
            // {controller}/{action}/{id?}
            // product/list/3
            // Alternative way is:
            // RouteData.Values["controller"] => product
            // RouteData.Values["action"] => list
            // RouteData.Values["id"] => 3

            // Console.WriteLine(RouteData.Values["controller"]);
            // Console.WriteLine(RouteData.Values["action"]);
            // Console.WriteLine(RouteData.Values["id"]);

            // q will be part of url if provided
            // Console.WriteLine(q);
            // Alternative with QueryString:
            // Console.WriteLine(HttpContext.Request.Query["q"].ToString());

			var products = ProductRepository.Products;

            if(id != null)
            {
                products =  products.Where(p => p.CategoryId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                products = products.Where(p => p.Name.ToLower().Contains(q.ToLower()) 
                || p.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var productViewModel = new ProductViewModel()
            {
                Products = products
            };
            
			return View(productViewModel);
        }

		[HttpGet]
		// localhost:5000/product/details/id?
		public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProductById(id));
        }

        [HttpGet] // If you do not specify, it will be HttpGet as default
		public IActionResult Create() // only responsible for bringing form page
		{
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
			return View();
		}

        [HttpPost]
		public IActionResult Create(Product p) 
		{
            ProductRepository.AddProduct(p);
			return RedirectToAction("List");
		}
	}
}

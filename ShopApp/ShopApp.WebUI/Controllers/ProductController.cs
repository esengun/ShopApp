using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Entity;

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

			//var products = ProductRepository.Products;

			//         if(id != null)
			//         {
			//             products =  products.Where(p => p.CategoryId == id).ToList();
			//         }

			//         if (!string.IsNullOrEmpty(q))
			//         {
			//             products = products.Where(p => p.Name.ToLower().Contains(q.ToLower()) 
			//             || p.Description.ToLower().Contains(q.ToLower())).ToList();
			//         }

			//         var productViewModel = new ProductViewModel()
			//         {
			//             Products = products
			//         };

			//return View(productViewModel);
			return View();
		}

		[HttpGet]
		// localhost:5000/product/details/id?
		public IActionResult Details(int id)
		{
			return View();
		}

		[HttpGet] // If you do not specify, it will be HttpGet as default
		public IActionResult Create() // only responsible for bringing form page
		{
			//ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
			return View(new Product());
		}

		[HttpPost]
		public IActionResult Create(Product p)
		{
			//         if (ModelState.IsValid)
			//         {
			//	ProductRepository.AddProduct(p);
			//	return RedirectToAction("List");
			//}
			//ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
			return View(); // if inputs are invalid, redirect user to create page with the same inputs
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			//ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Edit(Product p)
		{
			//ProductRepository.EditProduct(p);
			return RedirectToAction("List");
		}

		[HttpPost]
		public IActionResult Delete(int ProductId)
		{
			//ProductRepository.DeleteProduct(ProductId);
			return RedirectToAction("List");
		}
	}
}

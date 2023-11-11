using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
	public class AdminController : Controller
	{
		private IProductService _productService;

		public AdminController(IProductService productService)
		{
			this._productService = productService;
		}

		public IActionResult ProductList()
		{
			return View(new ProductListViewModel()
			{
				Products = _productService.GetAll()
			});
		}

		[HttpGet]
		public IActionResult CreateProduct()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateProduct(ProductModel productModel)
		{
			var product = new Product
			{
				Name = productModel.Name,
				Description = productModel.Description,
				Price = productModel.Price,
				Url = productModel.Url,
				ImageUrl = productModel.ImageUrl
			};
			_productService.Create(product);
			return RedirectToAction("ProductList");
		}
	}
}

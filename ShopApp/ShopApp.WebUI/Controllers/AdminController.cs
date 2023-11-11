using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.Views.Shared;

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

			// ViewData is lost after redirecting to another action
			// TempData is preserved between actions
			var alert = new AlertMessage($"{product.Name} product is created", "success");
			TempData["message"] = JsonConvert.SerializeObject(alert);

			return RedirectToAction("ProductList");
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = _productService.GetById((int)id);

			if (product == null)
			{
				return NotFound();
			}

			var productModel = new ProductModel()
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Description = product.Description,
				Url = product.Url,
				ImageUrl = product.ImageUrl,
				Price = product.Price
			};
			return View(productModel);
		}

		[HttpPost]
		public IActionResult Edit(ProductModel productModel)
		{
			var product = _productService.GetById(productModel.ProductId);
			if (product == null)
			{
				return NotFound();
			}

			product.Name = productModel.Name;
			product.Description = productModel.Description;
			product.Url = productModel.Url;
			product.ImageUrl = productModel.ImageUrl;
			product.Price = productModel.Price;

			_productService.Update(product);

			var alert = new AlertMessage($"{product.Name} product is updated", "success");
			TempData["message"] = JsonConvert.SerializeObject(alert);

			return RedirectToAction("ProductList");
		}

		public IActionResult Delete(int id)
		{
			var product = _productService.GetById(id);
			if (product == null)
			{
				return NotFound();
			}
			_productService.Delete(product);

			var alert = new AlertMessage($"{product.Name} product is deleted", "danger");
			TempData["message"] = JsonConvert.SerializeObject(alert);


			return RedirectToAction("ProductList");
		}
	}
}

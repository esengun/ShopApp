using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.ViewModels;

namespace ShopApp.WebUI.Controllers
{
	public class ShopController: Controller
	{
		private IProductService _productService;

		public ShopController(IProductService productService)
		{
			this._productService = productService;
		}

		public IActionResult List()
		{
			var productViewModel = new ProductListViewModel()
			{
				Products = _productService.GetAll()
			};

			return View(productViewModel);
		}

		public IActionResult Details(int? Id)
		{
			if(Id == null)
			{
				return NotFound();
			}

			var product = _productService.GetById((int)Id);
			if(product == null)
			{
				return NotFound();
			}
			return View(product);
		}

	}
}

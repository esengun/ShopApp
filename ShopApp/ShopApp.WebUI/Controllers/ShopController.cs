﻿using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
	public class ShopController: Controller
	{
		private IProductService _productService;

		public ShopController(IProductService productService)
		{
			this._productService = productService;
		}

		// localhost/products/category?page=1
		public IActionResult List(string category, int page = 1)
		{
			const int pageSize = 2;
			var productViewModel = new ProductListViewModel()
			{
				Products = _productService.GetProductsByCategory(category, page, pageSize)
			};

			return View(productViewModel);
		}

		public IActionResult Details(string url)
		{
			if(url == null)
			{
				return NotFound();
			}

			var product = _productService.GetProductDetails(url);
			if(product == null)
			{
				return NotFound();
			}
			return View(new ProductDetailModel()
			{
				Product = product,
				Categories = product.ProductCategories.Select(i=>i.Category).ToList()
			});
		}

	}
}

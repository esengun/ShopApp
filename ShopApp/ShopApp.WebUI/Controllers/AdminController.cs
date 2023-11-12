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
		private ICategoryService _categoryService;

		public AdminController(IProductService productService, ICategoryService categoryService)
		{
			this._productService = productService;
			_categoryService = categoryService;
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
		public IActionResult EditProduct(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			
			var product = _productService.GetByIdWithCategories((int)id);

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
				Price = product.Price,
				SelectedCategories = product.ProductCategories.Select(p => p.Category).ToList()
			};

			ViewBag.Categories = _categoryService.GetAll();

			return View(productModel);
		}

		[HttpPost]
		public IActionResult EditProduct(ProductModel productModel, int[] categoryIds)
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

			_productService.Update(product, categoryIds);

			var alert = new AlertMessage($"{product.Name} product is updated", "success");
			TempData["message"] = JsonConvert.SerializeObject(alert);

			return RedirectToAction("ProductList");
		}

		public IActionResult DeleteProduct(int id)
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

		public IActionResult CategoryList()
		{
			return View(new CategoryListViewModel()
			{
				Categories = _categoryService.GetAll()
			});
		}

		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateCategory(CategoryModel categoryModel)
		{
			var category = new Category
			{
				Name = categoryModel.Name,
				Url = categoryModel.Url
			};
			_categoryService.Create(category);

			// ViewData is lost after redirecting to another action
			// TempData is preserved between actions
			var alert = new AlertMessage($"{category.Name} category is created", "success");
			TempData["message"] = JsonConvert.SerializeObject(alert);

			return RedirectToAction("CategoryList");
		}

		[HttpGet]
		public IActionResult EditCategory(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = _categoryService.GetByIdWithProducts((int)id);

			if (category == null)
			{
				return NotFound();
			}

			var categoryModel = new CategoryModel()
			{
				CategoryId = category.CategoryId,
				Name = category.Name,
				Url = category.Url,
				Products = category.ProductCategories.Select(p=>p.Product).ToList()
			};
			return View(categoryModel);
		}

		[HttpPost]
		public IActionResult EditCategory(CategoryModel categoryModel)
		{
			var category = _categoryService.GetById(categoryModel.CategoryId);
			if (category == null)
			{
				return NotFound();
			}

			category.Name = categoryModel.Name;
			category.Url = categoryModel.Url;

			_categoryService.Update(category);

			var alert = new AlertMessage($"{category.Name} category is updated", "success");
			TempData["message"] = JsonConvert.SerializeObject(alert);

			return RedirectToAction("CategoryList");
		}

		public IActionResult DeleteCategory(int id)
		{
			var category = _categoryService.GetById(id);
			if (category == null)
			{
				return NotFound();
			}
			_categoryService.Delete(category);

			var alert = new AlertMessage($"{category.Name} category is deleted", "danger");
			TempData["message"] = JsonConvert.SerializeObject(alert);


			return RedirectToAction("CategoryList");
		}

		[HttpPost]
		public IActionResult DeleteProductFromCategory(int productId, int categoryId)
		{
			_categoryService.DeleteProductFromCategory(productId, categoryId);
			return Redirect("/admin/categories/"+categoryId);
		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.Views.Shared;

namespace ShopApp.WebUI.Controllers
{
	[Authorize] // To use admin controllers, user has to have privilege
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
			if (ModelState.IsValid) // Checks if the validations for each field in ProductModel are valid
			{
				var product = new Product
				{
					Name = productModel.Name,
					Description = productModel.Description,
					Price = productModel.Price,
					Url = productModel.Url,
					ImageUrl = productModel.ImageUrl
				};
				if (_productService.Create(product))
				{
					CreateMessage($"{product.Name} product is created", "success");
					
					return RedirectToAction("ProductList");
				}
				CreateMessage(_productService.ErrorMessage, "danger");
				return View(productModel);
			}
			return View(productModel);
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
				IsApproved = product.IsApproved,
				IsHome = product.IsHome,
				SelectedCategories = product.ProductCategories.Select(p => p.Category).ToList()
			};

			ViewBag.Categories = _categoryService.GetAll();

			return View(productModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditProduct(ProductModel productModel, int[] categoryIds, IFormFile file)
		{
			if (ModelState.IsValid)
			{
				var product = _productService.GetById(productModel.ProductId);
				if (product == null)
				{
					return NotFound();
				}

				product.Name = productModel.Name;
				product.Description = productModel.Description;
				product.Url = productModel.Url;
				product.Price = productModel.Price;
				product.IsApproved = productModel.IsApproved;
				product.IsHome = productModel.IsHome;

				if(file != null)
				{
					var extension = Path.GetExtension(file.FileName);
					var randomName = string.Format($"{Guid.NewGuid()}{extension}");
					product.ImageUrl = randomName;
					var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images", randomName);
					using(var stream  = new FileStream(path, FileMode.Create))
					{
						await file.CopyToAsync(stream);
					}
				}

				if(_productService.Update(product, categoryIds))
				{
					CreateMessage($"{product.Name} product is updated", "success");
					return RedirectToAction("ProductList");
				}
				CreateMessage(_productService.ErrorMessage, "danger");
			}
			ViewBag.Categories = _categoryService.GetAll();
			return View(productModel);
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
			if (ModelState.IsValid)
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
			return View(categoryModel);
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
			if (ModelState.IsValid)
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
			return View(categoryModel);
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
		private void CreateMessage(string message, string alertType)
		{
			// ViewData is lost after redirecting to another action
			// TempData is preserved between actions
			var alert = new AlertMessage(message, alertType);
			TempData["message"] = JsonConvert.SerializeObject(alert);
		}
	}
}

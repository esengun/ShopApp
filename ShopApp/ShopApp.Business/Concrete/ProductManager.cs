using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concrete.EFCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
	public class ProductManager : IProductService
	{
		private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
			_productRepository = productRepository;
        }

		public bool Create(Product entity)
		{
			// Apply business rules
			if (Validation(entity))
			{
				_productRepository.Create(entity);
				return true;
			}
			return false;
		}

		public void Delete(Product entity)
		{
			// Apply business rules
			_productRepository.Delete(entity);
		}

		public List<Product> GetAll()
		{
			return _productRepository.GetAll();
		}

		public Product GetById(int id)
		{
			return _productRepository.GetById(id);
		}

		public Product GetByIdWithCategories(int productId)
		{
			return _productRepository.GetByIdWithCategories(productId);
		}

		public int GetCountByCategory(string category)
		{
			return _productRepository.GetCountByCategory(category);
		}

		public List<Product> GetHomeProducts()
		{
			return _productRepository.GetHomeProducts();
		}

		public Product GetProductDetails(string url)
		{
			return _productRepository.GetProductDetails(url);
		}

		public List<Product> GetProductsByCategory(string category, int page, int pageSize)
		{
			return _productRepository.GetProductsByCategory(category, page, pageSize);
		}

		public List<Product> GetSearchResult(string searchString)
		{
			return _productRepository.GetSearchResult(searchString);
		}

		public void Update(Product entity)
		{
			_productRepository.Update(entity);
		}

		public bool Update(Product product, int[] categoryIds)
		{
			if (Validation(product))
			{
				if(categoryIds.Length == 0)
				{
					ErrorMessage += "At least one category must be choosen for the product!";
					return false;
				}
				_productRepository.Update(product, categoryIds);
				return true;
			}
			return false;
		}

		public string ErrorMessage { get; set; }


		public bool Validation(Product entity)
		{
			var isValid = true;

			if (string.IsNullOrEmpty(entity.Name))
			{
				ErrorMessage += "Product Name can not be empty!\n";
				isValid = false;
			}

			if (entity.Name.Length <= 3 || entity.Name.Length > 60)
			{
				ErrorMessage += "Product Name length must be between 3-60!\n";
				isValid = false;
			}

			if (entity.Price < 0)
			{
				ErrorMessage += "Product Price can not be negative!\n";
				isValid = false;
			}

			return isValid;
		}
	}
}

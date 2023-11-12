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

        public void Create(Product entity)
		{
			// Apply business rules
			_productRepository.Create(entity);
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

		public void Update(Product product, int[] categoryIds)
		{
			_productRepository.Update(product, categoryIds);
		}
	}
}

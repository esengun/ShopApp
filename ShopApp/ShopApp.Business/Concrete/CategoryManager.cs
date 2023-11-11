using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private ICategoryRepository _categoryRepository;

		public CategoryManager(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public void Create(Category entity)
		{
			// Apply business rules
			_categoryRepository.Create(entity);
		}

		public void Delete(Category entity)
		{
			// Apply business rules
			_categoryRepository.Delete(entity);
		}

		public void DeleteProductFromCategory(int productId, int categoryId)
		{
			_categoryRepository.DeleteProductFromCategory(productId, categoryId);
		}

		public List<Category> GetAll()
		{
			return _categoryRepository.GetAll();
		}

		public Category GetById(int id)
		{
			return _categoryRepository.GetById(id);
		}

		public Category GetByIdWithProducts(int categoryId)
		{
			return _categoryRepository.GetByIdWithProducts(categoryId);
		}

		public void Update(Category entity)
		{
			_categoryRepository.Update(entity);
		}
	}
}

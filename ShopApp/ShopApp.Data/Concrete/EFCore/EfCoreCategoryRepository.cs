using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EFCore
{
	public class EfCoreCategoryRepository : ICategoryRepository
	{
		private ShopContext db = new ShopContext();

		public void Create(Category entity)
		{
			db.Categories.Add(entity);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<Category> GetAll()
		{
			throw new NotImplementedException();
		}

		public Category GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetPopularCategories()
		{
			throw new NotImplementedException();
		}

		public void Update(Category entity)
		{
			throw new NotImplementedException();
		}
	}
}

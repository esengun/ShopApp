using Azure;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EFCore
{
	public class EfCoreCategoryRepository : EFCoreRepository<Category, ShopContext>, ICategoryRepository
	{
		public Category GetByIdWithProducts(int categoryId)
		{
			using (var context = new ShopContext())
			{						
				return context.Categories
					.Where(i => i.CategoryId == categoryId)
					.Include(i => i.ProductCategories)
					.ThenInclude(p => p.Product)
					.FirstOrDefault();
			}
		}

		public List<Product> GetPopularCategories()
		{
			throw new NotImplementedException();
		}
	}
}

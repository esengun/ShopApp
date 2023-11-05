using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EFCore
{
	internal class EFCoreCategoryRepository : EFCoreRepository<Category, ShopContext>, ICategoryRepository
	{
		public List<Product> GetPopularCategories()
		{
			throw new NotImplementedException();
		}
	}
}

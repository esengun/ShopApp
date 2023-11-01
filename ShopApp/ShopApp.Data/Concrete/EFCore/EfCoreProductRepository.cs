using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EFCore
{
	public class EfCoreProductRepository : EFCoreRepository<Product, ShopContext>, IProductRepository
	{
		public List<Product> GetPopularProducts()
		{
			using(var context = new ShopContext())
			{
				return context.Products.ToList();
			}
		}

		public List<Product> Gettop5Products()
		{
			throw new NotImplementedException();
		}
	}
}

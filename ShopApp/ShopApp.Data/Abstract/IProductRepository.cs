using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
	public interface IProductRepository : IRepository<Product>
	{
		Product GetProductDetails(string url);
		List<Product> GetProductsByCategory(string category, int page, int pageSize);
		int GetCountByCategory(string category);
		List<Product> GetHomeProducts();
		List<Product> GetSearchResult(string searchString);
		Product GetByIdWithCategories(int productId);
	}
}

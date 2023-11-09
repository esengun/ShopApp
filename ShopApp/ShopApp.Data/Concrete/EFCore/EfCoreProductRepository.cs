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
	public class EfCoreProductRepository : EFCoreRepository<Product, ShopContext>, IProductRepository
	{
		public int GetCountByCategory(string category)
		{
			using (var context = new ShopContext())
			{
				var products = context.Products.AsQueryable();

				if (!string.IsNullOrEmpty(category))
				{
					products = products
						.Include(i => i.ProductCategories)
						.ThenInclude(c => c.Category)
						.Where(i => i.ProductCategories.Any(a => a.Category.Url == category));
				}
				return products.Count();
			}
		}

		public List<Product> GetPopularProducts()
		{
			using (var context = new ShopContext())
			{
				return context.Products.ToList();
			}
		}

		public Product GetProductDetails(string url)
		{
			using (var context = new ShopContext())
			{
				return context.Products
					.Where(p => p.Url == url) // Left join
					.Include(p => p.ProductCategories)
					.ThenInclude(c => c.Category)
					.FirstOrDefault();
			}
		}

		public List<Product> GetProductsByCategory(string categoryUrl, int page, int pageSize)
		{
			using (var context = new ShopContext())
			{
				var products = context.Products.AsQueryable();

				if(!string.IsNullOrEmpty(categoryUrl))
				{
					products = products
						.Include(i => i.ProductCategories)
						.ThenInclude(c => c.Category)
						.Where(i => i.ProductCategories.Any(a => a.Category.Url == categoryUrl));
				}
				return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
			}
		}

		public List<Product> Gettop5Products()
		{
			throw new NotImplementedException();
		}
	}
}

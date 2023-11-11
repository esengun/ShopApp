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
				var products = context.Products
					.Where(i => i.IsApproved)
					.AsQueryable();

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

		public List<Product> GetSearchResult(string searchString)
		{
			using (var context = new ShopContext())
			{
				var products = context
					.Products
					.Where(p => p.IsApproved && (p.Name.ToLower().Contains(searchString.ToLower()) || p.Description.ToLower().Contains(searchString.ToLower())))
					.AsQueryable();


				return products.ToList();
			}
		}

		public List<Product> GetHomeProducts()
		{
			using (var context = new ShopContext())
			{
				return context.Products
					.Where(p => p.IsHome && p.IsApproved)
					.ToList();
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
				var products = context
					.Products
					.Where(i => i.IsApproved)
					.AsQueryable();

				if (!string.IsNullOrEmpty(categoryUrl))
				{
					products = products
						.Include(i => i.ProductCategories)
						.ThenInclude(c => c.Category)
						.Where(i => i.ProductCategories.Any(a => a.Category.Url == categoryUrl));
				}
				return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
			}
		}

		public Product GetByIdWithCategories(int productId)
		{
			using (var context = new ShopContext())
			{
				return context.Products
					.Where(i => i.ProductId == productId)
					.Include(i => i.ProductCategories)
					.ThenInclude(c => c.Category)
					.FirstOrDefault();
			}
		}
	}
}

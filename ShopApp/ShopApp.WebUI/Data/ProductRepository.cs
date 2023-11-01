using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Data
{
	public static class ProductRepository // this class is for test purposes and serve as a db
	{
		private static List<Product> _products = null;

		public static List<Product> Products
		{
			get
			{
				return _products;
			}
		}

		static ProductRepository()
		{
			_products = new List<Product>
			{
				new Product { ProductId = 1, Name = "samsung s6", Price = 2000, Description = "Android", ImageUrl = "1.png", CategoryId = 1 },
				new Product { ProductId = 2, Name = "samsung s7", Price = 3000, Description = "Android", IsApproved = true, ImageUrl = "2.png", CategoryId = 1 },
				new Product { ProductId = 3, Name = "Lenovo", Price = 4000, Description = "Android", IsApproved = true, ImageUrl = "3.png", CategoryId = 2  },
				new Product { ProductId = 4, Name = "Ardunio", Price = 5000, Description = "Android", ImageUrl = "4.png", CategoryId = 3}
			};
		}

		public static void AddProduct(Product product)
		{
			_products.Add(product);
		}

		public static Product GetProductById(int id)
		{
			return _products.FirstOrDefault(p => p.ProductId == id);
		}
	}
}

using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EFCore
{
	public static class SeedDatabase
	{
		public static void Seed()
		{
			var context = new ShopContext();

			if (context.Database.GetPendingMigrations().Count() == 0)
			{
				if (context.Categories.Count() == 0)
				{
					context.Categories.AddRange(Categories);
				}

				if (context.Products.Count() == 0)
				{
					context.Products.AddRange(Products);
					context.AddRange(ProductCategories);
				}
			}
			context.SaveChanges();
		}

		private static Category[] Categories =
		{
			new Category(){ Name="Smartphone", Url="smartphone"},
			new Category(){ Name="Computer", Url="computer"},
			new Category(){ Name="Electronic", Url="electronic"}
		};

		private static Product[] Products =
		{
			new Product(){ Name="Samsung S5", Url="samsung-s5", Price=2000, Description="Android smartphone", ImageUrl="3.png", IsApproved=true},
			new Product(){ Name="Samsung S20", Url="samsung-s20", Price=8000, Description="Android smartphone", ImageUrl="4.png", IsApproved=true},
			new Product(){ Name="Samsung S10", Url="samsung-s10", Price=9000, Description="Android smartphone", ImageUrl="4.png", IsApproved=true},
			new Product(){ Name="Samsung S20 Plus", Url="samsung-s20-plus", Price=9500, Description="Android smartphone", ImageUrl="4.png", IsApproved=true},
			new Product(){ Name="Iphone 13 mini", Url="iphone-13-mini", Price=7000, Description="IOS smartphone", ImageUrl="5.png", IsApproved=false},
			new Product(){ Name="Iphone X", Url="iphone-x", Price=10000, Description="IOS smartphone", ImageUrl="6.png", IsApproved=false},
			new Product(){ Name="Lenovo", Url="lenovo", Price=11000, Description="Windows computer", ImageUrl="3.png", IsApproved=true},
			new Product(){ Name="Asus", Url="asus", Price=12000, Description="Windows computer", ImageUrl="4.png", IsApproved=true},
			new Product(){ Name="Mac book pro", Url="mac-book-pro", Price=9000, Description="IOS computer", ImageUrl="4.png", IsApproved=false},
			new Product(){ Name="Ardunio", Url="ardunio", Price=500, Description="Ardunio Kit", ImageUrl="6.png", IsApproved=false}
		};

		private static ProductCategory[] ProductCategories =
		{
			new ProductCategory(){ Category=Categories[0], Product=Products[0] },
			new ProductCategory(){ Category=Categories[0], Product=Products[1] },
			new ProductCategory(){ Category=Categories[0], Product=Products[2] },
			new ProductCategory(){ Category=Categories[0], Product=Products[3] },
			new ProductCategory(){ Category=Categories[0], Product=Products[4] },
			new ProductCategory(){ Category=Categories[0], Product=Products[5] },
			new ProductCategory(){ Category=Categories[1], Product=Products[6] },
			new ProductCategory(){ Category=Categories[1], Product=Products[7] },
			new ProductCategory(){ Category=Categories[1], Product=Products[8] },
			new ProductCategory(){ Category=Categories[2], Product=Products[9] }
		};
	}
}

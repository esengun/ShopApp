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
				}
			}
			context.SaveChanges();
		}

		private static Category[] Categories =
		{
			new Category(){ Name="Smartphone"},
			new Category(){ Name="Computer"},
			new Category(){ Name="Electronic"}
		};

		private static Product[] Products =
		{
			new Product(){ Name="Samsung S5", Price=2000, Description="Android smartphone", ImageUrl="3.png", IsApproved=true},
			new Product(){ Name="Samsung S20", Price=8000, Description="Android smartphone", ImageUrl="4.png", IsApproved=true},
			new Product(){ Name="Samsung S10", Price=9000, Description="Android smartphone", ImageUrl="4.png", IsApproved=true},
			new Product(){ Name="Samsung S20 Plus", Price=9500, Description="Android smartphone", ImageUrl="4.png", IsApproved=true},
			new Product(){ Name="Iphone 13 mini", Price=7000, Description="IOS smartphone", ImageUrl="5.png", IsApproved=false},
			new Product(){ Name="Iphone X", Price=10000, Description="IOS smartphone", ImageUrl="6.png", IsApproved=false},
			new Product(){ Name="Lenovo", Price=11000, Description="Windows computer", ImageUrl="3.png", IsApproved=true},
			new Product(){ Name="Asus", Price=12000, Description="Windows computer", ImageUrl="4.png", IsApproved=true},
			new Product(){ Name="Mac book pro", Price=9000, Description="IOS computer", ImageUrl="4.png", IsApproved=false}
		};
	}
}

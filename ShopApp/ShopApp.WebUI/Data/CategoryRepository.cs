using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Data
{
	public class CategoryRepository
	{
		private static List<Category> _categories = null;

		public static List<Category> Categories
		{
			get
			{
				return _categories;
			}
		}

		static CategoryRepository()
		{
			_categories = new List<Category>
			{
				new Category { CategoryId = 1, Name = "Smartphone", Description = "Android smartphones" },
				new Category { CategoryId = 2, Name = "Computer", Description = "Computers" },
				new Category { CategoryId = 3, Name = "Electronic", Description = "Electronics" }
			};
		}

		public static void AddCategory (Category category)
		{
			_categories.Add(category);
		}

		public static Category GetCategoryById(int id)
		{
			return _categories.FirstOrDefault(c => c.CategoryId == id);
		}
	}
}

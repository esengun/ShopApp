using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.ViewComponents
{
	public class CategoriesViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var categories = new List<Category>(){
				new Category { Name = "Smartphone", Description = "Android smartphones" },
				new Category { Name = "Computer", Description = "Computers" },
				new Category { Name = "Electronic", Description = "Electronics" }
			};

			return View(categories);
		}
	}
}

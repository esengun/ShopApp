using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Data;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.ViewComponents
{
	public class CategoriesViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(CategoryRepository.Categories);
		}
	}
}

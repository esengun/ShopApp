using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Data;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.ViewComponents
{
	public class CategoriesViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			if (RouteData.Values["action"].ToString().Equals("List"))
			{
				ViewBag.SelectedCategory = RouteData?.Values["id"];
			}
			
			return View(CategoryRepository.Categories);
		}
	}
}

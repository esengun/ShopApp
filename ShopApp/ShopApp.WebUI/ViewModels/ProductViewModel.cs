using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.ViewModels
{
	public class ProductViewModel
	{
		public Category Category { get; set; }
		public List<Product> Products { get; set; }
	}
}

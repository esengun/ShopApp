using ShopApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
	// Product view model to be used in pages
	public class ProductModel
	{
		public int ProductId { get; set; }
		[Display(Name = "Name", Prompt ="Enter product name")]
		public string Name { get; set; }
		public string Url { get; set; }
		public double? Price { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public bool IsApproved { get; set; }
		public bool IsHome { get; set; }
		public List<Category> SelectedCategories{ get; set; }
	}
}

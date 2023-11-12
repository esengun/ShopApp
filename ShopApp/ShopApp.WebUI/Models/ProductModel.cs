using ShopApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
	// Product view model to be used in pages
	public class ProductModel
	{
		public int ProductId { get; set; }
		
		[Display(Name = "Name", Prompt = "Enter product name")]
		[Required(ErrorMessage = "Name can not be empty!")]
		[StringLength(60, MinimumLength = 5,ErrorMessage ="Product name should be between 5-60 characters!")]
		public string Name { get; set; }
		
		[Required(ErrorMessage = "Url can not be empty!")]
		public string Url { get; set; }
		
		[Required(ErrorMessage = "Price can not be empty!")]
		[Range(1,10000, ErrorMessage ="Price must be between 1-10000!")]
		public double? Price { get; set; }
		
		[Required(ErrorMessage = "Description can not be empty!")]
		[StringLength(100, MinimumLength = 5,ErrorMessage ="Description should be between 5-100 characters!")]
		public string Description { get; set; }
		
		[Required(ErrorMessage = "ImageUrl can not be empty!")]
		public string ImageUrl { get; set; }
		public bool IsApproved { get; set; }
		public bool IsHome { get; set; }
		public List<Category>? SelectedCategories { get; set; }
    }
}

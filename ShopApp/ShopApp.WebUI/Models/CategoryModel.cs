using ShopApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
	public class CategoryModel
	{
		public int CategoryId { get; set; }

		[Display(Name = "Name", Prompt = "Enter category name")]
		[Required(ErrorMessage = "Name can not be empty!")]
		[StringLength(60, MinimumLength = 5, ErrorMessage = "Category name should be between 5-60 characters!")]
		public string Name { get; set; }


		[Required(ErrorMessage = "Url can not be empty!")] 
		public string Url { get; set; }
        public List<Product>? Products { get; set; }
    }
}

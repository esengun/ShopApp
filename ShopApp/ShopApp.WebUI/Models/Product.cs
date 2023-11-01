using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
	public class Product
	{
        public int ProductId { get; set; }

		[Required]
		[StringLength(60, MinimumLength = 10, ErrorMessage = "Product name must include 10-60 characters")]
        public string Name { get; set; }

		[Required(ErrorMessage = "Price must be provided.")]
		[Range(1,10000)]
		public double? Price { get; set; }
		public string Description { get; set; }

		[Required]
		public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }

		[Required]
		public int? CategoryId { get; set; }

	}
}

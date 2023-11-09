using ShopApp.Entity;

namespace ShopApp.WebUI.Models
{
    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}

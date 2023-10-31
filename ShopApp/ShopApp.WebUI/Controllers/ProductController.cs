using Microsoft.AspNetCore.Mvc;

namespace ShopApp.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public string Index()
        {
            return "product/index";
        }

        // localhost:5000/product/list
        public string List()
        {
            return "product/list";
        }

        // localhost:5000/product/details/id?
        public string Details(int id)
        {
            return "product/details/"+id;
        }
    }
}

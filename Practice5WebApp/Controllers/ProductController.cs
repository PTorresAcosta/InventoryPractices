using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness;
using Practice5Model.Models;

namespace Practice5WebApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductBLL _productBLL;
        public ProductController(IProductBLL productBLL)
        {
            _productBLL = productBLL;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = new List<Product>();
            try
            {
                products = _productBLL.GetProducts().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in controller: " + ex.Message);
            }
            return View(products);
        }
    }
}

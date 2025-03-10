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

        //[HttpGet]
        //public IActionResult ProductInsert()
        //{
            
        //    return View();
        //}

        [HttpGet]
        public IActionResult ProductInsert(int? id)
        {

            Product product = new();
            try
            {
                if (id == null || id == 0)
                {
                    return View(product);
                }else
                {
                    product = _productBLL.GetProducts().FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in controller: " + ex.Message);
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductInsert(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    //create
                    _productBLL.AddProduct(product);
                }
                else
                {
                    //update
                    _productBLL.UpdateProduct(product);
                }
                return RedirectToAction(nameof(ProductList));
            }
            return View(product);
        }

        
        public IActionResult Delete(int id)
        {
            Product product = new();
            product = _productBLL.GetProducts().FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                NotFound();
            }
            _productBLL.DeleteProduct(product);
            return RedirectToAction(nameof(ProductList));
        }
    }
}

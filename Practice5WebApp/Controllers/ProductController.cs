using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness;
using Practice5Model.Models;
using Practice5WebApp.Data;

namespace Practice5WebApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductBLL _productBLL;
        private readonly IWebApiExecuter _webApiExecuter;
        public ProductController(IProductBLL productBLL, IWebApiExecuter webApiExecuter)
        {
            _productBLL = productBLL;
            _webApiExecuter = webApiExecuter;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            //var products = new List<Product>();
            //try
            //{
            //    products = _productBLL.GetProducts().ToList();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error in controller: " + ex.Message);
            //}
            //return View(products);

            return View(await _webApiExecuter.InvokeGet<List<Product>>("Product"));

        }

        //[HttpGet]
        //public IActionResult ProductInsert()
        //{

        //    return View();
        //}

        //[HttpGet]
        //public IActionResult ProductInsert(int? id)
        //{

        //    Product product = new();
        //    try
        //    {
        //        if (id == null || id == 0)
        //        {
        //            return View(product);
        //        }else
        //        {
        //            product = _productBLL.GetProducts().FirstOrDefault(p => p.ProductId == id);
        //            if (product == null)
        //            {
        //                NotFound();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error in controller: " + ex.Message);
        //    }

        //    return View(product);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ProductInsert(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (product.ProductId == 0)
        //        {
        //            //create
        //            _productBLL.AddProduct(product);
        //        }
        //        else
        //        {
        //            //update
        //            _productBLL.UpdateProduct(product);
        //        }
        //        return RedirectToAction(nameof(ProductList));
        //    }
        //    return View(product);
        //}

        public IActionResult ProductInsert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductInsert(Product product)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var response = await _webApiExecuter.InvokePost("Product", product);
                    if (response != null)
                    {
                        return RedirectToAction(nameof(ProductList));
                    }
                }
                catch (WebApiException ex)
                {
                    HandleWebApiException(ex);
                }


            }

            return View(product);
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {

            try
            {
                var product = await _webApiExecuter.InvokeGet<Product>($"Product/{id}");
                if (product != null)
                {
                    return View(product);
                }

            }
            catch (WebApiException ex)
            {
                HandleWebApiException(ex);
                return View();
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _webApiExecuter.InvokePut($"Product/{product.ProductId}", product);
                    return RedirectToAction(nameof(ProductList));
                }
            }
            catch (WebApiException ex)
            {
                HandleWebApiException(ex);
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _webApiExecuter.InvokeDelete($"Product/{id}");
                return RedirectToAction(nameof(ProductList));
            }
            catch (WebApiException ex)
            {
                HandleWebApiException(ex);
                return View(nameof(ProductList),
                    await _webApiExecuter.InvokeGet<List<Product>>("Product"));
            }
        }

        private void HandleWebApiException(WebApiException ex)
        {
            if (ex.ErrorResponse != null &&
                        ex.ErrorResponse.Errors != null &&
                        ex.ErrorResponse.Errors.Count > 0)
            {
                foreach (var error in ex.ErrorResponse.Errors)
                    ModelState.AddModelError(error.Key, string.Join("; ", error.Value));
            }
        }

    }
}

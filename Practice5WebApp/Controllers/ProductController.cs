using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness;
using Practice5Model.Models;
using Practice5WebApp.Data;

namespace Practice5WebApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly IWebApiExecuter _webApiExecuter;
        public ProductController(IProductBLL productBLL, IWebApiExecuter webApiExecuter)
        {
            _webApiExecuter = webApiExecuter;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {

            return View(await _webApiExecuter.InvokeGet<List<Product>>("Product"));

        }

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
        [ValidateAntiForgeryToken]
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

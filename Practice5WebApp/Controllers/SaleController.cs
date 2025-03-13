using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practice5Model.DTO;
using Practice5Model.Models;
using Practice5WebApp.Data;

namespace Practice5WebApp.Controllers
{
    public class SaleController : Controller
    {
        private readonly IWebApiExecuter _webApiExecuter;

        public SaleController(IWebApiExecuter webApiExecuter)
        {
            _webApiExecuter = webApiExecuter;
        }

        public async Task<IActionResult> SaleList()
        {
            return View(await _webApiExecuter.InvokeGet<List<SaleProductDTO>>("SaleProduct"));
        }

        [HttpGet]
        public async Task<IActionResult> SaleInsert()
        {
            var products = await _webApiExecuter.InvokeGet<List<Product>>($"Product/sell");
            ViewData["products"] = new SelectList(products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaleInsert(Sale sale)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _webApiExecuter.InvokePost("Sale", sale);
                    if (response != null)
                    {
                        return RedirectToAction(nameof(SaleList));
                    }
                }
                catch (WebApiException ex)
                {
                    HandleWebApiException(ex);
                }
            }
            return View(sale);

        }

        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _webApiExecuter.InvokeDelete($"Sale/{id}");
                return RedirectToAction(nameof(SaleList));
            }
            catch (WebApiException ex)
            {
                HandleWebApiException(ex);
                return View(nameof(SaleList),
                    await _webApiExecuter.InvokeGet<List<Purchase>>("Sale"));
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

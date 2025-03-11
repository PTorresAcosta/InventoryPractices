using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practice5Bussiness;
using Practice5DataAccess;
using Practice5Model.DTO;
using Practice5Model.Models;
using Practice5WebApp.Data;

namespace Practice5WebApp.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly IPurchaseBLL _purchaseBLL;
        private readonly IPurchaseProductBLL _purchaseProductBLL;
        private readonly IWebApiExecuter _webApiExecuter;

        public PurchaseController(IPurchaseBLL purchaseBLL, IPurchaseProductBLL purchaseProductBLL, IWebApiExecuter webApiExecuter)
        {
            _purchaseBLL = purchaseBLL;
            _purchaseProductBLL = purchaseProductBLL;
            _webApiExecuter = webApiExecuter;
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseList()
        {

            return View(await _webApiExecuter.InvokeGet<List<PurchaseProductDTO>>("PurchaseProduct"));

        }

        [HttpGet]
        public async Task<IActionResult> PurchaseInsert()
        {
            var products = await _webApiExecuter.InvokeGet<List<Product>>($"Product");
            ViewData["products"] = new SelectList(products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PurchaseInsert(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _webApiExecuter.InvokePost("Purchase", purchase);
                    if (response != null)
                    {
                        return RedirectToAction(nameof(PurchaseList));
                    }
                }
                catch (WebApiException ex)
                {
                    HandleWebApiException(ex);
                }
            }
            return View(purchase);

        }

        public async Task<IActionResult> UpdatePurchase(int? id)
        {

            try
            {
                var purchase = await _webApiExecuter.InvokeGet<Purchase>($"Purchase/{id}");
                var products = await _webApiExecuter.InvokeGet<List<Product>>($"Product");
                if (purchase != null && products != null)
                {
                    ViewData["products"] = new SelectList(products, "ProductId", "Name");
                    return View(purchase);
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
        public async Task<IActionResult> UpdatePurchase(Purchase purchase)
        {

            try
            {
                await _webApiExecuter.InvokePut($"Purchase/{purchase.PurchaseId}", purchase);
                return RedirectToAction(nameof(PurchaseList));
            }
            catch (WebApiException ex)
            {
                HandleWebApiException(ex);
            }

            return View(purchase);
        }

        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _webApiExecuter.InvokeDelete($"Purchase/{id}");
                return RedirectToAction(nameof(PurchaseList));
            }
            catch (WebApiException ex)
            {
                HandleWebApiException(ex);
                return View(nameof(PurchaseList),
                    await _webApiExecuter.InvokeGet<List<Purchase>>("Purchase"));
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

using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness;
using Practice5DataAccess;
using Practice5Model.DTO;
using Practice5Model.Models;

namespace Practice5WebApp.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly IPurchaseBLL _purchaseBLL;
        private readonly IPurchaseProductBLL _purchaseProductBLL;

        public PurchaseController(IPurchaseBLL purchaseBLL, IPurchaseProductBLL purchaseProductBLL)
        {
            _purchaseBLL = purchaseBLL;
            _purchaseProductBLL = purchaseProductBLL;
        }

        [HttpGet]
        public IActionResult PurchaseList()
        {
            var purchases = new List<PurchaseProductDTO>();

            try
            {
                purchases = _purchaseProductBLL.getPurchaseProduct().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in controller: " + ex.Message);
            }

            return View(purchases);
        }

        [HttpGet]
        public IActionResult PurchaseInsert(int? id)
        {
            Purchase purchase = new();

            try
            {
                if (id == null || id == 0)
                {
                    return View(purchase);
                }
                else
                {
                    purchase = _purchaseBLL.GetPurchases().FirstOrDefault(p => p.PurchaseId == id);
                    if (purchase == null)
                    {
                        NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in controller: " + ex.Message);
            }

            return View(purchase);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PurchaseInsert(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                if (purchase.PurchaseId == 0)
                {
                    //create
                    _purchaseBLL.AddPurchase(purchase);
                }
                else
                {
                    //update
                    _purchaseBLL.UpdatePurchase(purchase);
                }
                return RedirectToAction(nameof(PurchaseList));
            }
            return View(purchase);
        }

        public IActionResult Delete(int id)
        {
            Purchase purchase = new();
            purchase = _purchaseBLL.GetPurchases().FirstOrDefault(p => p.PurchaseId == id);
            if (purchase == null)
            {
                NotFound();
            }
            _purchaseBLL.DeletePurchase(purchase);
            return RedirectToAction(nameof(PurchaseList));
        }

    }
}

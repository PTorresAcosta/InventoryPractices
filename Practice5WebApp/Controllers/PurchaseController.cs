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

        

    }
}

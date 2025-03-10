using Microsoft.AspNetCore.Mvc;
using Practice5DataAccess;
using Practice5Model.Models;
using Practice7WebAPI.Filters.ProductFilters.ActionFilters;
using Practice7WebAPI.Filters.PurchaseFilters.ActionFilters;
using Practice7WebAPI.Filters.PurchaseFilters.ExcepptionFilters;

namespace Practice7WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseBLL _purchaseBLL;

        [ActivatorUtilitiesConstructor]
        public PurchaseController(IPurchaseBLL purchaseBLL)
        {
            _purchaseBLL = purchaseBLL;
        }

        [HttpGet]
        public IActionResult GetPurchases()
        {
            return Ok(_purchaseBLL.GetPurchases().ToList());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(Purchase_ValidatePurchaseIdFilterAttribute))]
        public IActionResult GetPurchasesById(int id)
        {
            return Ok(HttpContext.Items["purchase"]);
        }

        [HttpPost]
        [Purchase_ValideCreatePurchaseFilter]
        public IActionResult CreatePurchase([FromBody]Purchase purchase)
        {
            _purchaseBLL.AddPurchase(purchase);

            return CreatedAtAction(nameof(GetPurchasesById),
                new { id = purchase.PurchaseId },
                purchase);

        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(Purchase_ValidatePurchaseIdFilterAttribute))]
        [Purchase_ValidateUpdatePurchaseFilter]
        [TypeFilter(typeof(Purchase_HandleUpdateExceptionsFilterAttribute))]
        public IActionResult UpdatePurchase(int id, Purchase purchase)
        {

            _purchaseBLL.UpdatePurchase(purchase);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(Purchase_ValidatePurchaseIdFilterAttribute))]
        public IActionResult DeletePurchase(int id)
        {

            var purchaseToDelete = HttpContext.Items["purchase"] as Purchase;

            _purchaseBLL.DeletePurchase(purchaseToDelete);

            return Ok(purchaseToDelete);

        }

    }
}

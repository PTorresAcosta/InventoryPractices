using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Practice5Bussiness;

namespace Practice7WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseProductController : ControllerBase
    {
        private readonly IPurchaseProductBLL _purchaseProductBLL;
        [ActivatorUtilitiesConstructor]
        public PurchaseProductController(IPurchaseProductBLL purchaseProductBLL)
        {
            _purchaseProductBLL = purchaseProductBLL;
        }

        [HttpGet]
        public IActionResult GetPurchaseProducts()
        {

            return Ok(_purchaseProductBLL.getPurchaseProduct().ToList());

        }

    }
}

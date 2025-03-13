using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness.Interfaces;

namespace Practice7WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleProductController : ControllerBase
    {

        private readonly ISaleProductBLL _saleProductBLL;

        public SaleProductController(ISaleProductBLL saleProductBLL)
        {
            _saleProductBLL = saleProductBLL;
        }

        [HttpGet]
        public IActionResult GetSaleProducts()
        {
            return Ok(_saleProductBLL.GetSaleProducts());
        }

    }
}

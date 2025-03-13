using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness.Implementations;
using Practice5Bussiness.Interfaces;
using Practice5Model.Models;
using Practice7WebAPI.Filters.SaleFilters;

namespace Practice7WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {

        private readonly ISaleBLL _saleBLL;

        public SaleController(ISaleBLL saleBLL)
        {
            _saleBLL = saleBLL;
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(Sale_ValidateSaleIdFilterAttribute))]
        public IActionResult GetSaleById(int? id)
        {

            return Ok(HttpContext.Items["sale"]);

        }

        [HttpPost]
        [Sale_ValidateCreateSaleFilter]
        public IActionResult CreateSale([FromBody] Sale sale)
        {
            _saleBLL.AddSale(sale);

            return CreatedAtAction(nameof(GetSaleById),
                new { id = sale.SaleId },
                sale);

        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(Sale_ValidateSaleIdFilterAttribute))]
        public IActionResult DeleteSale(int? id)
        {

            var saleToDelete = HttpContext.Items["sale"] as Sale;

            _saleBLL.DeleteSale(saleToDelete);

            return Ok(saleToDelete);

        }

    }
}

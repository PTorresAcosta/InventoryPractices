using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness.Implementations;
using Practice5Bussiness.Interfaces;
using Practice7WebAPI.Filters.ProductFilters.ActionFilters;

namespace Practice7WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryBLL _inventoryBLL;

        public InventoryController(IInventoryBLL inventoryBLL)
        {
            _inventoryBLL = inventoryBLL;
        }

        [HttpGet]
        public IActionResult GetFullInventory()
        {
            return Ok(_inventoryBLL.GetFullInventory().ToList());
        }


        [HttpGet("{id}")]
        [TypeFilter(typeof(Product_ValidateProductIdFilterAttribute))]
        public IActionResult GetProductCountById(int id)
        {

            var count = _inventoryBLL.GetCountOfProduct(id);

            return Ok(count);

        }


    }
}

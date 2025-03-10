using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness;
using Practice5Model.Models;
using Practice7WebAPI.Filters;
using Practice7WebAPI.Filters.ActionFilters;
using Practice7WebAPI.Filters.ExceptionFilters;

namespace Practice7WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductBLL _productBLL;

        [ActivatorUtilitiesConstructor]
        public ProductController(IProductBLL productBLL)
        {
            _productBLL = productBLL;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productBLL.GetProducts().ToList());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(Product_ValidateProductIdFilterAttribute))]
        public IActionResult GetProductsById(int id)
        {
            return Ok(HttpContext.Items["product"]);
        }

        [HttpPost]
        [TypeFilter(typeof(Product_ValidateCreateProductFilterAttribute))]
        public IActionResult CreateProduct([FromBody]Product product)
        {
            _productBLL.AddProduct(product);

            return CreatedAtAction(nameof(GetProductsById),
                new {id = product.ProductId},
                product);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(Product_ValidateProductIdFilterAttribute))]
        [Product_ValidateUpdateProductFilter]
        [TypeFilter(typeof(Product_HandleUpdateExceptionsFilterAttribute))]
        public IActionResult UpdateProduct(int id, Product product)
        {

            _productBLL.UpdateProduct(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(Product_ValidateProductIdFilterAttribute))]
        public IActionResult DeleteProduct(int id)
        {

            var productToDelete = HttpContext.Items["product"] as Product;

            _productBLL.DeleteProduct(productToDelete);

            return Ok(productToDelete);

        }

    }
}

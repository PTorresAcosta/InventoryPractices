using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice5Bussiness.Interfaces;
using Practice5Model.Models;

namespace Practice7WebAPI.Filters.ProductFilters.ActionFilters
{
    public class Product_ValidateCreateProductFilterAttribute : ActionFilterAttribute
    {
        private readonly IProductBLL _productBLL;
        public Product_ValidateCreateProductFilterAttribute(IProductBLL productBLL)
        {
            _productBLL = productBLL;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var product = context.ActionArguments["product"] as Product;

            if (product == null)
            {
                context.ModelState.AddModelError("Product", "Product object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingProduct = _productBLL.GetProducts().FirstOrDefault(p =>
                    !string.IsNullOrWhiteSpace(product.Name) &&
                    !string.IsNullOrWhiteSpace(p.Name) &&
                    p.Name.ToLower() == product.Name.ToLower() 
                );

                if (existingProduct != null)
                {
                    context.ModelState.AddModelError("Product", "Product already exists");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }

            }

        }

    }
}

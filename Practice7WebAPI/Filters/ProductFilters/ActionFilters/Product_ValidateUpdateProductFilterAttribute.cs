using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice5Model.Models;

namespace Practice7WebAPI.Filters.ProductFilters.ActionFilters
{
    public class Product_ValidateUpdateProductFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var productId = context.ActionArguments["id"] as int?;
            var product = context.ActionArguments["product"] as Product;

            if (productId.HasValue && product != null && productId != product.ProductId)
            {
                context.ModelState.AddModelError("ProductId", "ProductId is not the same as Id");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

        }

    }
}

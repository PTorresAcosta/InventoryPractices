using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice5Bussiness;

namespace Practice7WebAPI.Filters.ProductFilters.ActionFilters
{
    public class Product_ValidateProductIdFilterAttribute : ActionFilterAttribute
    {
        private readonly IProductBLL _productBLL;
        public Product_ValidateProductIdFilterAttribute(IProductBLL productBLL)
        {
            _productBLL = productBLL;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var productId = context.ActionArguments["id"] as int?;

            if (productId.HasValue)
            {
                if(productId <= 0)
                {
                    context.ModelState.AddModelError("ProductId", "ProductId is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else
                {
                    var product = _productBLL.GetProducts().FirstOrDefault(p => p.ProductId == productId.Value);

                    if (product == null)
                    {
                        context.ModelState.AddModelError("Product", "Product doesn´t exist.");
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetails);
                    }else
                    {
                        context.HttpContext.Items["product"] = product;
                    }
                }
            }

        }

    }
}

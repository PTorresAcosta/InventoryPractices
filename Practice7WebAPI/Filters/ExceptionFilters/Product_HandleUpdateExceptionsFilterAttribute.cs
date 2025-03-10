using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice5Bussiness;

namespace Practice7WebAPI.Filters.ExceptionFilters
{
    public class Product_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IProductBLL _productBLL;

        public Product_HandleUpdateExceptionsFilterAttribute(IProductBLL productBLL)
        {
            _productBLL = productBLL;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strProductId = context.RouteData.Values["id"] as string;

            if (int.TryParse(strProductId, out int productId))
            {
                var product = _productBLL.GetProducts().FirstOrDefault(P => P.ProductId == productId);
                if (product == null)
                {
                    context.ModelState.AddModelError("Product", "Product doesn´t exist anymore");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }

        }

    }
}

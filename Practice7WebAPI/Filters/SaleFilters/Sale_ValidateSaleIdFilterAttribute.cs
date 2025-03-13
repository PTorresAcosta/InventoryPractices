using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness.Implementations;
using Practice5Bussiness.Interfaces;

namespace Practice7WebAPI.Filters.SaleFilters
{
    public class Sale_ValidateSaleIdFilterAttribute : ActionFilterAttribute
    {

        private readonly ISaleBLL _saleBLL;

        public Sale_ValidateSaleIdFilterAttribute(ISaleBLL saleBLL)
        {
            _saleBLL = saleBLL;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var saleId = context.ActionArguments["id"] as int?;

            if (saleId.HasValue)
            {
                if (saleId <= 0)
                {
                    context.ModelState.AddModelError("SaleId", "SaleId is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else
                {
                    var sale = _saleBLL.GetSales().FirstOrDefault(p => p.SaleId == saleId.Value);

                    if (sale == null)
                    {
                        context.ModelState.AddModelError("Sale", "Sale doesn´t exist.");
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetails);
                    }
                    else
                    {
                        context.HttpContext.Items["sale"] = sale;
                    }
                }
            }

        }
    }
}

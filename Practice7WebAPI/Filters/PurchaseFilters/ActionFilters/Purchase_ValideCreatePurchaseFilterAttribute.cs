using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice5Bussiness;
using Practice5Model.Models;

namespace Practice7WebAPI.Filters.PurchaseFilters.ActionFilters
{
    public class Purchase_ValideCreatePurchaseFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var purchase = context.ActionArguments["purchase"] as Purchase;

            if (purchase == null)
            {
                context.ModelState.AddModelError("Purchase", "Purchase object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }

    }
}

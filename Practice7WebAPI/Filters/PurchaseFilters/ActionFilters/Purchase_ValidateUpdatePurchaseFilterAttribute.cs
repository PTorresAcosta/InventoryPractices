using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice5Model.Models;

namespace Practice7WebAPI.Filters.PurchaseFilters.ActionFilters
{
    public class Purchase_ValidateUpdatePurchaseFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var purchaseId = context.ActionArguments["id"] as int?;
            var purchase = context.ActionArguments["purchase"] as Purchase;

            if (purchaseId.HasValue && purchase != null && purchaseId != purchase.PurchaseId)
            {
                context.ModelState.AddModelError("PurchaseId", "PurchaseId is not the same as Id");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

        }

    }
}

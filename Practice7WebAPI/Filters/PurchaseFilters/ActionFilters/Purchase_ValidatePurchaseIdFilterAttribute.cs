using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice5DataAccess;

namespace Practice7WebAPI.Filters.PurchaseFilters.ActionFilters
{
    public class Purchase_ValidatePurchaseIdFilterAttribute : ActionFilterAttribute
    {
        private readonly IPurchaseBLL _purchaseBLL;

        public Purchase_ValidatePurchaseIdFilterAttribute(IPurchaseBLL purchaseBLL)
        {
            _purchaseBLL = purchaseBLL;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var purchaseId = context.ActionArguments["id"] as int?;

            if (purchaseId.HasValue)
            {
                if (purchaseId <= 0)
                {
                    context.ModelState.AddModelError("PurchaseId", "PurchaseId is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else
                {
                    var purchase = _purchaseBLL.GetPurchases().FirstOrDefault(p => p.PurchaseId == purchaseId.Value);

                    if (purchase == null)
                    {
                        context.ModelState.AddModelError("Purchase", "Purchase doesn´t exist.");
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetails);
                    }
                    else
                    {
                        context.HttpContext.Items["purchase"] = purchase;
                    }
                }
            }

        }

    }
}

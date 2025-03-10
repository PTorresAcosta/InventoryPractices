using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice5DataAccess;

namespace Practice7WebAPI.Filters.PurchaseFilters.ExcepptionFilters
{
    public class Purchase_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IPurchaseBLL _purchaseBLL;

        public Purchase_HandleUpdateExceptionsFilterAttribute(IPurchaseBLL purchaseBLL)
        {
            _purchaseBLL = purchaseBLL;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strPurchaseId = context.RouteData.Values["id"] as string;

            if (int.TryParse(strPurchaseId, out int purchaseId))
            {
                var purchase = _purchaseBLL.GetPurchases().FirstOrDefault(P => P.PurchaseId == purchaseId);
                if (purchase == null)
                {
                    context.ModelState.AddModelError("Purchase", "Purchase doesn´t exist anymore");
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

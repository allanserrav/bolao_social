using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BolaoSocial.Api.Filters
{
    // https://www.jerriepelser.com/blog/validation-response-aspnet-core-webapi/
    // https://www.c-sharpcorner.com/article/working-with-filters-in-asp-net-core-mvc/

    public class ValidateModelStateFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
            var executed = await next();
            if (executed.Exception != null && !executed.ExceptionHandled)
            {
                context.Result = new BadRequestObjectResult(executed.Exception);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace YldChallenge.Application.Filters;

public class UserAgentFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

        if (string.IsNullOrEmpty(userAgent))
        {
            context.Result = new BadRequestObjectResult("User agent is missing");
            return;
        }
    }
}

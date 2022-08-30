using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MVCCore.Models
{
    public class CustomLogFilter :ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            Log("OnActionExecuted", actionExecutedContext.RouteData);
        }
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            Log("OnActionExecuting", actionExecutingContext.RouteData);
        }
        private void Log(string methodName,RouteData routeData)
        {
            var controllerName = routeData.Values["Controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("{0}- Controller:{1} Action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message);
        }
    }
}

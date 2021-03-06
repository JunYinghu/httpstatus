using System.Web.Mvc;

namespace Teapot.Web
{
    public class CorsAllowAnyOriginAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Response.Headers["Access-Control-Allow-Origin"] == null)
            {
                filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            }

            if (filterContext.HttpContext.Request.Headers["Access-Control-Request-Headers"] != null)
            {
                filterContext.HttpContext.Response.Headers.Add(
                    "Access-Control-Allow-Headers",
                    filterContext.HttpContext.Request.Headers["Access-Control-Request-Headers"]
                );
            }
            base.OnResultExecuted(filterContext);
        }
    }
}

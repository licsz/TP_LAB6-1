using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FSPPApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UTF8ActionFilter());
        }
    }

    public class UTF8ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.ContentEncoding = Encoding.UTF8;
            filterContext.HttpContext.Response.HeaderEncoding = Encoding.UTF8;
            filterContext.HttpContext.Response.Charset = "utf-8";
            filterContext.HttpContext.Response.ContentType = "text/html; charset=utf-8";
            
            base.OnActionExecuting(filterContext);
        }
    }
} 
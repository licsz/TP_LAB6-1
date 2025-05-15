using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;

namespace FSPPApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Регистрируем фильтры
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
            // Регистрируем маршруты
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Установка кодировки для каждого запроса
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.ContentType = "text/html; charset=utf-8";
        }
    }
} 
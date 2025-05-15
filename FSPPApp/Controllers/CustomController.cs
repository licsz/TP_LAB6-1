using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;

namespace FSPPApp.Controllers
{
    /// <summary>
    /// Реализация требования: "Добавить класс, реализующий интерфейс IController"
    /// 
    /// CustomController - пользовательский контроллер, реализующий интерфейс IController.
    /// Данный интерфейс требует реализации метода Execute(RequestContext).
    /// В отличие от наследования от Controller, здесь мы напрямую управляем 
    /// обработкой запроса и формированием ответа.
    /// </summary>
    public class CustomController : IController
    {
        /// <summary>
        /// Реализация метода Execute для обработки запросов, согласно интерфейсу IController.
        /// 
        /// Метод выполняет требование: "В методе Execute(), проверив, что название метода действия – «start», 
        /// а значение переменной id – 0, выполнить переход на метод Index() обычного контроллера.
        /// Если условия не выполняются, вывести сообщение об ошибке, а также полный URL."
        /// </summary>
        /// <param name="requestContext">Контекст запроса</param>
        public void Execute(RequestContext requestContext)
        {
            // Получаем параметры запроса из маршрута
            var routeData = requestContext.RouteData;
            var actionName = routeData.Values["action"] as string;
            var id = routeData.Values["id"];
            
            // Проверяем, что id равно 0 (конвертируем в int и сравниваем)
            int idValue;
            bool isIdZero = int.TryParse(id?.ToString() ?? "", out idValue) && idValue == 0;
            
            // Получаем контекстные объекты для работы с запросом и ответом
            HttpContextBase context = requestContext.HttpContext;
            HttpResponseBase response = context.Response;
            
            // Устанавливаем кодировку ответа
            response.Clear();
            response.BufferOutput = true;
            response.ContentEncoding = Encoding.UTF8;
            response.HeaderEncoding = Encoding.UTF8;
            response.ContentType = "text/html; charset=utf-8";
            response.Charset = "utf-8";
            
            // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: проверяем условие action="start" и id=0
            if (actionName == "start" && isIdZero)
            {
                // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: выполняем переход на метод Index() обычного контроллера (HomeController)
                var controller = new HomeController();
                var controllerContext = new ControllerContext(
                    new RequestContext(requestContext.HttpContext, new RouteData()), 
                    controller);
                controller.ControllerContext = controllerContext;
                
                // Получаем и выполняем результат метода Index()
                var result = controller.Index();
                result.ExecuteResult(controllerContext);
            }
            else
            {
                // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: если условия не выполняются, выводим сообщение об ошибке и полный URL
                response.Write("<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Ошибка</title></head><body>");
                response.Write("<h2>Ошибка: не выполнены условия для перехода</h2>");
                
                // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: с новой строки выводим полный URL, используя контекстный объект Request.Url
                response.Write("<p>Полный URL: " + context.Request.Url + "</p>");
                response.Write("</body></html>");
            }
        }
    }
} 
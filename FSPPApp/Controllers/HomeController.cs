using System;
using System.Web.Mvc;
using System.Text;
using System.Web;

namespace FSPPApp.Controllers
{
    /// <summary>
    /// Реализация требования: "а также обычный контроллер с методом Index()"
    /// 
    /// Обычный контроллер MVC, наследующийся от базового класса Controller.
    /// В отличие от CustomController, который реализует интерфейс IController напрямую,
    /// данный класс использует стандартную инфраструктуру MVC с действиями (actions),
    /// моделями представления и маршрутизацией.
    /// </summary>
    [ValidateInput(false)]
    public class HomeController : Controller
    {
        /// <summary>
        /// РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: "обычный контроллер с методом Index()"
        /// 
        /// GET-метод Index() отображает форму ввода данных.
        /// </summary>
        /// <returns>Представление с формой ввода данных</returns>
        public ActionResult Index()
        {
            // Устанавливаем кодировку UTF-8 для всего ответа
            HttpContext.Response.Clear();
            HttpContext.Response.BufferOutput = true;
            HttpContext.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Response.HeaderEncoding = Encoding.UTF8;
            HttpContext.Response.ContentType = "text/html; charset=utf-8";
            HttpContext.Response.Charset = "utf-8";
            
            return View();
        }

        /// <summary>
        /// РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ:
        /// "Создать Post-метод Index(), в котором получить введённые данные (частично из параметров 
        /// метода действия, частично с помощью контекстного объекта Request.Form) и вывести их 
        /// в ещё одном представлении, передав значения с помощью объекта ViewBag, если числовой
        /// идентификатор не пустой. Иначе выполнить перенаправление снова на метод действия Index(),
        /// используя метод RedirectToAction()"
        /// </summary>
        /// <param name="caseNumber">Номер производства (параметр метода)</param>
        /// <param name="fullName">ФИО должника (параметр метода)</param>
        /// <returns>Представление с результатами или перенаправление</returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(int? caseNumber, string fullName)
        {
            // Устанавливаем кодировку UTF-8 для всего ответа
            HttpContext.Response.Clear();
            HttpContext.Response.BufferOutput = true;
            HttpContext.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Response.HeaderEncoding = Encoding.UTF8;
            HttpContext.Response.ContentType = "text/html; charset=utf-8";
            HttpContext.Response.Charset = "utf-8";
            
            // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: проверяем, не пустой ли числовой идентификатор
            if (caseNumber.HasValue)
            {
                // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: получаем введённые данные частично из параметров метода
                // (caseNumber, fullName уже получены как параметры)
                
                // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: получаем остальные данные с помощью контекстного объекта Request.Form
                var debtAmount = Request.Form["debtAmount"];
                var caseDate = Request.Form["caseDate"];
                var caseStatus = Request.Form["caseStatus"];
                var hasPropertyArrest = Request.Form["hasPropertyArrest"] != null;

                // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: передаем значения с помощью объекта ViewBag
                ViewBag.CaseNumber = caseNumber;
                ViewBag.FullName = fullName;
                ViewBag.DebtAmount = debtAmount;
                ViewBag.CaseDate = caseDate;
                ViewBag.CaseStatus = caseStatus;
                ViewBag.HasPropertyArrest = hasPropertyArrest;

                // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: выводим данные в ещё одном представлении (Result)
                return View("Result");
            }
            else
            {
                // РЕАЛИЗАЦИЯ ТРЕБОВАНИЯ: если числовой идентификатор пустой, 
                // выполняем перенаправление снова на метод действия Index(),
                // используя метод RedirectToAction()
                return RedirectToAction("Index");
            }
        }
    }
} 
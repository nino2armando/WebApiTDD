using System.Web.Mvc;
using AutoMapper;
using WebApiTDD.Context.AppContext;
using WebApiTDD.DataContract;
using WebApiTDD.Domain.Models;
using WebApiTDD.Repository.Repository;
using WebApiTDD.Repository.UnitOfWork;
using WebApiTDD.Sevice.Services;


namespace WebApiTDD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UnitOfWork<WebApiTddContext> unitOfWork = new UnitOfWork<WebApiTddContext>();
            EmployeeService service = new EmployeeService(unitOfWork);
            var emps = service.FindById(1);
            ViewBag.emp = emps;
            return View();
        }
    }
}

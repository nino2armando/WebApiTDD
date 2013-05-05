
using System.Web.Mvc;
using WebApiTDD.AppContext;
using WebApiTDD.AppContext;
using WebApiTDD.Models;

namespace WebApiTDD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebApiTddContext 
               context = new WebApiTddContext();
            Manager manager = new Manager();
            manager.Name = "nino";
            
            context.Managers.Add(manager);
            context.SaveChanges();
            return View();
        }
    }
}

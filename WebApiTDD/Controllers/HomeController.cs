using System.Web.Mvc;


namespace WebApiTDD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

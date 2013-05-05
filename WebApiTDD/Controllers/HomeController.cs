using System.Web.Mvc;
using WebApiTDD.AppContext;
using WebApiTDD.Domain.Models;
using WebApiTDD.Repository.Repository;
using WebApiTDD.Repository.UnitOfWork;


namespace WebApiTDD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UnitOfWork<WebApiTddContext> unitOfWork = new UnitOfWork<WebApiTddContext>();
            IRepository<Manager> managerRepo = unitOfWork.GetRepository<Manager>();
            var manager = managerRepo.GetById(1);
            
            return View();
        }
    }
}

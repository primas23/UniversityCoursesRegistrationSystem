using System.Web.Mvc;

namespace UCRS.Web.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Manage");
        }

        public ActionResult Manage()
        {
            return View();
        }
    }
}
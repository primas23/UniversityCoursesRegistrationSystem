using System.Web.Mvc;

using UCRS.Common.Contracts;
using UCRS.Data;
using UCRS.Services;

namespace UCRS.Web.Controllers
{
    public class HomeController : Controller
    {
        private IStudentService _studentService = null;

        public HomeController()
        {
            this._studentService = new StudentService(new UniversitySystemDbContext());
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Web.Mvc;

using UCRS.Common;
using UCRS.Common.Contracts;

namespace UCRS.Web.Controllers
{
    public class HomeController : Controller
    {
        private IStudentService _studentService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        /// <exception cref="ArgumentNullException">The Student Service is null</exception>
        public HomeController(IStudentService studentService)
        {
            if (studentService == null)
            {
                throw new ArgumentNullException(GlobalConstants.StudentServiceNullMessage);
            }

            this._studentService = studentService;
        }

        public ActionResult Index()
        {


            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using UCRS.Common;
using UCRS.Common.Contracts;
using UCRS.Data.Models;
using UCRS.Services.Contracts;
using UCRS.WebClient.Attributes;
using UCRS.WebClient.Models;

namespace UCRS.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private IStudentService _studentService = null;
        private ICourseService _courseService = null;
        private IIdentifierProvider _identifierProvider = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        /// <param name="courseService">The course service</param>
        /// <param name="identifierProvider">The identifier provider.</param>
        /// <exception cref="ArgumentNullException">The Student Service is null</exception>
        public HomeController(IStudentService studentService, ICourseService courseService, IIdentifierProvider identifierProvider)
        {
            if (studentService == null)
            {
                throw new ArgumentNullException(GlobalConstants.StudentServiceNullMessage);
            }

            if (courseService == null)
            {
                throw new ArgumentNullException(GlobalConstants.CourseServiceNullMessage);
            }

            if (identifierProvider == null)
            {
                throw new ArgumentNullException(GlobalConstants.IdentifierProviderNullMessage);
            }

            this._courseService = courseService;
            this._studentService = studentService;
            this._identifierProvider = identifierProvider;
        }

        [HttpGet]
        [AuthorizeStudent]
        public async Task<ActionResult> Index()
        {
            Guid strudneId = this.GetStrudneId();

            StudentCoursesViewModel viewModel = new StudentCoursesViewModel();

            var getStudnetsId = this._studentService
                    .GetStudentCoursesIdsAsync(strudneId);

            var allCourses = this._courseService
                .GetAllCoursesAsync();

            viewModel.RegisteredCoursesIds = await getStudnetsId;
            viewModel.AllCourses = await allCourses;

            return this.View(viewModel);
        }

        [HttpPost]
        [AuthorizeStudent]
        public ContentResult AssignToCourse(Guid courseId)
        {
            Guid strudneId = this.GetStrudneId();
            bool isAsingedCrrectly = this._studentService.AssignCourseToUser(courseId, strudneId);

            if (isAsingedCrrectly == false)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string response = GlobalConstants.YouHaveAlreadyRegisteredMessage;
                return this.Content(response);
            }

            return new ContentResult();
        }

        /// <summary>
        /// Gets the strudne identifier.
        /// </summary>
        /// <returns>The student id.</returns>
        private Guid GetStrudneId()
        {
            HttpCookie loggedStudentCookie = HttpContext.Request.Cookies.Get(GlobalConstants.StudentCookieKey);

            if (loggedStudentCookie != null)
            {
                Guid strudneId = this._identifierProvider.DecodeId(loggedStudentCookie.Value);

                return strudneId;
            }

            return new Guid();
        }
    }
}
﻿using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using UCRS.Common;
using UCRS.Common.Contracts;
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
        public ActionResult Index()
        {
            Guid strudneId = GetStrudneId();

            StudentCoursesViewModel viewModel = new StudentCoursesViewModel
            {
                RegisteredCoursesIds = this._studentService
                    .GetStudentCoursesIds(strudneId)
                    .ToList(),

                AllCourses = this._courseService
                    .GetAllCourses()
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [AuthorizeStudent]
        public ContentResult AssignToCourse(Guid courseId)
        {
            Guid strudneId = GetStrudneId();
            bool isAsingedCrrectly = this._studentService.AssignCourseToUser(courseId, strudneId);

            if (isAsingedCrrectly == false)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string response = GlobalConstants.YouHaveAlreadyRegisteredMessage;
                return Content(response);
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
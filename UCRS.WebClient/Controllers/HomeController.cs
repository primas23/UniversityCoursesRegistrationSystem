﻿using System;
using System.Linq;
using System.Web.Mvc;

using UCRS.Common;
using UCRS.Services.Contracts;
using UCRS.WebClient.Models;

namespace UCRS.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private IStudentService _studentService = null;
        private ICourseService _courseService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        /// <param name="courseService">The course service</param>
        /// <exception cref="ArgumentNullException">The Student Service is null</exception>
        public HomeController(IStudentService studentService, ICourseService courseService)
        {
            if (studentService == null)
            {
                throw new ArgumentNullException(GlobalConstants.StudentServiceNullMessage);
            }

            if (courseService == null)
            {
                throw new ArgumentNullException(GlobalConstants.StudentServiceNullMessage);
            }

            this._courseService = courseService;
            this._studentService = studentService;
        }

        public ActionResult Index()
        {
            Guid strudneId = Guid.Parse("F3B003A5-6A3E-4238-ADDF-E0F6BB230E1A");

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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using UCRS.Common;
using UCRS.Data.Models;
using UCRS.Services.Contracts;
using UCRS.WebClient.Attributes;
using UCRS.WebClient.Models;

namespace UCRS.WebClient.Controllers
{
    public class CoursesController : Controller
    {
        private IStudentService _studentService = null;
        private ICourseService _courseService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        /// <param name="courseService">The course service</param>
        /// <exception cref="ArgumentNullException">The Student Service is null</exception>
        public CoursesController(IStudentService studentService, ICourseService courseService)
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

        [HttpGet]
        [AuthorizeStudent]
        public ActionResult Index()
        {
            IList<CourseViewModel> coursesViewModel = this.MapCoursesToViewModels(this._courseService.GetAllCourses());

            return this.View(coursesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeStudent]
        public ActionResult Save(ICollection<CourseViewModel> courseViewModels)
        {
            if (ModelState.IsValid == false)
            {
                return this.View(courseViewModels);
            }

            this._courseService.SaveCourses(this.MapViewModelsToCourses(courseViewModels));

            return this.RedirectToAction("Index", "Courses");
        }

        [HttpGet]
        [AuthorizeStudent]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [AuthorizeStudent]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return this.View(courseViewModel);
            }

            this._courseService.SaveCourse(new Course()
            {
                Name = courseViewModel.Name
            });

            return this.PartialView("Add");
        }

        [HttpPost]
        [AuthorizeStudent]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid courseId)
        {
            this._courseService.DeleteCourse(courseId);

            return this.PartialView();
        }

        /// <summary>
        /// Maps the view models to courses.
        /// </summary>
        /// <param name="courseViewModels">The course view models.</param>
        /// <returns>Collection of Courses</returns>
        private IList<Course> MapViewModelsToCourses(ICollection<CourseViewModel> courseViewModels)
        {
            IList<Course> courses = new List<Course>();

            foreach (CourseViewModel courseViewModel in courseViewModels)
            {
                courses.Add(new Course()
                {
                    Id = courseViewModel.Id,
                    Name = courseViewModel.Name
                });
            }

            return courses;
        }

        /// <summary>
        /// Maps the courses to view models.
        /// </summary>
        /// <param name="courses">The courses.</param>
        /// <returns>Collection of CourseViewModels</returns>
        private IList<CourseViewModel> MapCoursesToViewModels(ICollection<Course> courses)
        {
            IList<CourseViewModel> courseViewModels = new List<CourseViewModel>();

            foreach (Course course in courses)
            {
                courseViewModels.Add(new CourseViewModel()
                {
                    Id = course.Id,
                    Name = course.Name
                });
            }

            return courseViewModels;
        }
    }
}
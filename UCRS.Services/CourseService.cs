using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCRS.Common;
using UCRS.Data.Contracts;
using UCRS.Data.Models;
using UCRS.Services.Contracts;

namespace UCRS.Services
{
    public class CourseService : ICourseService
    {
        private IUniversitySystemDbContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">The context is null</exception>
        public CourseService(IUniversitySystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(GlobalConstants.ContextNullMessage);
            }

            this._context = context;
        }

        /// <summary>
        /// Gets all courses async.
        /// </summary>
        /// <returns>
        /// Collection of all courses
        /// </returns>
        public async Task<ICollection<Course>> GetAllCoursesAsync()
        {
            return await Task.Run<IList<Course>>(() => this._context
                .Courses
                .ToList());
        }

        /// <summary>
        /// Gets all courses.
        /// </summary>
        /// <returns>
        /// Collection of all courses
        /// </returns>
        public ICollection<Course> GetAllCourses()
        {
            return this._context
                .Courses
                .ToList();
        }

        /// <summary>
        /// Saves the courses.
        /// </summary>
        /// <param name="courses">The courses.</param>
        public void SaveCourses(IList<Course> courses)
        {
            for (int i = 0; i < courses.Count(); i++)
            {
                Guid id = courses[i].Id;

                Course course = this._context
                    .Courses
                    .FirstOrDefault(c => c.Id == id);

                if (course != null)
                {
                    course.Name = courses[i].Name;
                }
            }

            this._context.SaveChanges();
        }

        /// <summary>
        /// Saves the course.
        /// </summary>
        /// <param name="course">The course.</param>
        public void SaveCourse(Course course)
        {
            this._context.Courses.Add(course);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Deletes the course.
        /// </summary>
        /// <param name="courseId">The course identifier.</param>
        public void DeleteCourse(Guid courseId)
        {
            Course course = this._context
                .Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {
                this._context.Courses.Remove(course);
                this._context.SaveChanges();
            }
        }
    }
}

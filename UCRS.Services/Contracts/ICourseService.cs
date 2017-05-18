using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using UCRS.Data.Models;

namespace UCRS.Services.Contracts
{
    public interface ICourseService
    {
        /// <summary>
        /// Gets all courses async.
        /// </summary>
        /// <returns>Collection of all courses</returns>
        Task<ICollection<Course>> GetAllCoursesAsync();

        /// <summary>
        /// Gets all courses.
        /// </summary>
        /// <returns>Collection of all courses</returns>
        ICollection<Course> GetAllCourses();

        /// <summary>
        /// Saves the courses.
        /// </summary>
        /// <param name="courses">The courses.</param>
        void SaveCourses(IList<Course> courses);

        /// <summary>
        /// Saves the course.
        /// </summary>
        /// <param name="course">The course.</param>
        void SaveCourse(Course course);

        /// <summary>
        /// Deletes the course.
        /// </summary>
        /// <param name="courseId">The course identifier.</param>
        void DeleteCourse(Guid courseId);
    }
}
using System.Collections.Generic;

using UCRS.Data.Models;

namespace UCRS.Services.Contracts
{
    public interface ICourseService
    {
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
    }
}
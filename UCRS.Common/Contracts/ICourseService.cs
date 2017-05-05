using System.Collections.Generic;

namespace UCRS.Common.Contracts
{
    public interface ICourseService
    {
        /// <summary>
        /// Gets all courses.
        /// </summary>
        /// <returns>Collection of all courses</returns>
        ICollection<ICourse> GetAllCourses();
    }
}
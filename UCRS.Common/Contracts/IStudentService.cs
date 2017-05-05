using System;
using System.Collections.Generic;

namespace UCRS.Common.Contracts
{
    public interface IStudentService
    {
        ICollection<ICourse> GetAllCourses();

        /// <summary>
        /// Gets the student courses.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>
        /// Collection of the courses in which the student is registered.
        /// </returns>
        ICollection<ICourse> GetStudentCourses(Guid studentId);
    }
}
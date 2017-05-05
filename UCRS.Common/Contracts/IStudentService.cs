using System;
using System.Collections.Generic;

namespace UCRS.Common.Contracts
{
    public interface IStudentService
    {
        /// <summary>
        /// Gets the student courses.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>
        /// Collection of the courses in which the student is registered.
        /// </returns>
        ICollection<ICourse> GetStudentCourses(Guid studentId);

        /// <summary>
        /// Gets the student courses ids.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>
        /// Collection of the courses ids in which the student is registered.
        /// </returns>
        ICollection<Guid> GetStudentCoursesIds(Guid studentId);
    }
}
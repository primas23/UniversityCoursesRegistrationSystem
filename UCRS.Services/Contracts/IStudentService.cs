using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using UCRS.Data.Models;

namespace UCRS.Services.Contracts
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
        ICollection<Course> GetStudentCourses(Guid studentId);

        /// <summary>
        /// Gets the student courses ids async.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>
        /// Collection of the courses ids in which the student is registered.
        /// </returns>
        Task<ICollection<Guid>> GetStudentCoursesIdsAsync(Guid studentId);

        /// <summary>
        /// Gets the student courses ids.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>
        /// Collection of the courses ids in which the student is registered.
        /// </returns>
        ICollection<Guid> GetStudentCoursesIds(Guid studentId);

        /// <summary>
        /// Doeses the student exist.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>If the student exists.</returns>
        bool DoesStudentExist(Guid id);

        /// <summary>
        /// Gets the student id by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The id of the student</returns>
        Guid GetStudentIdbyEmail(string email);

        /// <summary>
        /// Assigns the course to user.
        /// </summary>
        /// <param name="courseId">The course identifier.</param>
        /// <param name="strudneId">The strudne identifier.</param>
        /// <returns>If cource was assigned</returns>
        bool AssignCourseToUser(Guid courseId, Guid strudneId);
    }
}
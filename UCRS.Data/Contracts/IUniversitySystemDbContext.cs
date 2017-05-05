using System.Data.Entity;

using UCRS.Common.Contracts;
using UCRS.Data.Models;

namespace UCRS.Data.Contracts
{
    public interface IUniversitySystemDbContext
    {
        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        IDbSet<Course> Courses { get; set; }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        IDbSet<Student> Students { get; set; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>
        /// If the changes were made
        /// </returns>
        int SaveChanges();
    }
}
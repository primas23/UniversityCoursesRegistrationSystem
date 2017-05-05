using System.Data.Entity;

namespace UCRS.Common.Contracts
{
    public interface IUniversitySystemDbContext
    {
        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        IDbSet<ICourse> Courses { get; set; }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        IDbSet<IStudent> Students { get; set; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>
        /// If the changes were made
        /// </returns>
        int SaveChanges();
    }
}
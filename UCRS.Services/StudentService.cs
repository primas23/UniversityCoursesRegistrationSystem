using System;
using System.Collections.Generic;
using System.Linq;

using UCRS.Common;
using UCRS.Common.Contracts;
using UCRS.Data;

namespace UCRS.Services
{
    public class StudentService : IStudentService
    {
        private IUniversitySystemDbContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class with the default context.
        /// </summary>
        public StudentService()
        {
            this._context = new UniversitySystemDbContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">The context is null</exception>
        public StudentService(IUniversitySystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(GlobalConstants.ContextNullMessage);
            }

            this._context = context;
        }

        public ICollection<ICourse> GetAllCourses()
        {
            return null;
        }

        /// <summary>
        /// Gets the student courses.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>
        /// Collection of the courses in which the student is registered.
        /// </returns>
        public ICollection<ICourse> GetStudentCourses(Guid studentId)
        {
            IStudent student = this._context
                .Students
                .FirstOrDefault(s => s.Id == studentId);

            if (student != null)
            {
                return student
                    .Courses
                    .ToList();
            }

            return new List<ICourse>();
        }
    }
}

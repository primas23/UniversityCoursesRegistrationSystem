using System;
using System.Collections.Generic;
using System.Linq;

using UCRS.Common;
using UCRS.Data.Contracts;
using UCRS.Data.Models;
using UCRS.Services.Contracts;

namespace UCRS.Services
{
    public class StudentService : IStudentService
    {
        private IUniversitySystemDbContext _context = null;
        
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
        
        /// <summary>
        /// Gets the student courses.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>
        /// Collection of the courses in which the student is registered.
        /// </returns>
        public ICollection<Course> GetStudentCourses(Guid studentId)
        {
            Student student = this.GetStudent(studentId);

            if (student != null)
            {
                return student
                    .Courses
                    .ToList();
            }

            return new List<Course>();
        }

        /// <summary>
        /// Gets the student courses ids.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>
        /// Collection of the courses ids in which the student is registered.
        /// </returns>
        public ICollection<Guid> GetStudentCoursesIds(Guid studentId)
        {
            Student student = this.GetStudent(studentId);

            if (student != null)
            {
                return student
                    .Courses
                    .Select(c => c.Id)
                    .ToList();
            }
            
            return new List<Guid>();
        }

        /// <summary>
        /// Gets the student with the supplied id.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>Returns null if not fould.</returns>
        private Student GetStudent(Guid studentId)
        {
            return this._context
                .Students
                .FirstOrDefault(s => s.Id == studentId);
        }
    }
}

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

        /// <summary>
        /// Doeses the student exist.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// If the student exists.
        /// </returns>
        public bool DoesStudentExist(Guid id)
        {
            return this._context.Students.Count(s => s.Id == id) > 0;
        }

        /// <summary>
        /// Gets the student id by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// The id of the student
        /// </returns>
        public Guid GetStudentIdbyEmail(string email)
        {
            return this._context
                .Students
                .Where(s => s.Email == email)
                .Select(s => s.Id)
                .First();
        }

        /// <summary>
        /// Assigns the course to user.
        /// </summary>
        /// <param name="courseId">The course identifier.</param>
        /// <param name="strudneId">The strudne identifier.</param>
        /// <returns>
        /// If cource was assigned
        /// </returns>
        public bool AssignCourseToUser(Guid courseId, Guid strudneId)
        {
            Course course = this._context
                .Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                return false;
            }

            Student student = this._context
                .Students
                .FirstOrDefault(s => s.Id == strudneId);

            if (student == null)
            {
                return false;
            }

            if (student.Courses.Contains(course))
            {
                return false;
            }

            student.Courses.Add(course);
            return this._context.SaveChanges() > -1;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;

using UCRS.Common;
using UCRS.Data.Contracts;
using UCRS.Data.Models;
using UCRS.Services.Contracts;

namespace UCRS.Services
{
    public class CourseService : ICourseService
    {
        private IUniversitySystemDbContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">The context is null</exception>
        public CourseService(IUniversitySystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(GlobalConstants.ContextNullMessage);
            }

            this._context = context;
        }

        /// <summary>
        /// Gets all courses.
        /// </summary>
        /// <returns>
        /// Collection of all courses
        /// </returns>
        public ICollection<Course> GetAllCourses()
        {
            return this._context
                .Courses
                .ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using UCRS.Data.Models;

namespace UCRS.WebClient.Models
{
    public class StudentCoursesViewModel
    {
        /// <summary>
        /// Gets or sets the registered courses.
        /// </summary>
        /// <value>
        /// The registered courses.
        /// </value>
        public ICollection<Course> AllCourses { get; set; }

        /// <summary>
        /// Gets the registerd courses.
        /// </summary>
        /// <value>
        /// The registerd courses.
        /// </value>
        public ICollection<Course> RegisterdCourses
        {
            get
            {
                if (this.AllCourses == null || this.AllCourses.Any() == false)
                {
                    return new List<Course>();
                }

                return this.AllCourses
                    .Where(a => this.RegisteredCoursesIds.Contains(a.Id))
                    .ToList();
            }
        }

        /// <summary>
        /// Gets the not registerd courses.
        /// </summary>
        /// <value>
        /// The not registerd courses.
        /// </value>
        public ICollection<Course> NotRegisterdCourses
        {
            get
            {
                if (this.AllCourses == null)
                {
                    return new List<Course>();
                }

                return this.AllCourses
                    .Where(a => this.RegisteredCoursesIds.Contains(a.Id) == false)
                    .ToList();
            }
        }

        /// <summary>
        /// Gets or sets the registered courses ids.
        /// </summary>
        /// <value>
        /// The registered courses ids.
        /// </value>
        public ICollection<Guid> RegisteredCoursesIds { get; set; }
    }
}
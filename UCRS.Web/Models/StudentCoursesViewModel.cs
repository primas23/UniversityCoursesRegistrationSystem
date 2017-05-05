using System;
using System.Collections.Generic;

using UCRS.Common.Contracts;

namespace UCRS.Web.Models
{
    public class StudentCoursesViewModel
    {
        /// <summary>
        /// Gets or sets the registered courses.
        /// </summary>
        /// <value>
        /// The registered courses.
        /// </value>
        public IList<ICourse> AllCourses { get; set; }

        /// <summary>
        /// Gets or sets the registered courses ids.
        /// </summary>
        /// <value>
        /// The registered courses ids.
        /// </value>
        public IList<Guid> RegisteredCoursesIds { get; set; }
    }
}
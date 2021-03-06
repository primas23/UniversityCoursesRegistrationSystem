﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using UCRS.Common;

namespace UCRS.Data.Models
{
    public class Student : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        [MaxLength(GlobalConstants.MaxPasswordLenght)]
        [MinLength(GlobalConstants.MinPasswordLenght)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [MaxLength(GlobalConstants.MaxNameLenght)]
        [MinLength(GlobalConstants.MinNameLenght)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public virtual ICollection<Course> Courses { get; set; }
    }
}

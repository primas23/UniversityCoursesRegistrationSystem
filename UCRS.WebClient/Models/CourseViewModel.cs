using System;
using System.ComponentModel.DataAnnotations;

using UCRS.Common;

namespace UCRS.WebClient.Models
{
    public class CourseViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
    }
}
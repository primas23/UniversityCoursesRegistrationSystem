using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using UCRS.Common;

namespace UCRS.Data.Models
{
    public class Course : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

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
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        public virtual ICollection<Student> Students { get; set; }
    }
}

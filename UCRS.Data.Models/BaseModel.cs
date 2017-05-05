using System;
using System.ComponentModel.DataAnnotations;

namespace UCRS.Data.Models
{
    /// <summary>
    /// Base class for Data Models
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModel"/> class.
        /// </summary>
        protected BaseModel()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public Guid Id { get; set; }
    }
}

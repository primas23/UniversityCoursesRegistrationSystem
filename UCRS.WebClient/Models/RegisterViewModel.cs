using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using UCRS.Common;

namespace UCRS.WebClient.Models
{
    public class RegisterViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        [StringLength(GlobalConstants.MaxPasswordLenght, ErrorMessage = GlobalConstants.MustBeAtleastMessageFormat, MinimumLength = GlobalConstants.MinPasswordLenght)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = GlobalConstants.PasswordAndConfirmPasswordDoNotMatchMessage)]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Index(IsUnique = true)]
        [StringLength(GlobalConstants.MaxNameLenght, ErrorMessage = GlobalConstants.MustBeAtleastMessageFormat, MinimumLength = GlobalConstants.MinNameLenght)]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
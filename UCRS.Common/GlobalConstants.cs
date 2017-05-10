namespace UCRS.Common
{
    public class GlobalConstants
    {
        /// <summary>
        /// The maximum name lenght
        /// </summary>
        public const int MaxNameLenght = 100;

        /// <summary>
        /// The minimum name lenght
        /// </summary>
        public const int MinNameLenght = 3;

        /// <summary>
        /// The minimum password lenght
        /// </summary>
        public const int MinPasswordLenght = 3;

        /// <summary>
        /// The maximum password lenght
        /// </summary>
        public const int MaxPasswordLenght = 100;

        /// <summary>
        /// The student cookie key
        /// </summary>
        public const string StudentCookieKey = "thisisstudentsupersecretcookie";

        /// <summary>
        /// The context null message
        /// </summary>
        public const string ContextNullMessage = "The context is null";

        /// <summary>
        /// The identifier provider null message
        /// </summary>
        public const string IdentifierProviderNullMessage = "The Identifier Provider is null";

        /// <summary>
        /// The student service null message
        /// </summary>
        public const string StudentServiceNullMessage = "The Student Service is null";
        
        /// <summary>
        /// The account service null message
        /// </summary>
        public const string AccountServiceNullMessage = "The Account Service is null";

        /// <summary>
        /// The course service null message
        /// </summary>
        public const string CourseServiceNullMessage = "The Course Service is null";

        /// <summary>
        /// The invalid login attempt message
        /// </summary>
        public const string InvalidLoginAttemptMessage = "Invalid login attempt.";

        /// <summary>
        /// The must be atleast message
        /// </summary>
        public const string MustBeAtleastMessageFormat = "The {0} must be at least {2} characters long.";

        /// <summary>
        /// The password and confirm password do not match message
        /// </summary>
        public const string PasswordAndConfirmPasswordDoNotMatchMessage = "The password and confirmation password do not match.";

        /// <summary>
        /// The login redirect URL
        /// </summary>
        public const string LoginRedirectUrl = "/account/login";

        /// <summary>
        /// The salt
        /// </summary>
        public const string Salt = ".askdjh123kjn!";
    }
}

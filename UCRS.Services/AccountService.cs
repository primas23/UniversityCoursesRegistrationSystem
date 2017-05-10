using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCRS.Common;
using UCRS.Data.Contracts;
using UCRS.Data.Models;
using UCRS.Services.Contracts;

namespace UCRS.Services
{
    public class AccountService : IAccountService
    {
        private IUniversitySystemDbContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">The context is null</exception>
        public AccountService(IUniversitySystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(GlobalConstants.ContextNullMessage);
            }

            this._context = context;
        }

        /// <summary>
        /// Signs in the student.
        /// </summary>
        /// <param name="email">The model email.</param>
        /// <param name="password">The model password.</param>
        /// <returns>
        /// If the student is signed in.
        /// </returns>
        public bool SignIn(string email, string password)
        {
            Student student = this._context
                .Students
                .FirstOrDefault(s => s.Email == email);

            return (student != null) && (student.Password == password);
        }

        /// <summary>
        /// Registers the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        /// A message
        /// </returns>
        public string Register(string email, string password, string name)
        {
            if (this._context.Students.Any(s => s.Email == email))
            {
                return "There is a student with the same email!";
            }

            Student student = new Student()
            {
                Name = name,
                Email = email,
                Password = password
            };

            this._context.Students.Add(student);
            this._context.SaveChanges();
                
            return "";
        }
    }
}

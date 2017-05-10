using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCRS.Services.Contracts
{
    public interface IAccountService
    {
        /// <summary>
        /// Signs in the student.
        /// </summary>
        /// <param name="email">The model email.</param>
        /// <param name="password">The model password.</param>
        /// <returns>If the student is signed in.</returns>
        bool SignIn(string email, string password);

        /// <summary>
        /// Registers the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="name">The name.</param>
        /// <returns>A message</returns>
        string Register(string email, string password, string name);
    }
}

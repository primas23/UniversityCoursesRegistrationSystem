using System;
using System.Web;
using System.Web.Mvc;

using UCRS.Common;
using UCRS.Common.Contracts;
using UCRS.Services.Contracts;
using UCRS.WebClient.Models;

namespace UCRS.WebClient.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService = null;
        private IStudentService _studentService = null;
        private IIdentifierProvider _identifierProvider = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        /// <param name="accountService">The account service.</param>
        /// <param name="identifierProvider">The identifier provider.</param>
        /// <exception cref="ArgumentNullException">The Account Service is null</exception>
        public AccountController(IStudentService studentService, IAccountService accountService, IIdentifierProvider identifierProvider)
        {
            if (accountService == null)
            {
                throw new ArgumentNullException(GlobalConstants.AccountServiceNullMessage);
            }

            if (studentService == null)
            {
                throw new ArgumentNullException(GlobalConstants.StudentServiceNullMessage);
            }

            if (identifierProvider == null)
            {
                throw new ArgumentNullException(GlobalConstants.IdentifierProviderNullMessage);
            }

            this._accountService = accountService;
            this._studentService = studentService;
            this._identifierProvider = identifierProvider;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            bool result = this._accountService.SignIn(model.Email, model.Password);

            if (result == true)
            {
                Guid id = this._studentService.GetStudentIdbyEmail(model.Email);
                string cookieValue = this._identifierProvider.EncodeId(id);

                HttpCookie cookie = new HttpCookie(GlobalConstants.StudentCookieKey, cookieValue)
                {
                    Expires = DateTime.Now.AddMinutes(GlobalConstants.CookieExpirationTime)
                };

                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }

            this.ModelState.AddModelError("", GlobalConstants.InvalidLoginAttemptMessage);

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string registerMessage = this._accountService.Register(model.Email, model.Password, model.Name);

                if (string.IsNullOrWhiteSpace(registerMessage))
                {
                    return RedirectToAction("Index", "Home");
                }

                this.ModelState.AddModelError("", registerMessage);
            }

            return View(model);
        }
    }
}
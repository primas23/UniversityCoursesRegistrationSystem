using System;
using System.Web.Mvc;

using UCRS.Common;
using UCRS.Services.Contracts;
using UCRS.WebClient.Models;

namespace UCRS.WebClient.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        /// <exception cref="ArgumentNullException">The Account Service is null</exception>
        public AccountController(IAccountService accountService)
        {
            if (accountService == null)
            {
                throw new ArgumentNullException(GlobalConstants.AccountServiceNullMessage);
            }

            this._accountService = accountService;
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
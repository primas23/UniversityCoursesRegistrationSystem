using System;
using System.Web;
using System.Web.Mvc;

using UCRS.Common;
using UCRS.Common.Contracts;
using UCRS.Common.Providers;

namespace UCRS.WebClient.Attributes
{
    /// <summary>
    /// Attribute that redirects if there is no account or the account is expired.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.ActionFilterAttribute" />
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizeStudentAttribute : ActionFilterAttribute
    {
        private IIdentifierProvider _identifierProvider = null;
        
        public AuthorizeStudentAttribute()
        {
            this._identifierProvider = new IdentifierProvider();
        }

        public AuthorizeStudentAttribute(IIdentifierProvider identifierProvider)
        {
            if (identifierProvider == null)
            {
                throw new ArgumentNullException(GlobalConstants.IdentifierProviderNullMessage);
            }
            
            this._identifierProvider = identifierProvider;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie loggedStudentCookie = filterContext.HttpContext.Request.Cookies.Get(GlobalConstants.StudentCookieKey);

            if (loggedStudentCookie == null)
            {
                filterContext.Result = new RedirectResult(GlobalConstants.LoginRedirectUrl);
            }
            else
            {
                Guid id = this._identifierProvider.DecodeId(loggedStudentCookie.Value);

                if (id == default(Guid))
                {
                    filterContext.Result = new RedirectResult(GlobalConstants.LoginRedirectUrl);
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}

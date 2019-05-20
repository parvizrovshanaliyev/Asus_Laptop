
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.filterauth
{
    public class UserAuthenticate : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            //HttpContext.Current.User.Identity.IsAuthenticated 
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/MemberAccount/Login?ReturnUrl=/Checkout/Index");
            }
        }
    }
}
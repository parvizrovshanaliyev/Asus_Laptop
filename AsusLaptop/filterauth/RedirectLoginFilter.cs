using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.filterauth
{
    public class RedirectLoginFilter: ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {// First check if authentication succeed and user authenticated:            

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                bool IsAdmin = filterContext.HttpContext.User.IsInRole("admin");

                //Then check for user role(s) and assign view accordingly, don't forget the 
                //[Authorize(Roles = "YourRoleHere")] on your controller / action
                if (IsAdmin)
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        area = "Admin",
                        controller = "Home",
                        action = "Index"
                    }));
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        area = "",
                        controller = "Home",
                        action = "Index"
                    }));
                }
            }

            base.OnActionExecuted(filterContext);

           
        }
    }
}
using System.Web.Mvc;

namespace AsusLaptop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
                context.MapRoute(
                name: "Account",
                url: "Account/{action}/{id}",
                defaults: new
                {
                    controller = "ALogin",
                    action = "Login",
                    id = UrlParameter.Optional
                }
                );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "AsusLaptop.Areas.Admin.Controllers" }
            );
        }
    }
}
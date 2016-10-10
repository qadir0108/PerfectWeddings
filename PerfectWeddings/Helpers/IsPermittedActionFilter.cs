using PerfectWeddings.Business;
using PerfectWeddings.Data.Entities;
using PerfectWeddings.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PerfectWeddings.Helpers
{
    public class IsPermittedActionFilter : ActionFilterAttribute
    {
        public PagePermissions Permission { get; set; }

        /// <summary>
        /// Method: OnActionExecuting
        /// Comments: This action filter method is user authorized to access the page.
        /// Parameters: Required the Page Permissions enum   
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {           
            bool IsPermitted = false;

            try
            {
                // Check session
                if (HttpContext.Current.Session["User"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary   
                    {  
                        { "action", "Login" },  
                        { "controller", "Account" }                   
                    });
                    return;
                }

                // Check Admin
                var user = (User)HttpContext.Current.Session["User"];
                if (user.Type == Enums.UserTypeEnum.SuperAdmin && Permission == PagePermissions.Admin)
                    IsPermitted = true;

                if (Permission == PagePermissions.All)
                    IsPermitted = true;

                if (IsPermitted)
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
            }
            catch(Exception ex)
            {
              
            }

            // Redirect to Error page
            filterContext.Result =
                    new RedirectToRouteResult(new RouteValueDictionary   
                    {  
                        { "action", "SystemError" },  
                        { "controller", "Account" }                      
                    });
            return;
        }
    }
}
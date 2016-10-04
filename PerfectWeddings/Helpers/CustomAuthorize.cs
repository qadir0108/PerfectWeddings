using PerfectWeddings.Business;
using PerfectWeddings.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PerfectWeddings.Helpers
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return SessionObjects.isAuthenticated;
        }
    }

    public class HasPermission : ActionFilterAttribute
    {
        //Properties in Action Filter
        public PagePermissions FormType { get; set; }

        /// <summary>
        /// Method: OnActionExecuting
        /// Comments: This action filter method is user authorized to access the page.
        /// Parameters: Required the Page Permissions enum   
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {           
            bool HasPermission = false;

            try
            {
                // Check Is user session null
                if (HttpContext.Current.Session["userModel"] == null || FormType == null)
                {
                    filterContext.Result =
                        new RedirectToRouteResult(new RouteValueDictionary   
                    {  
                        { "action", "Login" },  
                        { "controller", "Account" }                   
                    });
                    return;
                }

                // Check User has permission to access given form
                var userModel = (UserModel)HttpContext.Current.Session["userModel"];
                //HasPermission = Business.AuthManager.HasPermission(FormType, (int)userModel.UserId);
                if(HasPermission)
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
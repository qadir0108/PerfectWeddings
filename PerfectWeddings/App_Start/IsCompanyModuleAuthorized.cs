using PerfectWeddings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace PerfectWeddings.App_Start
{
    public class IsCompanyModuleAuthorized: ActionFilterAttribute
    {
        public Enums.Modules Permission { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            if (HttpContext.Current.Session["IsSuperAdmin"] != null && HttpContext.Current.Session["IsSuperAdmin"].ToString().ToLower() != "superadmin")
            {
                var userModel = (UserModel)HttpContext.Current.Session["userModel"];
                //if (userModel != null)
                //    if (!AuthManager.HasCompanyModulePermission((int)Permission, (int)userModel.CompanyKey))

                //        if (!AuthManager.HasModulePermssion(Permission, (string)userModel.CompanyGuid, (string)userModel.UserGuid))
                //        {
                //            var viewData = filterContext.Controller.ViewData;

                //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                //                       {
                //                               { "action", "Index" },
                //                               { "controller", "Home" }
                //                       });
                //            return;

                //        }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
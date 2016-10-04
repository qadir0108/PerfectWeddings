using PerfectWeddings.Business;
using PerfectWeddings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PerfectWeddings.App_Start
{
    public class IsAuthorized : ActionFilterAttribute
    {
        public PagePermissions Permission { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            var userModel = (UserModel)HttpContext.Current.Session["userModel"];
            if (userModel != null)
                if (!AuthManager.HasPermission(Permission, (int)userModel.UserId))
                {
                    var viewData = filterContext.Controller.ViewData;

                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                       {
                                               { "action", "Index" },
                                               { "controller", "Home" }
                                       });
                    return;

                }

            base.OnActionExecuting(filterContext);
        }
    }
}
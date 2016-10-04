using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaliberMatrix.App_Start
{
    public class SessionExpire : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {


            HttpContext ctx = HttpContext.Current;

            //ctx.Current.User.IsAuthencated;

            if (HttpContext.Current.Session["UserName"] == null)
            {
                var viewData = filterContext.Controller.ViewData;

                filterContext.Result =
          new RedirectToRouteResult(new RouteValueDictionary   
                                                            {  
                                                                    { "action", "Login" },  
                                                                    { "controller", "Account" },  
                                                                    { "returnUrl", filterContext.HttpContext.Request.RawUrl}  
                                                             });
                return;
                
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
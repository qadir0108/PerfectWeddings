using PerfectWeddings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfectWeddings.Helpers
{
    public class SessionObjects
    {
        public static bool isAuthenticated
        {
            set { HttpContext.Current.Session["IsAuthenticated"] = value; }
            get
            {
                try
                {
                    return HttpContext.Current.Session["IsAuthenticated"] != null &&
                           (Boolean) HttpContext.Current.Session["IsAuthenticated"];
                }
                catch (Exception ex)
                {
                    
                }

                return false;
            }
        }

        public static UserModel UserData
        {
            set { HttpContext.Current.Session["User"] = value; }
            get { return (UserModel) HttpContext.Current.Session["User"]; }
        }

    }
}
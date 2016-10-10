using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PerfectWeddings.ViewModels;
using PerfectWeddings.Data.Entities;
using System.Web.Security;

namespace PerfectWeddings.Controllers
{
    public class BaseController : Controller
    {

        public User LoggedInUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {

                    var UserName = User.Identity.Name;
                    return (User)Session["User"];
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Session.Abandon();
                    FormsAuthentication.RedirectToLoginPage();
                    return null;
                }
            }
        }
    }
}
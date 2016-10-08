using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PerfectWeddings.ViewModels;
using PerfectWeddings.Data.Entities;

namespace PerfectWeddings.Controllers
{
    public class BaseController : Controller
    {

        public User LoggedInUser
        {
            get
            {
                var user = (User)Session["User"];
                return user;
            }
        }

        /// <summary>
        /// Method:GetUserId
        /// </summary>
        /// <returns>Return UserModel</returns>
        public UserModel GetUserModel()
        {
            try
            {
                UserModel userModel = ((UserModel)Session["userModel"]);
                return userModel;
            }
            catch
            {
                throw;
            }
        }
    }
}
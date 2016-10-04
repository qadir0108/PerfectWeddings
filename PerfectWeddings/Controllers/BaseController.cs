using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PerfectWeddings.ViewModels;

namespace PerfectWeddings.Controllers
{
    public class BaseController : Controller
    {

        /// <summary>
        /// Method:GetProjectId
        /// </summary>
        /// <returns>Return ProjectId</returns>
        public int GetProjectId()
        {
            try
            {
                string val = Session["Index"].ToString();
                string[] value = val.Split('_');
                int SelectedProjectID = Convert.ToInt32(value[0]);
                return SelectedProjectID;
            }
            catch
            {
                throw;
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
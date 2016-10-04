using PerfectWeddings.App_Start;
using PerfectWeddings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfectWeddings.Controllers
{
    //[CustomAuthorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Method: Index
        /// Type: Index
        /// </summary>
        /// <returns></returns>
        [SessionExpire]
        public ActionResult Index()
        {
            //UserModel loginModel = GetLoginUserModel();
            //HomeDto model = DataAccess.Instance.HomeAction.GetHomeModel((int)loginModel.UserId, loginModel.CompanyKey);
            return View();
        }



        [SessionExpire]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [SessionExpire]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Method: LandingPage
        /// Type: Get
        /// </summary>
        /// <returns></returns>
        public ActionResult LandingPage()
        {
            ViewBag.Message = "Landing Page";

            return View();
        }

        #region Help Page
        public ActionResult HelpPage()
        {
            ViewBag.Message = "Help Page";

            return View();
        }
        #endregion
    }
}
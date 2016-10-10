using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Configuration;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Text;
using System.Collections.Generic;
using PerfectWeddings.ViewModels;
using PerfectWeddings.Business;
using PerfectWeddings.Data.EntityManager;
using PerfectWeddings.Helpers;
using PerfectWeddings.Data.Entities;
using System.Web.Security;
using PerfectWeddings.Common;

namespace PerfectWeddings.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// Method:Register
        /// Type:HttpGet
        /// </summary>
        /// <returns>return model</returns>
        /// 
        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterSupplier()
        {
            RegisterSupplierViewModel model = new RegisterSupplierViewModel();
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterSupplier(RegisterSupplierViewModel model)
        {
            try
            {
                EnquirerManager nuMgr = new EnquirerManager();
                nuMgr.Insert(new Enquirer()
                {
                    FirstName = model.firstName,
                    LastName = model.lastName,
                    EmailAddress = model.email,
                    PhoneNumber=model.phoneNo,
                    EnquiryCategory=model.category,
                    Message=model.message
                });

                return Json(new JsonResponse() { IsSucess = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new JsonResponse() { IsSucess = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            PerfectWeddings.ViewModels.RegisterViewModel model = new PerfectWeddings.ViewModels.RegisterViewModel();
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            try
            {
                NormalUserManager nuMgr = new NormalUserManager();
                nuMgr.Insert(new Data.Entities.NormalUser()
                {
                    UserName = model.Email,
                    FirstName = model.Name,
                    LastName = model.Name,
                    EmailAddress = model.Email,
                    WeddingDate = model.WeddingDate,
                    Type = Enums.UserTypeEnum.NormalUser,
                    Password = Encryption.Encrypt("w")
                });

                return Json(new JsonResponse() { IsSucess = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new JsonResponse() { IsSucess = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            PerfectWeddings.ViewModels.LoginModel model = new PerfectWeddings.ViewModels.LoginModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LoginSupplier(LoginModel model)
        {
            try
            {
                SupplierManager sMgr = new SupplierManager();
                var result = sMgr.Authenticate(model.UserName, model.Password);

                if(result != Enums.UserLoginStatusEnum.Authenticated)
                    throw new Exception(result.ToString());

                FormsAuthentication.SetAuthCookie(model.UserName, true);

                Session["User"] = sMgr.GetByUsername(model.UserName);

                return Json(new JsonResponse() { IsSucess = true }, JsonRequestBehavior.AllowGet);
            
            }
            catch (Exception ex)
            {
                return Json(new JsonResponse() { IsSucess = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LoginCouple(LoginModel model)
        {
            try
            {
                NormalUserManager nmgr = new NormalUserManager();
                var result = nmgr.Authenticate(model.UserName, model.Password);
                if (result != Enums.UserLoginStatusEnum.Authenticated)
                    throw new Exception(result.ToString());

                FormsAuthentication.SetAuthCookie(model.UserName, true);

                Session["User"] = nmgr.GetByUsername(model.UserName);

                return Json(new JsonResponse() { IsSucess = true }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new JsonResponse() { IsSucess = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [AjaxAuthorize]
        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();

            }
            catch (Exception) { }
            return RedirectToAction("Login", "Account");
        }

        #region Will be used in future
        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        #endregion
    }
}
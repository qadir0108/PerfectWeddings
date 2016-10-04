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

namespace PerfectWeddings.Controllers
{
    [CustomAuthorize]
    public class AccountController : Controller
    {
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("Login");
        }

        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }

        [AllowAnonymous]
        public async Task<ActionResult> LockScreen()
        {

            ViewBag.UserName = Session["UserName"].ToString();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LockScreen(string password)
        {
            //UserManager userManager = new UserManager();
            //var userObj = userManager.Authenticate(new LoginDto() { UserName = ViewBag.userName, Password = password });
            //ViewBag.UserName = Session["UserName"].ToString();
            //if (Session["Password"].ToString() != password)
            //{
            //    ViewBag.errorMsg = "Please provide correct password to unlock";
            //    return View();
            //}

            return View();
        }
        public ActionResult LogOutUser()
        {
            try
            {
                var userModel = ((UserModel)Session["userModel"]);
                //AuthManager.DecrementUserCount(Enums.Modules.Application, userModel.CompanyKey);

                Session.Clear();
                Session.Abandon();
                
            }
            catch (Exception) { }
            return RedirectToAction("Login", "Account");
        }
        
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            try
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                UserManager userManager = new UserManager();
                //var userObj = userManager.Authenticate(new LoginDto() { UserName = model.userName, Password = model.Password });
                
                //if (userObj.Error.HasError && userObj.isSuperAdmin == false)
                //{
                //    ViewBag.errorCredential = "1";
                //    return View("Login", model);
                //}
                //else if (!userObj.IsActive && userObj.isSuperAdmin == false)
                //{
                //    ViewBag.errorCredential = "3";
                //    return View("Login", model);
                //}

                // //MODULE PERMISSION CODE
                //else if ((userObj.isSuperAdmin == false) && (!AuthManager.HasModulePermssion(Enums.Modules.Application, Convert.ToString(userObj.CompanyGuid), Convert.ToString(userObj.UserGuid))))
                //{
                //    ViewBag.errorCredential = "6";
                //    return View("Login", model);
                //}

                //else if(!userObj.isSuperAdmin)
                //{
                  
                //    TempData["loginSuccessfully"] = "2";
                //    SessionObjects.isAuthenticated = true;
                //    var userModel = new UserModel()
                //    {
                //        Email = userObj.Email,
                //        FirstName = userObj.FirstName,
                //        LastName = userObj.LastName,
                //        IsActive = userObj.IsActive,
                //        IsOwner = userObj.IsOwner,
                //        UserName = userObj.UserName,
                //        CompanyKey = userObj.CompanyKey,
                //        CompanyName = userObj.CompanyName,
                //        Password = userObj.Password,
                //        UserId = userObj.Id,
                //        Image = userObj.Image,
                //        ThemeType = userObj.ThemeType,
                //        Title = userObj.Title,
                //        CompanyGuid = userObj.CompanyGuid.ToString(),
                //        UserGuid = userObj.UserGuid.ToString()
                //    };
                //    #region
                //    //var userRoles = DataAccess.Instance.UserRole.GetAll().Where(x => x.usr_key == userModel.UserId).ToList();
                //    //string Roles = "";
                //    //foreach (var item in userRoles)
                //    //{
                //    //    Roles += Convert.ToString(item.qmatrix_role.name) + " - ";
                //    //}
                //    //Session["Roles"] = Roles;
                //    #endregion

                //    Session["userModel"] = userModel;
                //    Session["UserName"] = userModel.UserName;
                //    Session["Password"] = userModel.Password;
                //    Session["FirstName"] = userModel.FirstName;
                //    Session["LastName"] = userModel.LastName;
                //    Session["CompanyKey"] = userModel.CompanyKey;
                //    Session["ThemeType"] = userModel.ThemeType;
                //    Session["Image"] = userModel.Image;
                //    Session["IsOwner"] = userModel.IsOwner;

                //    Session["IsSuperAdmin"] = null;

                //    Session["CompanyGuid"] = userModel.CompanyGuid;
                //    Session["UserGuid"] = userModel.UserGuid;

                //    var userPref = DataAccess.Instance.ThemePreferenceActions.GetAll().Where(x => x.usr_key == userModel.UserId).FirstOrDefault();
                //    Session["UserPref"] = userPref;
                //    if (!string.IsNullOrEmpty(userObj.UserName))
                //    {
                //        string sqlFormattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //        var historyModel = new cmatrix_login_history()
                //        {
                //            lgh_login_time = Convert.ToDateTime(sqlFormattedDate),
                //            lgh_ip = userObj.FirstName,
                //            lgh_usr_key = Convert.ToInt32(userModel.UserId),
                //        };

                //        DataAccess.Instance.LoginHistory.Add(historyModel, Guid.Empty);
                //    }
                //    Session["UserKey"] = ((UserModel)Session["userModel"]).UserId;
                //    var ISUserExist = DataAccess.Instance.UserActions.GetAll().Where(x => x.usr_key == userObj.Id).ToList().Select(x => x.usr_is_aggreed).FirstOrDefault();

                //    if (ISUserExist == null || (bool)ISUserExist == false)
                //    {
                //        Session["UserId"] = userObj.Id;
                //        return PartialView("_UserEulaAgreement");
                //    }
                //    return RedirectToAction("Index", "Home");
                //}

                //else if (userObj.isSuperAdmin)
                //{
                    
                //    Session["IsSuperAdmin"] = "superadmin";
                //    return RedirectToAction("ModulePermission", "UserManagement");
                //}
                //else
                //{
                //    ViewBag.errorCredential = "4";
                //    return View("Login", model);
                //}

            }
            catch (Exception ex)
            {
                ViewBag.errorCredential = "4";
                return View("Login", model);
            }

            return View("Login", model);
        }

        [AllowAnonymous]
        public ActionResult TermsAndConditions()
        {
            return View("TermsAndConditions");
        }

        [AllowAnonymous]
        public ActionResult PrivacyPolicy()
        {
            return View("PrivacyPolicy");
        }
        
        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            var user = await UserManager.FindByIdAsync(await SignInManager.GetVerifiedUserIdAsync());
            if (user != null)
            {
                var code = await UserManager.GenerateTwoFactorTokenAsync(user.Id, provider);
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        /// <summary>
        /// Method:Register
        /// Type:HttpGet
        /// </summary>
        /// <returns>return model</returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            PerfectWeddings.ViewModels.RegisterViewModel model = new PerfectWeddings.ViewModels.RegisterViewModel();
            return View(model);
        }

        public JsonResult CheckExistingEmail(string userName)
        {
            bool ifEmailExist = false;
            int ISUserExist = 0;
            try
            {
                //ISUserExist = DataAccess.Instance.UserActions.GetAll().Where(x => x.usr_user_name == userName).ToList().Count();
                //if (ISUserExist > 0)
                //{

                //    ifEmailExist = true;
                //}

                return Json(!ifEmailExist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
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
                    WeddingDate = model.WeddingDate
                });

                return Json(new JsonResponse() { IsSucess = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new JsonResponse() { IsSucess = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

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
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
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
        // GET: /Account/SystemError
        [AllowAnonymous]
        public ActionResult SystemError()
        {
            return View();
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
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }
        [AllowAnonymous]
        public JsonResult GetStatusOfUser(string company)
        {
            List<string> CompanyInfo = new List<string>();
            //Get status of user about comopany that it is owner or employee
            dynamic value = 1;
            //try
            //{
            //    if (!string.IsNullOrEmpty(company))
            //    {
            //        var Company = DataAccess.Instance.Company.GetAll().Where(c => c.cmp_name == company && (c.cmp_is_deleted == null || c.cmp_is_deleted == false)).FirstOrDefault();
            //        if (Company != null)
            //        {
            //            value = DataAccess.Instance.Company.GetAll().Where(c => c.cmp_name == company && (c.cmp_is_deleted == null || c.cmp_is_deleted == false)).Select(x => new
            //            {
            //                CompanyAddress = x.cmp_address,
            //                CompanyPhone = x.cmp_phone,
            //              // Email = x.cmp_email
            //            });

            //        }
            //        else
            //        {
            //            value = "Owner";

            //        }
            //    }
            //    else
            //    {
            //        value = DataAccess.Instance.Company.GetAll().Where(c => c.cmp_name == company && (c.cmp_is_deleted == null || c.cmp_is_deleted == false)).Select(x => new
            //        {
            //            CompanyAddress = x.cmp_address,
            //            CompanyPhone = x.cmp_phone,
            //            //Email = x.cmp_email
            //        });
            //    }

            //}
            //catch (Exception ex)
            //{
            //    value = "3";
            //}
            return Json(value, JsonRequestBehavior.AllowGet);

        }
        
        public static void SendEmailToAdmin(string Email, int Id)
        {
            string ServerURL = WebConfigurationManager.AppSettings["ServerURL"].ToString();
            string To = WebConfigurationManager.AppSettings["SupportEmail"].ToString();
            if (ServerURL == null || ServerURL == "")
            {
                ServerURL = "PerfectWeddings.com";
            }
            if (To == null || To == "")
            {
                To = "support@caliber-technologies.com";
            }
            string ID = UtilityHelper.Encrypt(Id.ToString());
            string Subject = "Quality Matrix Sign Up";
            string body = "New user has been registered, check detail below <br/><br/>";
            body += "Email: " + Email + " <br/><br/>";
            body += "Please Copy below URL and Paste on Browser to active his account <br/><br/>";
            body += "http://" + ServerURL + "/Company/ActivateUser.aspx?Activateid=" + ID;

            string errorMessage = "";
            UtilityHelper.SendEmail(To, Subject, body, out errorMessage);
        }
        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public JsonResult IsUserExist(string userName)
        {
            int ISUserExist = 0;
            string value = "";
           // ISUserExist = DataAccess.Instance.UserActions.GetAll().Where(x => x.usr_user_name == userName).ToList().Count();
            if (ISUserExist > 0)
            {

                value = "1";
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
           
        }
        #endregion
    }
}
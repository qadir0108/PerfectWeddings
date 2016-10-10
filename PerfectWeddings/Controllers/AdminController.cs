using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PerfectWeddings.ViewModels;
using PerfectWeddings.Data.Entities;
using System.Web.Security;
using PerfectWeddings.Helpers;
using PerfectWeddings.Business;

namespace PerfectWeddings.Controllers
{
    [Authorize]
    [AjaxAuthorize]
    [IsPermittedActionFilter(Permission = PagePermissions.Admin)]
    public class AdminController : BaseController
    {
        [HttpGet]
        public ActionResult CreateSupplierAccount()
        {
            return View();
        }
    }
}
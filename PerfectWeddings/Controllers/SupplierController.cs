using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PerfectWeddings.ViewModels;
using PerfectWeddings.Enums;
using PerfectWeddings.Data.EntityManager;
using PerfectWeddings.Data.Entities;
using PerfectWeddings.Helpers;

namespace PerfectWeddings.Controllers
{
    [AjaxAuthorize]
    public class SupplierController : BaseController
    {
        public ActionResult Dashboard()
        {
            //SupplierManager sMgr = new SupplierManager();
            //SupplierAdvertisementManager saMgr = new SupplierAdvertisementManager();

            //var Supplier = sMgr.GetById(LoggedInUser.Id);

            //Supplier.Ads.Add(
            //    new SupplierAdvertisement()
            //    {
            //        Title = "Hello", // model.title
            //        Supplier = Supplier
            //    });

            return View();
        }

        [HttpPost]
        public ActionResult AddListing(ListingViewModel model)
        {
            //SupplierCategoryEnum actualValue = (SupplierCategoryEnum)Enum.Parse(typeof(SupplierCategoryEnum), model.Category);

            return View();
        }

     
        public ActionResult AddListing()
        {
            ListingViewModel lVm = new ListingViewModel();
            return PartialView("_AddListing",lVm);
        }
    }
}
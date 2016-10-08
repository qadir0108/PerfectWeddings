using System.Web;
using System.Web.Optimization;

namespace PerfectWeddings
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region PerfectWeddings
            bundles.Add(new StyleBundle("~/PerfectWeddings/CSS").Include(
                "~/css/fonts1.css",
                "~/css/fonts2.css",
                "~/css/font-awesome.min.css",
                "~/css/bootstrap.min.css",
                "~/css/style.css",
                "~/css/owl.carousel.css",
                "~/css/owl.theme.css",
                "~/css/owl.transitions.css",
                "~/css/fontello.css",
                "~/css/jquery-ui.css",
                "~/css/toastr.min.css",
                "~/css/pw.css"
                ));

            bundles.Add(new ScriptBundle("~/PerfectWeddings/JS").Include(
                "~/js/jquery-1.11.1.js", 
                "~/js/jquery-1.11.3.min.js",
                // "~/js/jquery.validate.min.js", Using bootstrap validations now
                // "~/js/additional-methods.min.js",  Using bootstrap validations now
                "~/js/validator.min.js",
                "~/js/bootstrap.min.js",
                "~/js/jquery.flexnav.js",
                "~/js/navigation.js",
                "~/js/owl.carousel.min.js",
                "~/js/slider.js",
                "~/js/jquery.sticky.js",
                 "~/js/header-sticky.js",
                 "~/js/toastr.min.js",
                 "~/js/jquery.blockUI.js",
                 "~/js/pw.js",
                 "~/js/pw.security.js",
                 "~/js/pw.maps.js"
            ));

            bundles.Add(new ScriptBundle("~/PerfectWeddings/jQueryUI").Include(
                "~/js/jquery-ui.js"
            ));

            #endregion

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            //BundleTable.EnableOptimizations = true;
        }
    }
}

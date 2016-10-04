using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfectWeddings.HtmlHelpers
{
    public static class MiscHelpers
    {

        #region Helpers for UI

        public static string StripTags(string html)
        {

            if (string.IsNullOrEmpty(html))
            {
                return string.Empty;
            }
            System.Text.RegularExpressions.Regex objRegEx = new System.Text.RegularExpressions.Regex(@"<[^>]+>|&nbsp;");

            return objRegEx.Replace(html, "");
        }

        public static string GetLayout(this HtmlHelper html)
        {
            string layout = "~/Views/Shared/_Layout.cshtml";
            if (HttpContext.Current.Session["ThemeType"] != null && HttpContext.Current.Session["ThemeType"].ToString() == "2")
                layout = "~/Views/Shared/_Layout2.cshtml";
            return layout;
        }

            #endregion

    }
}
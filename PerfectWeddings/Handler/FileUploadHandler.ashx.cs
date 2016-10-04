using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace QMatrix.Handler
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<string> AttachmentName = new List<string>();
            List<string> ActualName = new List<string>();
            List<int> FileSize = new List<int>();
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string UniqueName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    AttachmentName.Add(UniqueName);
                    ActualName.Add(file.FileName);
                    FileSize.Add(file.ContentLength);
                    if (context.Request["Type"] == "US")
                    {
                        string fname = context.Server.MapPath("~/Uploads/UserStoriesAttachments/" + UniqueName);
                        file.SaveAs(fname);
                    }
                    else if (context.Request["Type"] == "Re")
                    {
                        string fname = context.Server.MapPath("~/Uploads/RequirmentsAttachments/" + UniqueName);
                        file.SaveAs(fname);
                    }
                    else if (context.Request["Type"] == "BL")
                    {
                        string fname = context.Server.MapPath("~/Uploads/BacklogAttachments/" + UniqueName);
                        file.SaveAs(fname);

                    }

                }
                context.Response.Write("File(s) Uploaded Successfully!");
                HttpContext.Current.Session["AttachmentName"] = AttachmentName;
                HttpContext.Current.Session["FileActualName"] = ActualName;
                HttpContext.Current.Session["FileSize"] = FileSize;
            }
            else
            {
                context.Response.Write("No File Found");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
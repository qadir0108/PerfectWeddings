using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Business
{
    public class SessionInfo
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
        public int CompanyId { get; set; }
        public bool? IsOwner { get; set; }

        // Theme Property
        public string Color { get; set; }
        public string ThemeStyle { get; set; }
        public string Layout { get; set; }
        public string Header { get; set; }
        public string TopDropDown { get; set; }
        public string SideBarMode { get; set; }
        public string SideBarMenu { get; set; }
        public string SideBarStyle { get; set; }
        public string SideBarPosition { get; set; }

        public string TopMenuStyle { get; set; }
        public string TopMenuMode { get; set; }
        public string MegaMenuStyle { get; set; }
        public string MegaMenuMode { get; set; }

    }
}

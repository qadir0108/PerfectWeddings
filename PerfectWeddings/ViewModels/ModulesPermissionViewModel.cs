using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfectWeddings.ViewModels
{
    public class ModulesPermissionViewModel
    {
        public int ModuleID { get; set; }
        public String Module { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ModulesUsers> Users { get; set; }
        public ModulesPermissionViewModel() {

            Users = new List<ModulesUsers>();
        }
    }


    public class ModulesUsers
    {
        public string UserKey { get; set; }
    }
}
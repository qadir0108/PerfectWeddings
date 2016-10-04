using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum MethodToContactEnum
    {
        [Description("Phone")]
        Phone = 1,

        [Description("Email")]
        Email = 2,
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum UserLoginStatusEnum
    {
        [Description("Authenticated")]
        Authenticated = 1,
        [Description("Not Authenticated")]
        NotAuthenticated = 2,
        [Description("Expired")]
        Expired = 3,
        [Description("Not Found")]
        NotFound = 4
    }
}

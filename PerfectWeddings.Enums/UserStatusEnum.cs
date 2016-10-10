using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum UserStatusEnum
    {
        [Description("Active")]
        Active = 0,
        [Description("DeActive")]
        DeActive = 1,
        [Description("Expired")]
        Expired = 2
    }
}

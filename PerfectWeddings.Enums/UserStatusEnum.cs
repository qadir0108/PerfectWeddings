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
        Active = 1,
        [Description("DeActive")]
        DeActive = 2,
        [Description("Expired")]
        Expired = 3
    }
}

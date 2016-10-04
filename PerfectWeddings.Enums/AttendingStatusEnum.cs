using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum AttendingStatusEnum
    {
        [Description("Unsure")]
        Unsure = 1,
        [Description("Attending")]
        Attending = 2,
        [Description("Declined")]
        Declined = 3
    }
}

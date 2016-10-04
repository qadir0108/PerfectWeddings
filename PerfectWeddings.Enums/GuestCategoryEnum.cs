using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum GuestCategoryEnum
    {
        [Description("Brid's Family")]
        BridsFamily = 1,
        [Description("Groom's Family")]
        GroomsFamily = 2,
        [Description("Friends")]
        Friends = 3,
        [Description("Co-workers")]
        CoWorkers = 4
    }
}

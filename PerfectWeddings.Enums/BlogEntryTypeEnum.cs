using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum BlogEntryTypeEnum
    {
        [Description("Normal")]
        Normal = 1,
        [Description("Real Weddings")]
        RealWeddings = 2
    }
}

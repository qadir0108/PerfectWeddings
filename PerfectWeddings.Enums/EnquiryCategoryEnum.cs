using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum EnquiryCategoryEnum
    {
        [Description("Couple")]
        Couple = 0,
        [Description("Supplier")]
        Supplier = 1,
        [Description("Advertisement")]
        Advertisement = 2,
        [Description("Suggestion")]
        Suggestion = 3
    }
}

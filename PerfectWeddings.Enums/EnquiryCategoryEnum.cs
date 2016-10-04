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
        Couple = 1,
        [Description("Supplier")]
        Supplier = 2,
        [Description("Advertisement")]
        Advertisement = 3,
        [Description("Suggestion")]
        Suggestion = 4
    }
}

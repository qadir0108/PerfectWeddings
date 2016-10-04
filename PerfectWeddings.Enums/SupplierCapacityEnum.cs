using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum SupplierCapacityEnum
    {
        [Description("0 - 99")]
        NintyNine = 1,

        [Description("100 - 199")]
        OneNintyNine = 2,

        [Description("200 - 299")]
        TwoNintyNine = 3,

        [Description("300 - 399")]
        ThreeNintyNine = 4,

        [Description("400 - 499")]
        FourNintyNine = 5,

        [Description("500 - 599")]
        FiveNintyNine = 6,

    }
}

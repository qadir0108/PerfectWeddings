using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum SupplierAccountTypeEnum
    {
        [Description("Trial- 1 Month Free (No Charge)")]
        Trial = 1,

        [Description("Monthly Direct Debit or Payment to be paid directly to bank")]
        Monthly = 2,

        [Description("12 Months Subscription")]
        Yearly = 3

    }
}

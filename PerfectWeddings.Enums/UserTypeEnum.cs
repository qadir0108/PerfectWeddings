using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum UserTypeEnum
    {
        [Description("Normal Client User, Couple")]
        NormalUser = 1,
        [Description("Supplier")]
        Supplier = 2,
        [Description("Employee Admin")]
        Employee = 3,
        [Description("Super Admin")]
        SuperAdmin = 4
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum Modules : int
    {
        Application = 1, // Do not change the ID of this enum.

        [Description("Portfolio Management")]
        PortfolioManagement = 2,

        [Description("Process Management")]
        ProcessManagement = 3,

        [Description("Test Execution")]
        TestExecution = 4,

        [Description("Tracking and Monitoring")]
        TrackMonitoring = 5,

        [Description("Release Management")]
        ReleaseManagement = 6,

        [Description("Support and Maintenance")]
        SupportMaintenance = 7

    }
}

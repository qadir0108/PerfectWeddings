using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum SocialAccountType
    {
        [Description("Facebook")]
        Facebook = 1,

        [Description("Google")]
        Google = 2,

        [Description("Instagram")]
        Instagram = 3,

        [Description("Flicker")]
        Flicker = 4,

        [Description("Youtube")]
        Youtube = 5,

        [Description("Twitter")]
        Twitter = 6,

        [Description("LinkedIn")]
        LinkedIn = 7,

        [Description("Pinterest")]
        Pinterest = 8
                    
    }
}

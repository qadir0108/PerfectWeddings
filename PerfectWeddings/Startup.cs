using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PerfectWeddings.Startup))]

namespace PerfectWeddings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

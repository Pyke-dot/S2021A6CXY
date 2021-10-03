using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S2021A6CXY.Startup))]

namespace S2021A6CXY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

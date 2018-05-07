using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Challenge.Api.Startup))]

namespace Challenge.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

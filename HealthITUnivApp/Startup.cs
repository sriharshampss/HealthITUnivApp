using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthITUnivApp.Startup))]
namespace HealthITUnivApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirlineManagementWebApplication.Startup))]
namespace AirlineManagementWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

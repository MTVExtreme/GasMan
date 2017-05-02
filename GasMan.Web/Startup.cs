using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GasMan.Web.Startup))]
namespace GasMan.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

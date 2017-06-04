using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Panacea.Events.Web.Startup))]
namespace Panacea.Events.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

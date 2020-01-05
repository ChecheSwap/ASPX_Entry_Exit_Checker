using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(checadorAsp.Startup))]
namespace checadorAsp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

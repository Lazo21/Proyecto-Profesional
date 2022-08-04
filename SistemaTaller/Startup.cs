using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaTaller.Startup))]
namespace SistemaTaller
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

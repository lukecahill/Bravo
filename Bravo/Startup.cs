using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bravo.Startup))]
namespace Bravo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

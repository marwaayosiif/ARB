using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ARB.Startup))]
namespace ARB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

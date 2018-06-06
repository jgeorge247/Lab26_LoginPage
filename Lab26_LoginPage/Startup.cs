using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab26_LoginPage.Startup))]
namespace Lab26_LoginPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

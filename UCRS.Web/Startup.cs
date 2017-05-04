using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UCRS.Web.Startup))]
namespace UCRS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

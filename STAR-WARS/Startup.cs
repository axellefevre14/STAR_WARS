using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(STAR_WARS.Startup))]
namespace STAR_WARS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

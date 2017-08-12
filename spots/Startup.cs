using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(spots.Startup))]
namespace spots
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EastIndia.Startup))]
namespace EastIndia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

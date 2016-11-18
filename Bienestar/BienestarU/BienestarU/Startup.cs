using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BienestarU.Startup))]
namespace BienestarU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

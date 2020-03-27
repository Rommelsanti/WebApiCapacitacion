using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiCapacitacion.Startup))]
namespace WebApiCapacitacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

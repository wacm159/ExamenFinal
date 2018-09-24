using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenFinal.Startup))]
namespace ExamenFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

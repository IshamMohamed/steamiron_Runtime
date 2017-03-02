using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(steamironService.Startup))]

namespace steamironService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestRoomApp.Startup))]
namespace RestRoomApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

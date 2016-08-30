using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SimpleChatAPI.Startup))]

namespace SimpleChatAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}
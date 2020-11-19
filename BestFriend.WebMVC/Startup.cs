using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BestFriend.WebMVC.Startup))]
namespace BestFriend.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FreshFindsBlog.UI.Startup))]
namespace FreshFindsBlog.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

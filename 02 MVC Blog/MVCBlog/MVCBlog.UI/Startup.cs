using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBlog.UI.Startup))]
namespace MVCBlog.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

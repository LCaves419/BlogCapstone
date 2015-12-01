using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBlog.UI.Startup))]
namespace MVCBlog.UI
{
    //LJ- this partial is paert of Startup.Auth.cs
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

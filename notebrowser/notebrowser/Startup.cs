using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(notebrowser.Startup))]
namespace notebrowser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

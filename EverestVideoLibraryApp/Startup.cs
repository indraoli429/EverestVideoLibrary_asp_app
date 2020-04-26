using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EverestVideoLibraryApp.Startup))]
namespace EverestVideoLibraryApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

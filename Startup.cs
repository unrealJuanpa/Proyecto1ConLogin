using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyecto1ConLogin.Startup))]
namespace Proyecto1ConLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CurrysToGo.Startup))]
namespace CurrysToGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

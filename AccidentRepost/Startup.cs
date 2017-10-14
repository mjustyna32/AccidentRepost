using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccidentRepost.Startup))]
namespace AccidentRepost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

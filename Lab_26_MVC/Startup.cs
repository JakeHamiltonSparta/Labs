using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_26_MVC_Again_Again.Startup))]
namespace Lab_26_MVC_Again_Again
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

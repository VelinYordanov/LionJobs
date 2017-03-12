using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LionJobs.Web.Startup))]
namespace LionJobs.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exam1.Startup))]
namespace Exam1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

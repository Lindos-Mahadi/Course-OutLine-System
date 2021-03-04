using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(New_Course_OutLine.Startup))]
namespace New_Course_OutLine
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

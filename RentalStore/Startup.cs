using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc2019.Startup))]
namespace mvc2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

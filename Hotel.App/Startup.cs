using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel.App.Startup))]
namespace Hotel.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}

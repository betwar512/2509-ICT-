using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantUnitTest.Startup))]
namespace RestaurantUnitTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

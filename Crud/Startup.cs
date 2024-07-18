using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crud.Startup))]
namespace Crud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

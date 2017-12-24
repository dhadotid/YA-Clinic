using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YA_Clinic.Startup))]
namespace YA_Clinic
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

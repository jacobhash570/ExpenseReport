using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpenseReport.WebMVC.Startup))]
namespace ExpenseReport.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

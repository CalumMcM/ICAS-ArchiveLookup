using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArchiveLookup.ICAS.com.Startup))]
namespace ArchiveLookup.ICAS.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}

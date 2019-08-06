using System.Web.Http;


namespace ArchiveLookup.ICAS.com.Controllers
{
    public class LoginController : ApiController
    {
		public string Post([FromBody]string pin)
		{
			switch (pin)
			{
				case "1234": return "ArchiveLookup";
				case "1313": return "Finance";
				default: return "error";
			}
		}
    }
}

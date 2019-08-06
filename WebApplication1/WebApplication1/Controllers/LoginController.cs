using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArchiveLookup.ICAS.com.Controllers
{
    public class LoginController : ApiController
    {
		public bool Post([FromBody]string pin)
		{
			return false;
		}
    }
}

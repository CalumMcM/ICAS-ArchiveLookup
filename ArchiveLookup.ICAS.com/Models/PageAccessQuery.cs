using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class PageAccessQuery: Query
	{
		public string UserName { get; set; }
		public string PageName { get; set; }

		public override object ToDapperParameter()
		{
			return new
			{
				UserName = UserName,
				PageName = PageName
			};
		}

		public override string getDatabasePrefix(string header)
		{
			throw new NotImplementedException();
		}
	}
}
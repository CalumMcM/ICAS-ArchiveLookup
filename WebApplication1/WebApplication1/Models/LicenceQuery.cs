using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class LicenceQuery
	{
		public string ID { get; set; }
		public string FIRM_ID { get; set; }
		public string FIRM_NO { get; set; }
		public string SOURCE_CODE { get; set; }

		public Object ToDapperParameter()
		{
			return new {
				ID = ID,
				FIRM_NO = FIRM_NO,
				FIRM_ID = FIRM_ID,
				SOURCE_CODE = SOURCE_CODE
			};
		}
		public string getDatabasePrefix(string header)
		{
			switch (header)
			{
				 case "ID": return "n.";
				case "FIRM_NO": return "ar.";
				case "FIRM_ID": return "si.";
				case "SOURCE_CODE": return "a.";
			}
			return "";
		}
	}

}
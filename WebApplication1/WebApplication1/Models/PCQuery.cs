using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class PCQuery
	{
		public string ID { get; set; }
		public string MAJOR_KEY { get; set; }
		public string FIRST_NAME { get; set; }
		public string MIDDLE_NAME { get; set; }
		public string SORT_NAME { get; set; }
		public string LAST_NAME { get; set; }
		public string DESCRIPTION { get; set; }
		public string ACTIVITY_TYPE { get; set; }
		public string FIRM_ID { get; set; }
		public string FIRM_NAME { get; set; }
		public string FIRM_NO { get; set; }
		public string SOURCE_CODE { get; set; }

		public Object ToDapperParameter()
		{
			return new {
				ID = ID,
				MAJOR_KEY = MAJOR_KEY,
				FIRST_NAME = FIRST_NAME,
				MIDDLE_NAME = MIDDLE_NAME,
				SORT_NAME = SORT_NAME,
				LAST_NAME = LAST_NAME,
				DESCRIPTION = DESCRIPTION,
				ACTIVITY_TYPE = ACTIVITY_TYPE,
				FIRM_NO = FIRM_NO,
				FIRM_ID = FIRM_ID,
				FIRM_NAME = FIRM_NAME,
				SOURCE_CODE = SOURCE_CODE
			};
		}
		public string getDatabasePrefix(string header)
		{
			switch (header)
			{
				 case "ID": return "n.";
				case "MAJOR_KEY": return "n.";
				case "FIRST_NAME": return "n.";
				case "MIDDLE_NAME": return "n.";
				case "SORT_NAME": return "n.";
				case "LAST_NAME": return "n.";
				case "DESCRIPTION": return "a.";
				case "ACTIVITY_TYPE": return "a.";
				case "FIRM_NO": return "ar.";
				case "FIRM_ID": return "si.";
				case "FIRM_NAME": return "si.";
				case "SOURCE_CODE": return "a.";
			}
			return "";
		}
	}

}
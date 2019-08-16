using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class LicenceQuery: Query
	{
		public string ID;
		public string MAJOR_KEY;
		public string FIRST_NAME;
		public string MIDDLE_NAME;
		public string SORT_NAME;
		public string LAST_NAME;
		public string DESCRIPTION;
		public string ACTIVITY_TYPE;
		public string FIRM_ID;
		public string FIRM_NAME;
		public string FIRM_NO;
		public string SOURCE_CODE;

		public override Object ToDapperParameter()
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
		public override string getDatabasePrefix(string header)
		{
			switch (header)
			{
				 case "ID": return "n.";
				case "MAJOR_KEY": return "n.";
				case "FIRST_NAME": return "n.";
				case "MIDDLE_NAME": return "n.";
				case "SORT_NAME": return "f.";
				case "LAST_NAME": return "n.";
				case "DESCRIPTION": return "a.";
				case "ACTIVITY_TYPE": return "a.";
				case "FIRM_NO": return "ar.";
				case "FIRM_ID": return "si.";
				case "SOURCE_CODE": return "a.";
			}
			return "";
		}
		public override string queryGenerator()
		{
			var properties = this.GetType().GetProperties();
			var propertyName = properties[0].Name;
			var query = "";
			for (var i = 0; i < properties.Length; i++)
			{
				if (properties[i].GetValue(this) != null)
				{
					query = query + " AND " + this.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
				}
			}

			return query;
		}
	}

}
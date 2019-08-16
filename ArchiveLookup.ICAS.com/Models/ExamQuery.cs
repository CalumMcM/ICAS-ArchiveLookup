using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class ExamQuery: Query
	{
		public string STUDENT_ID;
		public string MAJOR_KEY;
		public string FIRST_NAME;
		public string MIDDLE_NAME;
		public string LAST_NAME;
		public string FIRM_NAME;
		public string FIRM_NO;

		public override Object ToDapperParameter()
		{
			return new {
				MAJOR_KEY = MAJOR_KEY,
				FIRST_NAME = FIRST_NAME,
				MIDDLE_NAME = MIDDLE_NAME,
				LAST_NAME = LAST_NAME,
				FIRM_NO = FIRM_NO,
				FIRM_NAME = FIRM_NAME,
				STUDENT_ID = STUDENT_ID
			};
		}
		public override string getDatabasePrefix(string header)
		{
			switch (header)
			{
				case "MAJOR_KEY": return "n.";
				case "FIRST_NAME": return "n.";
				case "MIDDLE_NAME": return "n.";
				case "LAST_NAME": return "n.";
				case "DESCRIPTION": return "a.";
				case "FIRM_NO": return "ar.";
				case "STUDENT_ID": return "cr.";
			}
			return "";
		}
	}

}
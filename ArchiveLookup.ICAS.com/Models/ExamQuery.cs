using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class ExamQuery
	{
		public string STUDENT_ID { get; set; }
		public string MAJOR_KEY { get; set; }
		public string FIRST_NAME { get; set; }
		public string MIDDLE_NAME { get; set; }
		public string LAST_NAME { get; set; }
		public string FIRM_NAME { get; set; }
		public string FIRM_NO { get; set; }

		public Object ToDapperParameter()
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
		public string getDatabasePrefix(string header)
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
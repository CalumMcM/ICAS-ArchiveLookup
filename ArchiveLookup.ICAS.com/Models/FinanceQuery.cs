using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class FinanceQuery: Query
	{
		public string ID;
		public string MAJOR_KEY;
		public string STUDENT_NO;
		public string MAIN_FIRM_NO;
		public string REFERENCE_NUM;

		public override Object ToDapperParameter()
		{
			return new {
				ID = ID,
				MAJOR_KEY = MAJOR_KEY,
				STUDENT_NO = STUDENT_NO,
				MAIN_FIRM_NO = MAIN_FIRM_NO,
				REFERENCE_NUM = REFERENCE_NUM
			};
		}
		public override string getDatabasePrefix(string header)
		{
			switch (header)
			{
				case "ID": return "n.";
				case "MAJOR_KEY": return "n.";
				case "STUDENT_NO": return "si.";
				case "MAIN_FIRM_NO": return "f.";
				case "REFERENCE_NUM": return "i.";
			}
			return "";
		}
	}

}
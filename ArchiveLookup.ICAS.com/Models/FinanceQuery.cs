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
		/*
		 Returns: An object which converts the field name which has
		 been used in the code with the counterpart of that field 
		 name in the database 
		*/
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
		/*
		 Inputs: header - a Field Name for the query of type string
		 Returns: database prefix for that field name of type string
		 Remarks: For the given header it should get the prefix the
		 given field name belongs to for the query 
		*/
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
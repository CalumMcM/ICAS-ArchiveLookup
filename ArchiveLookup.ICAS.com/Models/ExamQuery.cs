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
		/*
		 Returns: An object which converts the field name which has
		 been used in the code with the counterpart of that field 
		 name in the database 
		*/ 
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
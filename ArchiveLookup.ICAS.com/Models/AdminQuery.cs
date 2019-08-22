using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class AdminQuery: Query
	{
		public string UserName;
		public string PageName;
		public string AdminAction;
		/*
	 Returns: An object which converts the field name which has
	 been used in the code with the counterpart of that field 
	 name in the database 
	*/
		public override Object ToDapperParameter()
		{
			return new
			{
				UserName = UserName,
				PageName = PageName
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
				case "UserName": return "";
			}
			return "";
		}
		public string getAction()
		{
			return this.AdminAction;
		}
	}
}
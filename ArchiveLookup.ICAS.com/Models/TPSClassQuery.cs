using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class TPSClassQuery
	{
		public string CLASS;
		public Nullable<DateTime> START_DATE;
		public Nullable<DateTime> END_DATE;
		/*
		 Returns: An object which converts the field name which has
		 been used in the code with the counterpart of that field 
		 name in the database 
		*/
		public Object ToDapperParameter()
		{
			return new {
				START_DATE = START_DATE,
				END_DATE = END_DATE,
				CLASS = CLASS
			};
		}
	}

}
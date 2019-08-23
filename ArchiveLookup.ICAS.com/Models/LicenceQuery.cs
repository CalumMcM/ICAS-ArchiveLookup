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
		/*
		 Returns: A string, in the SQL format, containing any criteria to filter the search 
		*/
		public override string queryGenerator()
		{
			var properties = this.GetType().GetFields();
			var query = "";
			bool began = false;
			for (var i = 0; i < properties.Length; i++)
			{
				if (properties[i].GetValue(this) != null)
				{
					var type = properties[i].GetValue(this);
					if (type is string)
					{
						if (properties[i].Name == "SORT_NAME")
						{
							if (!began)
							{
								query = query + "WHERE " + this.getDatabasePrefix(properties[i].Name) + properties[i].Name + " like '%'+@" + properties[i].Name +"+'%'";
								began = true;
							}
							else
							{
								query = query + " AND " + this.getDatabasePrefix(properties[i].Name) + properties[i].Name + " like '%'+@" + properties[i].Name + "+'%'";
							}
						}
						else if ((string)(properties[i].GetValue(this)) != "" && !began)
						{
							query = query + "WHERE " + this.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
							began = true;
						}
						else if (((string)properties[i].GetValue(this)) != "")
						{
							query = query + " AND " + this.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
						}
					}
				}
			}
			return query;
		}
	}

}
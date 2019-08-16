using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public abstract class Query
	{
		public abstract Object ToDapperParameter();
		public abstract string getDatabasePrefix(string header);
		/*
		 Returns: A string, in the SQL format, containing any criteria to filter the search 
		*/
		public virtual string queryGenerator()
		{
			var properties = this.GetType().GetFields();
			var query = "";
			bool began = false;
			for (var i = 0; i < properties.Length; i++)
			{
				if ((string) (properties[i].GetValue(this)) != "" && properties[i].GetValue(this) != null && !began)
				{
					query = query + "WHERE " + this.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
					began = true;
				}
				else if (((string) properties[i].GetValue(this)) != "" && properties[i].GetValue(this) != null)
				{
					query = query + " AND " + this.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
				}
			}
			return query;
		}
	}
}
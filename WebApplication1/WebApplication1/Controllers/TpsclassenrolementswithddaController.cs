using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArchiveLookup.ICAS.com.Models;
using Dapper;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace ArchiveLookup.ICAS.com.Controllers
{
	public class TpsclassenrolementswithddaController : ApiController
	{
		//rename query in paramters to criteria here and in WebAPICONfig.cs
		public List<TPSClass> Post([FromBody]TPSClass criteria)
		{
			var persons = new List<TPSClass>();
			var queryBase = @"EXEC DBO.ClassSelect" + queryGenerator(criteria, true);

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TPSClassEnrolementWithDDA"].ConnectionString))
			{
				try
				{
					persons = connection.Query<Person>(queryBase, criteria.ToDapperParameter()).ToList();
				}
				catch (SqlException e)
				{
					switch (e.Number)
					{
						case 2601: return persons;
						default: return persons;
					}
				}
			}

			return persons;
		}

		public string queryGenerator(PersonQuery criteriaFull, bool areYouSure)
		{
			//WHEN ADDING NEW CRITERIA ADD DATABSE PREFIX HERE IN SAME POSITION AS IT IS IN getClassNames();
			var properties = criteriaFull.GetType().GetFields();
			var query = "";
			bool began = false;
			for (var i = 0; i < properties.Length; i++)
			{
				if (properties[i].GetValue(criteriaFull) != "" && properties[i].GetValue(criteriaFull) != null && !began)
				{
					query = query + "WHERE " + criteriaFull.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
					began = true;
				}
				else if (properties[i].GetValue(criteriaFull) != "" && properties[i].GetValue(criteriaFull) != null)
				{
					query = query + " AND " + criteriaFull.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
				}
			}

			return query;
		}

	}
}

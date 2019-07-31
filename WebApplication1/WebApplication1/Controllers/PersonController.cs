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
    public class PersonController : ApiController
    {
		//rename query in paramters to criteria here and in WebAPICONfig.cs
		public List<Person> Post([FromBody]PersonQuery query)
		{
			var persons = new List<Person>();
			//var querySQL = queryGenerator(query, true);
			/*
			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ArchiveLookup"].ConnectionString))
			{
				var queryBase = @"SELECT	n.[ID]
						,n.[MAJOR_KEY]
						,n.[FULL_NAME]
						,n.[FIRST_NAME]
						,n.[LAST_FIRST]
						,n.[COMPANY]
						,n.[MEMBER_TYPE]
						,mt.[DESCRIPTION]
						,n.[EMAIL]
						FROM [imis].[dbo].[Name] as n
						JOIN activity as a
						on n.id = a.id
						JOIN Member_Types as mt
						on n.MEMBER_TYPE  = mt.MEMBER_TYPE";
				persons = connection.Query<Person>(querySQL, queryBase+querySQL).ToList();
			}
			*/
			return persons;
		}
		
		public string queryGenerator(PersonQuery criteriaFull, bool areYouSure)
		{
			var properties = criteriaFull.GetType().GetFields();

			var query = "";
			bool began = false;
			for (var i =0; i < properties.Length; i++)
			{
				if (properties[i].GetValue(criteriaFull) != null && !began)
				{
					query = query + "WHERE n." + properties[i].Name + " = @" + properties[i].Name;
					began = true;
				}
				else if (properties[i].GetValue(criteriaFull) != null )
				{
					query = query + " AND n." + properties[i].Name + " = @" + properties[i].Name;
				}
				
			}
			
			return query;
		}
		
	}
}

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
		public List<TPSClass> Post([FromBody]TPSClassQuery criteria)
		{
			var persons = new List<TPSClass>();
			var queryBase = @"EXEC DBO.TPSClassSelect '20190701', '20190805', '605340001'";

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TPSClassEnrolementWithDDA"].ConnectionString))
			{
				try
				{
					persons = connection.Query<TPSClass>(queryBase, criteria.ToDapperParameter()).ToList();
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

		public string queryGenerator(TPSClassQuery criteriaFull, bool areYouSure)
		{
			//TPC = 605340000 //TPS = 605340001 //TPE = 605340002
			var chosenClass = "60534000";
			switch (criteriaFull.CLASS)
			{
				case "TPC": return chosenClass + "0";
				case "TPS": return chosenClass + "1";
				case "TPE": return chosenClass + "2";
				default: return chosenClass + "0";
			}
		}
	}
}

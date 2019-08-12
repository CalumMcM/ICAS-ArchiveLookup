﻿using System;
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
	public class TpsexamController : ApiController
	{
		public List<TPSClass> Post([FromBody]TPSClassQuery criteria)
		{
			var persons = new List<TPSClass>();
			var queryBase = @"EXEC DBO.TPSExamSelect @START_DATE, @END_DATE, " + queryGenerator(criteria, true);

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

		public int queryGenerator(TPSClassQuery criteriaFull, bool areYouSure)
		{
			//TPC = 605340000 //TPS = 605340001 //TPE = 605340002
			switch (criteriaFull.CLASS)
			{
				case "TPC": return 605340000;
				case "TPS": return 605340001;
				case "TPE": return 605340002;
				default: return 605340000;
			}
		}
	}
}

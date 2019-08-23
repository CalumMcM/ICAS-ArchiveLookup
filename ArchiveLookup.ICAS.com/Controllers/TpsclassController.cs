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
using log4net;

namespace ArchiveLookup.ICAS.com.Controllers
{
	public class TpsclassController : ApiController
	{
		private ILog _Logger = LogManager.GetLogger(typeof(TpsclassController));
		/*
		 Inputs: criteria - The query which has the fields in TPSClassQuery
		 Returns: A list of TPSClass objects
		 Remark: Constructs the query which is executed on the imis database and returns the results as a 
		 list of TPSClass objects where each TPSClass is a record that was returned
		*/
		public List<TPSClass> Post([FromBody]TPSClassQuery criteria)
		{
			var persons = new List<TPSClass>();
			var queryBase = @"EXEC DBO.TPSClassSelect @START_DATE, @END_DATE, " + queryGenerator(criteria, true);

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dwliveAzure"].ConnectionString))
			{
				try
				{
					persons = connection.Query<TPSClass>(queryBase, criteria.ToDapperParameter()).ToList();
				}
				catch (SqlException e)
				{
					_Logger.Error("Database Query Failed", e);
					switch (e.Number)
					{
						//2601 = SQL Violation in unique index
						case 2601: return persons;
						default: return persons;
					}
				}
				catch (Exception e)
				{
					_Logger.Error("Exception occurred", e);
					throw e;
				}
			}
			_Logger.Debug("Response from database: " + persons);
			return persons;
		}

		public int queryGenerator(TPSClassQuery criteriaFull, bool areYouSure)
		{
			//TPC = 605340000 //TPS = 605340001 //TPE = 605340002
			switch (criteriaFull.CLASS)
			{
				case "TC": return 605340000;
				case "TPS": return 605340001;
				case "TPE": return 605340002;
				default: return 605340000;
			}
		}
	}
}

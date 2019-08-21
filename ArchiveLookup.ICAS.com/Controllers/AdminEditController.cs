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
    public class AdminEditController : ApiController
    {
		private ILog _Logger = LogManager.GetLogger(typeof(LicenceController));
		/*
		 Inputs: criteria - The query which has the fields in LicenceQuery
		 Returns: A list of Licence objects
		 Remark: Constructs the query which is executed on the imis database and returns the results as a 
		 list of Licence objects where each Licence is a record that was returned
		*/
		public bool Post([FromBody]PageAccessQuery pageAccess)
		{
			if (true)
			{
				var persons = new List<PageAccess>();
				var queryBase = @"INSERT INTO dbo.PageAccess(UserName, PageName) VALUES(@UserName, @PageName)";
				using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlArchiveLookup"].ConnectionString))
				{
					try
					{
						connection.Execute(queryBase, pageAccess.ToDapperParameter());
					}
					catch (SqlException e)
					{
						_Logger.Error("Database Query Failed", e);
						switch (e.Number)
						{
							//2601 = SQL Violation in unique index
							case 2601: return false;
							default: return false;
						}
					}
					catch (Exception e)
					{
						_Logger.Error("Exception occurred", e);
						throw e;
					}
				}
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

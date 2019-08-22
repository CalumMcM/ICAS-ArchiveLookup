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
		public bool Post([FromBody]AdminQuery AdminQuery)
		{
			string action = AdminQuery.getAction();
			if (action != null)
			{
				if (action == "Add")
				{
					var persons = new List<PageAccess>();
					var queryUsers = @"INSERT INTO dbo.Users(UserName) Values(@UserName)";
					var queryPageAccess = @"INSERT INTO dbo.PageAccess(UserName, PageName) VALUES(@UserName, @PageName)";
					using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlArchiveLookup"].ConnectionString))
					{
						try
						{
							connection.Execute(queryUsers, AdminQuery.ToDapperParameter());
							connection.Execute(queryPageAccess, AdminQuery.ToDapperParameter());
						}
						catch (SqlException e)
						{
							try
							{
								connection.Execute(queryPageAccess, AdminQuery.ToDapperParameter());
							}
							catch (SqlException e2)
							{
								_Logger.Error("Database Query Failed", e2);
								switch (e2.Number)
								{
									//2601 = SQL Violation in unique index
									case 2601: return false;
									default: return false;
								}
							}
							catch (Exception e2)
							{
								_Logger.Error("Exception occurred", e);
								throw e;
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
				else if (AdminQuery.AdminAction == "Remove")
				{
					var persons = new List<PageAccess>();
					var queryUsers = @"DELETE FROM dbo.Users where UserName = @UserName";
					var queryPageAccess = @"DELETE FROM dbo.PageAccess where Username = 'jmcmeekin' and PageName = 'Concession'";
					using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlArchiveLookup"].ConnectionString))
					{
						try
						{
							connection.Execute(queryUsers, AdminQuery.ToDapperParameter());
							connection.Execute(queryPageAccess, AdminQuery.ToDapperParameter());
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
				return false;
			}
			else
			{
				return false;
			}
		}
	}
}

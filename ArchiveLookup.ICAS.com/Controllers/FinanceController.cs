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
using System.Diagnostics;
using log4net;
using log4net.Config;

namespace ArchiveLookup.ICAS.com.Controllers
{
	public class FinanceController : ApiController
	{
		private ILog _Logger = LogManager.GetLogger(typeof(FinanceController));
		/*
		 Inputs: criteria - The query which has the fields in FinanceQuery
		 Returns: A list of Finance objects
		 Remark: Constructs the query which is executed on the imis database and returns the results as a 
		 list of Finance objects where each Finance is a record that was returned
		*/
		public List<Finance> Post([FromBody]FinanceQuery criteria)
		{
			var persons = new List<Finance>();
			var queryBase = @"SELECT TOP (2000) n.[ID] as [IMIS_ID]
								,n.[MAJOR_KEY] as [MEMBER_NO]
								,si.[STUDENT_NO]
								,i.[INVOICE_DATE] 
								,i.[REFERENCE_NUM] 
								,i.[DESCRIPTION] AS [INVOICE_DESCRIPTION] 
								,i.[CHARGES] 
								,i.[CREDITS] 
								,i.[BALANCE]
								,i.[Note] 
								,t.[TRANSACTION_DATE] AS [TRANS_TRANSACTION_DATE] 
								,t.[TRANSACTION_TYPE] 
								,t.[DESCRIPTION] AS [TRANSACTION_DESCRIPTION] 
								,t.[AMOUNT] AS [TRANSACTION_AMOUNT] 
								,f.[MAIN_FIRM_NO]
								FROM [imis].[dbo].[Name] as n
								LEFT OUTER JOIN Student_Info as si
								on n.ID = si.ID
								JOIN Firm as f
								on n.ID = f.ID
								LEFT OUTER JOIN Orders as o
								on n.CO_ID = o.CO_ID
								LEFT OUTER JOIN Trans as t
								on t.TRANS_NUMBER = o.ORDER_NUMBER
								LEFT OUTER JOIN Invoice as i
								on t.TRANS_NUMBER = i.REFERENCE_NUM " + criteria.queryGenerator() + " ORDER BY TRANSACTION_DATE DESC";

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql"].ConnectionString))
			{
				try
				{
					persons = connection.Query<Finance>(queryBase, criteria.ToDapperParameter()).ToList();
				}
				catch (SqlException e)
				{
					_Logger.Error("Database Query Failed", e);
					//2601 = SQL Violation in unique index
					switch (e.Number)
					{
						case 2601: return persons;
						default: throw e;
					}
				}
				catch (Exception e)
				{
					_Logger.Error("Exception occurred", e);
					throw e;
				}
			}

			return persons;
		}
	}
}

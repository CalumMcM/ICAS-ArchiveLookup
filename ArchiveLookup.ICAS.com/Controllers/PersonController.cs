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
    public class PersonController : ApiController
    {
		private ILog _Logger = LogManager.GetLogger(typeof(PersonController));
		/*
		 Inputs: criteria - The query which has the fields in PersonQuery
		 Returns: A list of Person objects
		 Remark: Constructs the query which is executed on the imis database and returns the results as a 
		 list of Person objects where each Person is a record that was returned
		*/
		public List<Person> Post([FromBody]PersonQuery criteria)
		{
			var persons = new List<Person>();
			var queryBase = @"SELECT TOP (1000) n.[ID] as [IMIS_ID]
								,n.[MAJOR_KEY] as [MEMBER_NO]
								,n.[FIRST_NAME]
								,n.[MIDDLE_NAME]
								,n.[LAST_NAME]
								,n.[FUNCTIONAL_TITLE]
								,n.[MEMBER_TYPE]
								,n.[CATEGORY]
								,n.[TITLE]
								,n.[CITY]
								,n.[COUNTY]
								,n.[COMPANY_SORT]
								,n.[FULL_ADDRESS]
								,n.[Company]
								,n.[LAST_FIRST]
								,n.[STATUS]
								,n.[PAID_THRU]
								,n.[JOIN_DATE]
								,a.[DESCRIPTION]
								,a.[TRANSACTION_DATE]
								,a.[EFFECTIVE_DATE]
								,a.[PRODUCT_CODE]
								,a.[ACTIVITY_TYPE]
								,a.[THRU_DATE]
								,a.[AMOUNT]
								,a.[UNITS]
								,f.[MAIN_FIRM_NO]
								,si.[INTAKE_YEAR]
								,si.[STUDENT_NO]
								,si.[TPCE_STUDENT]
								,si.[TRE_STUDENT]
								,si.[CONTRACT_START_DATE]
								,si.[CONTRACT_END_DATE]
								,si.[FIRM_ID]
								,si.[FIRM_NAME]
								,si.[FINAL_CERTIFICATE_DATE]
								,si.[EXAM_CERTIFICATE_DATE]
								,si.[BE_PASS]
								,si.[LOGBOOK_VERIFIED]
								,si.[LOGBOOK_VERIFIED_DATE]
								,si.[ITP_STUDENT]
								,si.[ITP_Passed]
								,si.[COMMENTS]
								,ec.[EVENT_ATTENDEES]
								,g.[TP_Monthly]
								FROM [imis].[dbo].[Name] as n
								JOIN activity as a
								on n.id = a.id
								JOIN Member_Types as mt
								on n.MEMBER_TYPE  = mt.MEMBER_TYPE
								LEFT OUTER JOIN Student_Info as si
								on n.ID = si.ID
								JOIN Groups as g
								on n.ID = g.ID
								JOIN exclude_comms as ec
								on n.ID = ec.ID
								JOIN Firm as f
								on n.ID = f.ID " + criteria.queryGenerator() + " ORDER BY TRANSACTION_DATE DESC";

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql"].ConnectionString))
			{
				try
				{
					persons = connection.Query<Person>(queryBase, criteria.ToDapperParameter()).ToList();
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

			return persons;
		}
		
	}
}

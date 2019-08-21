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
    public class LicenceController : ApiController
    {
		private ILog _Logger = LogManager.GetLogger(typeof(FinanceController));
		/*
		 Inputs: criteria - The query which has the fields in LicenceQuery
		 Returns: A list of Licence objects
		 Remark: Constructs the query which is executed on the imis database and returns the results as a 
		 list of Licence objects where each Licence is a record that was returned
		*/
		public List<Licence> Post([FromBody]LicenceQuery criteria)
		{
			var persons = new List<Licence>();
			var queryBase = @"SELECT TOP (1000) n.[ID] as [IMIS_ID]
									,n.[MAJOR_KEY] as [MEMBER_NO]
									,n.[FUNCTIONAL_TITLE]
									,n.[FIRST_NAME] 
									,n.[MIDDLE_NAME] 
									,n.[LAST_NAME] 		
									,n.[STATUS]
									,n.[ORG_CODE]
									,a.[DESCRIPTION] 
									,a.[TRANSACTION_DATE] 
									,a.[EFFECTIVE_DATE] 
									,a.[THRU_DATE] 
									,a.[NOTE] 
									,a.[PRODUCT_CODE] 
									,a.[ACTIVITY_TYPE] 
									,a.[SOURCE_CODE]
									,si.[FIRM_ID] 
									,ar.[FIRM_NO] 
									,f.[AR_MONTH] 
									,f.[SORT_NAME]
									,f.[FINANCIAL_YEAR_END] 
									,f.[CA_LICENSED_END_DATE] 
									,f.[AROther] 
									,f.[FIRM_NOTES] 
									,pii.[StartDate] as [PII_Start_Date]
									,pii.[EndDate] as [PII_End_Date]
									,pii.[RecordState] as [PII_Status]
									,pii.[PII_Comments]
									,dpb.[StartDate] as [DPB_Start_Date]
									,dpb.[EndDate] as [DPB_End_Date]
									,dpb.[RecordStatus] as [DPB_Status]
									,dpb.[Comments] as [DPB_COMMENTS]
									,ar.[DATE_CREATED] as [AR_Start_Date]
									,ar.[STATUS] as [AR_Status]
							  FROM [imis].[dbo].[Name] as n
							LEFT OUTER JOIN activity as a
							on n.id = a.id
							LEFT OUTER JOIN Student_Info as si
							on n.ID = si.ID
							LEFT OUTER JOIN Firm as f
							on n.ID = f.ID
							LEFT OUTER JOIN IREG_DPB as dpb
							on n.ID = dpb.NameID
							LEFT OUTER JOIN IREG_PII as pii
							on n.ID = pii.NameID
							LEFT OUTER JOIN IREG_AnnRet as ar
							on n.ID = ar.ID 
							where a.[ACTIVITY_TYPE] = 'LICENCE'" + criteria.queryGenerator() + " ORDER BY TRANSACTION_DATE DESC"; ;

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql"].ConnectionString))
			{
				try
				{
					persons = connection.Query<Licence>(queryBase, criteria.ToDapperParameter()).ToList();
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
			}
			return persons;
		}
	}
}

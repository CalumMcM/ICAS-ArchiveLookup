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
    public class PcController : ApiController
    {
		//rename query in paramters to criteria here and in WebAPICONfig.cs
		public List<ProcessingChange> Post([FromBody]PCQuery criteria)
		{
			var persons = new List<ProcessingChange>();
			var queryBase = @"SELECT TOP (1000) n.[ID] 
									,n.[MAJOR_KEY] 
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
							where a.[ACTIVITY_TYPE] = 'LICENCE'" + queryGenerator(criteria, true) + " ORDER BY TRANSACTION_DATE DESC"; ;

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ArchiveLookup"].ConnectionString))
			{
				try
				{
					persons = connection.Query<ProcessingChange>(queryBase, criteria.ToDapperParameter()).ToList();
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
		
		public string queryGenerator(PCQuery criteriaFull, bool areYouSure)
		{
			var properties = criteriaFull.GetType().GetProperties();
			var propertyName = properties[0].Name;
			var query = "";
			for (var i =0; i < properties.Length; i++)
			{
				if (properties[i].GetValue(criteriaFull) != null)
				{
					query = query + " AND " + criteriaFull.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
				}
			}
			
			return query;
		}
		
	}
}

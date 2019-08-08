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
    public class FinanceController : ApiController
    {
		//rename query in paramters to criteria here and in WebAPICONfig.cs
		public List<Finance> Post([FromBody]FinanceQuery criteria)
		{
			var persons = new List<Finance>();
			var queryBase = @"SELECT TOP (2000) n.[ID]
								,n.[MAJOR_KEY]
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
								,a.[DESCRIPTION]
								,a.[TRANSACTION_DATE]
								,a.[EFFECTIVE_DATE]
								,a.[PRODUCT_CODE]
								,a.[ACTIVITY_TYPE]
								,a.[THRU_DATE]
								,f.[MAIN_FIRM_NO]
								,si.[CONTRACT_START_DATE]
								,si.[STUDENT_NO]
								,si.[CONTRACT_END_DATE]
								,si.[FIRM_ID]
								,si.[FIRM_NAME]
								,si.[ITP_STUDENT]
								,si.[ITP_Passed]
								,si.[COMMENTS]
								,ec.[EVENT_ATTENDEES]
								,g.[TP_Monthly]
								,i.[INVOICE_DATE]
								,i.[REFERENCE_NUM]
								,i.[DESCRIPTION] AS [INVOICE_DESCRIPTION]
								,i.[CHARGES]
								,i.[CREDITS]
								,i.[BALANCE]
								,t.[TRANSACTION_DATE] AS [TRANS_TRANSACTION_DATE]
								,t.[TRANS_NUMBER]
								,t.[TRANSACTION_TYPE]
								,t.[DESCRIPTION] AS [TRANSACTION_DESCRIPTION]
								,t.[AMOUNT] AS [TRANSACTION_AMOUNT]
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
								on n.ID = f.ID
								LEFT OUTER JOIN Orders as o
								on n.CO_ID = o.CO_ID
								LEFT OUTER JOIN Trans as t
								on t.INVOICE_REFERENCE_NUM = o.INVOICE_REFERENCE_NUM
								LEFT OUTER JOIN Invoice as i
								on t.BT_ID = i.BT_ID " + queryGenerator(criteria, true) + " ORDER BY TRANSACTION_DATE DESC"; ;

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ArchiveLookup"].ConnectionString))
			{
				try
				{
					persons = connection.Query<Finance>(queryBase, criteria.ToDapperParameter()).ToList();
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
		
		public string queryGenerator(FinanceQuery criteriaFull, bool areYouSure)
		{
			//WHEN ADDING NEW CRITERIA ADD DATABSE PREFIX HERE IN SAME POSITION AS IT IS IN getClassNames();
			var properties = criteriaFull.GetType().GetFields();
			var query = "";
			bool began = false;
			for (var i =0; i < properties.Length; i++)
			{
				if (properties[i].GetValue(criteriaFull) != "" && properties[i].GetValue(criteriaFull) != null && !began)
				{
					query = query + "WHERE " + criteriaFull.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
					began = true;
				}
				else if (properties[i].GetValue(criteriaFull) != "" && properties[i].GetValue(criteriaFull) != null)
				{
					query = query + " AND " + criteriaFull.getDatabasePrefix(properties[i].Name) + properties[i].Name + " = @" + properties[i].Name;
				}
			}
			
			return query;
		}
		
	}
}

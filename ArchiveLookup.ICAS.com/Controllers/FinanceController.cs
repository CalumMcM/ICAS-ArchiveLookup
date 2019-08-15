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
using System.Diagnostics;

namespace ArchiveLookup.ICAS.com.Controllers
{
    public class FinanceController : ApiController
    {
		//rename query in paramters to criteria here and in WebAPICONfig.cs
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
								on t.TRANS_NUMBER = i.REFERENCE_NUM " + queryGenerator(criteria, true) + " ORDER BY TRANSACTION_DATE DESC";

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ArchiveLookup"].ConnectionString))
			{
				try
				{
					persons = connection.Query<Finance>(queryBase, criteria.ToDapperParameter()).ToList();
				}
				catch (SqlException e)
				{
					//Debug.WriteLine(e.Message);
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

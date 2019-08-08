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
    public class PersonController : ApiController
    {
		//rename query in paramters to criteria here and in WebAPICONfig.cs
		public List<Person> Post([FromBody]PersonQuery criteria)
		{
			var persons = new List<Person>();
			var queryBase = @"SELECT TOP (1000) n.[ID]
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
								,a.[AMOUNT]
								,a.[UNITS]
								,a.[NOTE]
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
								on n.ID = f.ID " + queryGenerator(criteria, true) + " ORDER BY TRANSACTION_DATE DESC";

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ArchiveLookup"].ConnectionString))
			{
				try
				{
					persons = connection.Query<Person>(queryBase, criteria.ToDapperParameter()).ToList();
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
		
		public string queryGenerator(PersonQuery criteriaFull, bool areYouSure)
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

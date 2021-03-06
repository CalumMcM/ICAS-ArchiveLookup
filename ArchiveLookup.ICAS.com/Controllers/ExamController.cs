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
using log4net;

namespace ArchiveLookup.ICAS.com.Controllers
{
    public class ExamController : ApiController
	{
		private ILog _Logger = LogManager.GetLogger(typeof(ExamController));
		/*
		 Inputs: criteria - The query which has the fields in ExamQuery
		 Returns: A list of exam objects
		 Remark: Constructs the query which is executed on the imis database and returns the results as a 
		 list of Exam objects where each Exam is a record that was returned
		*/
		public List<Exam> Post([FromBody]ExamQuery criteria)
		{
			var persons = new List<Exam>();
			var queryBase = @"SELECT TOP (1000) n.[ID] as [IMIS_ID]
								,n.[MAJOR_KEY] as [MEMBER_NO]
								,n.[FIRST_NAME] -- 
								,n.[MIDDLE_NAME] -- 
								,n.[LAST_NAME] --
								,n.[CITY] --
								,n.[STATE_PROVINCE] --
								,n.[ZIP] --
								,n.[COUNTRY] -- 
								,n.[COUNTY] --
								,si.[ROUTE_CODE] -- 
								,si.[ROUTE_SUB_CODE] --
								,si.[INTAKE_YEAR] --
								,cr.[STUDENT_ID] -- 
								,si.[FIRM_NAME] -- 
								,a.[DESCRIPTION] --
								,a.[TRANSACTION_DATE] --
								,a.[PRODUCT_CODE] --
								,a.[ACTIVITY_TYPE] --
								,a.[NOTE] --
								,a.[THRU_DATE] --
								,a.[AMOUNT] --
								,a.[UNITS] --
								,f.[MAIN_FIRM_NO] --
								,cr.[REG_TYPE] as [STATUS]
								,cr.[GRADE_TEXT] as [GRADE]
								,cr.[REGISTRATION_ITEM]
								,cr.[DESCRIPTION] as [TITLE]
								,cr.[UF_3] as [CLASS_YEAR]
								,cr.[UF_4] as [GROUP]
								,cr.[NOTES]
								,cr.[COMPONENT_INSTANCE] as [LOCATION]
								,cr.PROGRAM_ID as [PROGRAM]
								,cr.[ENROLLED_DATE]
								,d.[TYPE]
								,d.[ALLOWANCE]
								,d.[ACTION]
								,d.[ALLOWANCE_2]
								,d.[ACTION_2]
								,d.[ALLOWANCE_3]
								,d.[ACTION_3]
								,d.[ALLOWANCE_4]
								,d.[ACTION_4]
						  FROM [imis].[dbo].[Name] as n
						  --JOIN CTE_T1 as cte
						  --on n.ID = cte.ID
						JOIN activity as a
						on n.id = a.id
						JOIN Member_Types as mt
						on n.MEMBER_TYPE  = mt.MEMBER_TYPE
						LEFT OUTER JOIN Student_Info as si
						on n.ID = si.ID
						JOIN Firm as f
						on n.ID = f.ID
						JOIN Disability as d
						on n.ID = d.ID
						JOIN Cert_Register as cr
						on si.ID = cr.BT_ID " + criteria.queryGenerator() + " ORDER BY TRANSACTION_DATE DESC"; 

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql"].ConnectionString))
			{
				try
				{
					persons = connection.Query<Exam>(queryBase, criteria.ToDapperParameter()).ToList();
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

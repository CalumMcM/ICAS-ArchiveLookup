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
    public class InsightsController : ApiController
	{
		private ILog _Logger = LogManager.GetLogger(typeof(InsightsController));
		/*
		 Returns: A list of Insight objects
		 Remark: Constructs the query which is executed on the imis database and returns the results as a 
		 list of Insight objects where each Insight is a record that was returned
		*/
		public List<Insight> Post()
		{
			var persons = new List<Insight>();
			var queryBase = @"SELECT TOP (1000) CONVERT (nvarchar(250), c.[ContactID] ) as [ContactID]
							,CONVERT (nvarchar(250), c.[OrganisationKey] ) as [OrganisationKey]
							,c.[EndDate]
							,c.[Birth Date] as [Birth_Date]
							,c.[CA Member Number] as [CA_Member_Number]
							,c.[Company] 
							,c.[CPD Exempt] as [CPD_Exempt]
							,c.[Customer Sub Type] as [CONTACT_Customer_Sub_Type]
							,c.[Customer Type] as [CONTACT_Customer_Type]
							,c.[Date of Joining ICAS] as [Date_of_Joining_ICAS]
							,c.[Effective Removal Date] as [Effective_Removal_Date]
							,c.[Gender]
							,c.[Home Address City] as [Home_Address_City]
							,c.[Home Address Country] as [Home_Address_Country]
							,c.[Home Address Postal code] as [Home_Address_Postal_Code]
							,c.[Job Level] as [Job_Level]
							,c.[Job Title] as [Job_Title]
							,c.[Member Interests] as [Member_Interests]
							,c.[Parent Customer Name] as [Parent_Customer_Name]
							,c.[Reason For Leaving] as [Reason_For_Leaving]
							,c.[State] as [CONTACT_State]
							,c.[Status] as [CONTACT_Status]
							,c.[Student Contract End Date] as [Student_Contract_End_Date]
							,c.[Student Contract Start Date] as [Student_Contract_Start_Date]
							,c.[Student ITP] as [Student_ITP]
							,c.[Student Training Firm] as [Student_Training_Firm]
							,c.[Work Address Line 1] as [Work_Address_Line_1]
							,c.[Work Address Line 2] as [Work_Address_Line_2]
							,c.[Work Address Line 3] as [Work_Address_Line_3]
							,c.[Work Address City] as [Work_Address_City]
							,c.[Work Address Country] as [Work_Address_Country]
							,c.[Work Address Postal code] as [Work_Address_Postal_Code]
							,c.[Work Sectors] as [Work_Sectors]
							,c.[Working Status] as [Working_Status]
							,c.[University Attended] as [University_Attended]
							,c.[University Degree Subject] as [University_Degree_Subject]
							,CONVERT (nvarchar(250), l.[ContactOrganisationID] ) as [ContactOrganisationID] 
							,CONVERT (nvarchar(250), l.[LicenceID] ) as [LicenceID]
							,l.[EndDate] as [LICENCE_EndDate]
							,l.[Licence End Date] as [Licence_End_Date]
							,l.[Licence Issue Date] as [Licence_Issue_Date]
							,l.[Licence Start Date] as [Licence_Start_Date]
							,l.[Licence Type] as [Licence_Type]
							,l.[State] as [LICENCE_State]
							,l.[Status] as [LICENCE_Status]
							,CONVERT (nvarchar(250), mr.[Key Sales Order ID] ) as [Key_Sales_Order_ID]
							,mr.[EndDate] as [MEMBERSHIPRECORD_EndDate]
							,mr.[Annual Renewal Complete] as [Annual_Renewal_Complete]
							,mr.[Annual Renewal Method] as [Annual_Renewal_Method]
							,mr.[Engagement Feedback] as [Engagement_Feedback]
							,mr.[Engagement Feedback Comments] as [Engagement_Feedback_Comments]
							,mr.[Engagement Feedback Star Rating] as [Engagement_Feedback_Star_Rating]
							,mr.[Has Made Professional Declaration] as [Has_Made_Professional_Declaration]
							,mr.[Latest Feedback] as [Latest_Feedback]
							,mr.[Membership Status Code] as [Membership_Status_Code]
							,mr.[Membership Year End Date] as [Membership_Year_End_Date]
							,mr.[Payment Responsibility] as [Payment_Responsibility]
							,mr.[State Code] as [MEMBERSHIPRECORD_Status]
							,mr.[Status Code] as [MEMBERSHIPRECORD_State]
							,mr.[Sub Rate Product Name] as [Sub_Rate_Product_Name]
							,CONVERT (nvarchar(250), ato.[AuthorisationTrainingOfficeID] ) as [AuthorisationTrainingOfficeID]
							,CONVERT (nvarchar(250), ato.[ParentATOID] ) as [ParentATOID]
							,ato.[EndDate] as [ATO_EndDate]
							,ato.[Authorisation Stage] as [Authorisation_Stage]
							,ato.[Group Authorisation] as [Group_Authorisation]
							,ato.[Last Authorisation Date] as [Last_Authorisation_Date]
							,ato.[State] as [ATO_State]
							,ato.[Status] as [ATO_Status]
							,CONVERT (nvarchar(250),  b.[BoomID] ) as [BoomID]
							,b.[EndDate] as [BOOM_EndDate]
							,b.[Business Owner] as [Business_Owner]
							,b.[Is Manager] as [Is_Manager]
							,b.[Is ICAS Officer] [Is_ICAS_Officer]
							,b.[State] as [BOOM_State]
							,b.[Status] as [BOOM_Status]
							,CONVERT (nvarchar(250), o.[OrganisationID] ) as [OrganisationID]
							,CONVERT (nvarchar(250), o.[OrganisationID] ) as [ParentID]
							,o.[Address Line 1] as [Address_Line_1]
							,o.[Address Line 2] as [Address_Line_2]
							,o.[Address Line 3] as [Address_Line_3]
							,o.[AML Supervising Body] as [AML_Supervising_Body]
							,o.[City]
							,o.[Country]
							,o.[Customer Sub Type] as [Customer_Sub_Type]
							,o.[Customer Type] as [Customer_Type]
							,o.[ICAS Country] as [ICAS_Country]
							,o.[Legal Entity] as [Legal_Entity]
							,o.[Legal Entity Type] as [Legal_Entity_Type]
							,o.[Organisation Name] as [Organisation_Name]
							,o.[Parent Name] as [Parent_Name]
							,o.[Postal Code] as [Postal_Code]
							,o.[State] as [ORGANISATION_State]
							,o.[Status] as [ORGANISATION_Status]
							,o.[Trading Name] as [Trading_Name]
							FROM [Data_Dimensional_Model].[dbo].[PBIContacts] as c
							LEFT OUTER JOIN [PBILicence] as l
							on c.[ContactID] = l.[ContactId]
							LEFT OUTER JOIN [PBIMembershipRecord] as mr
							on c.[ContactID] = mr.[ContactID]
							LEFT OUTER JOIN [PBIBoom] as b
							on c.[ContactID] = b.[ContactID]
							LEFT OUTER JOIN [PBIATO] as ato
							on ato.[OrganisationID] = b.[OrganisationID]
							LEFT OUTER JOIN [PBIOrganisation] as o
							on o.[OrganisationID] = b.[OrganisationID]"; 

			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dwliveDDM"].ConnectionString))
			{
				try
				{
					persons = connection.Query<Insight>(queryBase).ToList();
				}
				catch (SqlException e)
				{
					switch (e.Number)
					{
						_Logger.Error("Database Query Failed", e);
						//2601 = SQL Violation in unique index
						case 2601: return persons;
						default: return persons;
					}
				}
			}
			//createCSV(persons);
			return persons;
		}

		public void createCSV(List<Insight> table)
		{
			string csv = "";
			foreach (Insight record in table)
			{
				var properties = record.GetType().GetFields();
				for (var i = 0; i < properties.Length; i++)
				{
					if (!(i == properties.Length - 1))
					{
						csv += (string)properties[i].GetValue(record) + ",";
					} else
					{
						csv += (string)properties[i].GetValue(record) + "\n";
					}
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class ProcessingChange
	{
		public string ID { get; set; } 
		public string MAJOR_KEY { get; set; } 
		public string FUNCTIONAL_TITLE { get; set; }
		public string FIRST_NAME { get; set; } 
		public string MIDDLE_NAME { get; set; } 
		public string LAST_NAME { get; set; } 		
		public string STATUS { get; set; }
		public string ORG_CODE { get; set; }
		public string DESCRIPTION { get; set; } 
		public string TRANSACTION_DATE { get; set; } 
		public string EFFECTIVE_DATE { get; set; } 
		public string THRU_DATE { get; set; } 
		public string NOTE { get; set; } 
		public string PRODUCT_CODE { get; set; } 
		public string ACTIVITY_TYPE { get; set; } 
		public string FIRM_ID { get; set; } 
		public string FIRM_NAME { get; set; } 
		public string MAIN_FIRM_NO { get; set; } 
		public string AR_MONTH { get; set; } 
		public string FINANCIAL_YEAR_END { get; set; } 
		public string CA_LICENSED_END_DATE { get; set; } 
		public string AROther { get; set; } 
		public string FIRM_NOTES { get; set; } 
		public string PII_Start_Date { get; set; }
		public string PII_End_Date { get; set; }
		public string PII_Status { get; set; } 
		public string PII_Comments { get; set; }
		public string DPB_Start_Date { get; set; }
		public string DPB_End_Date { get; set; }
		public string DPB_Status { get; set; } 
		public string DPB_COMMENTS { get; set; }
		public string AR_Start_Date { get; set; }
		public string AR_Status { get; set; }

	}
}
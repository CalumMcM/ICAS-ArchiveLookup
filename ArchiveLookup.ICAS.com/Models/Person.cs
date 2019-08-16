using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class Person
	{
		public string IMIS_ID { get; set; }
		public string MEMBER_NO { get; set; } 
		public string LAST_NAME { get; set; }
		public string FIRST_NAME { get; set; }
		public string LAST_FIRST { get; set; }
		public string MIDDLE_NAME { get; set; }
		public string TRANSACTION_DATE { get; set; }
		public string ACTIVITY_TYPE { get; set; }
		public string DESCRIPTION { get; set; }
		public string EFFECTIVE_DATE { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string FUNCTIONAL_TITLE { get; set; }
		public string STATUS { get; set; }
		public string UNITS { get; set; }
		public string INTAKE_YEAR{ get; set; }
		public string TPCE_STUDENT { get; set; }
		public string TRE_STUDENT { get; set; }
		public string CONTRACT_START_DATE { get; set; }
		public string CONTRACT_END_DATE { get; set; }
		public string FIRM_ID { get; set; }
		public string FIRM_NAME { get; set; }
		public string STUDENT_NO { get; set; }
		public string FINAL_CERTIFICATE_DATE { get; set; }
		public string EXAM_CERTIFICATE_DATE { get; set; }
		public string BE_PASS { get; set; }
		public string LOGBOOK_VERIFIED { get; set; }
		public string LOGBOOK_VERIFIED_DATE { get; set; }
		public string ITP_STUDENT { get; set; }
		public string ITP_Passed { get; set; }
		public string EVENT_ATTENDEES { get; set; }
		public string TP_Monthly { get; set; }
		public string MEMBER_TYPE { get; set; }
		public string CATEGORY { get; set; }
		public string TITLE { get; set; }
		public string CITY { get; set; }
		public string COUNTY { get; set; }
		public string COMPANY_SORT { get; set; }
		public string FULL_ADDRESS { get; set; }
		public string Company { get; set; }
		public string THRU_DATE { get; set; }
		public string AMOUNT { get; set; }
		public string MAIN_FIRM_NO { get; set; }
		public string COMMENTS { get; set; }
	}
}
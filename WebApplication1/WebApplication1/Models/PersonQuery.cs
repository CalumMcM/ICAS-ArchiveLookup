using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class PersonQuery
	{
		public string ID;
		public string MAJOR_KEY;
		public string FIRST_NAME;
		public string MIDDLE_NAME;
		public string LAST_NAME;
		public string FUNCTIONAL_TITLE;
		public string STATUS;
		public string INTAKE_YEAR;
		public string TPCE_STUDENT;
		public string TRE_STUDENT;
		public Nullable <DateTime> CONTRACT_START_DATE;
		public Nullable<DateTime> CONTRACT_END_DATE;
		public string FIRM_ID;
		public string FIRM_NAME;
		public Nullable<DateTime> FINAL_CERTIFICATE_DATE;
		public Nullable<DateTime> EXAM_CERTIFICATE_DATE;
		public string BE_PASS;
		public string LOGBOOK_VERIFIED;
		public Nullable<DateTime> LOGBOOK_VERIFIED_DATE;
		public string ITP_STUDENT;
		public string ITP_Passed;
		public string EVENT_ATTENDEES;
		public string TP_Monthly;
		public string DESCRIPTION;
		public Nullable<DateTime> TRANSACTION_DATE;
		public Nullable<DateTime> EFFECTIVE_DATE;
		public string PRODUCT_CODE;
		public string ACTIVITY_TYPE;
		public Object ToDapperParameter()
		{
			return new {
				ID = ID,
				MAJOR_KEY = MAJOR_KEY,
				FIRST_NAME = FIRST_NAME,
				MIDDLE_NAME = MIDDLE_NAME,
				LAST_NAME = LAST_NAME,
				FUNCTIONAL_TITLE = FUNCTIONAL_TITLE,
				STATUS = STATUS,
				INTAKE_YEAR = INTAKE_YEAR,
				TPCE_STUDENT = TPCE_STUDENT,
				TRE_STUDENT = TRE_STUDENT,
				CONTRACT_START_DATE = CONTRACT_START_DATE,
				CONTRACT_END_DATE = CONTRACT_END_DATE,
				FIRM_ID = FIRM_ID,
				FIRM_NAME = FIRM_NAME,
				FINAL_CERTIFICATE_DATE = FINAL_CERTIFICATE_DATE,
				EXAM_CERTIFICATE_DATE = EXAM_CERTIFICATE_DATE,
				BE_PASS = BE_PASS,
				LOGBOOK_VERIFIED = LOGBOOK_VERIFIED,
				LOGBOOK_VERIFIED_DATE = LOGBOOK_VERIFIED_DATE,
				ITP_STUDENT = ITP_STUDENT,
				ITP_Passed  = ITP_Passed,
				EVENT_ATTENDEES = EVENT_ATTENDEES,
				TP_Monthly = TP_Monthly,
				DESCRIPTION = DESCRIPTION,
				TRANSACTION_DATE = TRANSACTION_DATE,
				EFFECTIVE_DATE = EFFECTIVE_DATE,
				PRODUCT_CODE = PRODUCT_CODE,
				ACTIVITY_TYPE = ACTIVITY_TYPE
			};
		}
		public string getDatabasePrefix(string header)
		{
			switch (header)
			{
				case "ID": return "n.";
				case "MAJOR_KEY": return "n.";
				case "FIRST_NAME": return "n.";
				case "MIDDLE_NAME": return "n.";
				case "LAST_NAME": return "n.";
				case "FUNCTIONAL_TITLE": return "n.";
				case "STATUS": return "n.";
				case "INTAKE_YEAR": return "si.";
				case "TPCE_STUDENT": return "si.";
				case "TRE_STUDENT": return "si.";
				case "CONTRACT_START_DATE": return "si.";
				case "CONTRACT_END_DATE": return "si.";
				case "FIRM_ID": return "si.";
				case "FIRM_NAME": return "si.";
				case "FINAL_CERTIFICATE_DATE": return "si.";
				case "EXAM_CERTIFICATE_DATE": return "si.";
				case "BE_PASS": return "si.";
				case "LOGBOOK_VERIFIED_DATE": return "si.";
				case "ITP_STUDENT": return "si.";
				case "ITP_Passed": return "si.";
				case "EVENT_ATTENDEES": return "ec.";
				case "TP_Monthly": return "g.";
				case "DESCRIPTION": return "a.";
				case "TRANSACTION_DATE": return "a.";
				case "EFFECTIVE_DATE": return "a.";
				case "PRODUCT_CODE": return "a.";
				case "ACTIVITY_TYPE": return "a.";
			}
			return "";
		}
	}

}
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
		public string CONTRACT_START_DATE;
		public string CONTRACT_END_DATE;
		public string FIRM_ID;
		public string FIRM_NAME;
		public string FINAL_CERTIFICATE_DATE;
		public string EXAM_CERTIFICATE_DATE;
		public string BE_PASS;
		public string LOGBOOK_VERIFIED;
		public string LOGBOOK_VERIFIED_DATE;
		public string ITP_STUDENT;
		public string ITP_Passed;
		public string EVENT_ATTENDEES;
		public string TP_Monthly;
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
				TP_Monthly = TP_Monthly
			};
		}
	}

}
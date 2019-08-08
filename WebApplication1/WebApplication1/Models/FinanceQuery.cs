using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class FinanceQuery
	{
		public string ID;
		public string MAJOR_KEY;
		public string FIRST_NAME;
		public string MIDDLE_NAME;
		public string LAST_NAME;
		public string FUNCTIONAL_TITLE;
		public string MEMBER_TYPE;
		public string CATEGORY;
		public string TITLE;
		public string CITY;
		public string COUNTY;
		public string COMPANY_SORT;
		public string FULL_ADDRESS;
		public string Company;
		public string LAST_FIRST;
		public string STATUS;
		public string DESCRIPTION;
		public Nullable<DateTime> TRANSACTION_DATE;
		public Nullable<DateTime> EFFECTIVE_DATE;
		public string PRODUCT_CODE;
		public string ACTIVITY_TYPE;
		public Nullable<DateTime> THRU_DATE;
		public string MAIN_FIRM_NO;
		public Nullable<DateTime> CONTRACT_START_DATE;
		public Nullable<DateTime> CONTRACT_END_DATE;
		public string FIRM_ID;
		public string FIRM_NAME;
		public string ITP_STUDENT;
		public string ITP_Passed;
		public string COMMENTS;
		public string EVENT_ATTENDEES;
		public string TP_Monthly;
		public Nullable<DateTime> INVOICE_DATE;
		public string REFERENCE_NUM;
		public string INVOICE_DESCRIPTION;
		public string CHARGES;
		public string CREDITS;
		public string BALANCE;
		public Nullable<DateTime> TRANS_TRANSACTION_DATE;
		public string TRANS_NUMBER;
		public string TRANSACTION_TYPE;
		public string TRANSACTION_DESCRIPTION;
		public string TRANSACTION_AMOUNT;

		public Object ToDapperParameter()
		{
			return new {
				ID = ID,
				MAJOR_KEY = MAJOR_KEY,
				FIRST_NAME = FIRST_NAME,
				MIDDLE_NAME = MIDDLE_NAME,
				LAST_NAME = LAST_NAME,
				FUNCTIONAL_TITLE = FUNCTIONAL_TITLE,
				MEMBER_TYPE = MEMBER_TYPE,
				CATEGORY = CATEGORY,
				TITLE = TITLE,
				CITY = CITY,
				COUNTY = COUNTY,
				COMPANY_SORT = COMPANY_SORT,
				FULL_ADDRESS = FULL_ADDRESS,
				Company = Company,
				LAST_FIRST = LAST_FIRST,
				STATUS = STATUS,
				DESCRIPTION = DESCRIPTION,
				TRANSACTION_DATE = TRANSACTION_DATE,
				EFFECTIVE_DATE = EFFECTIVE_DATE,
				PRODUCT_CODE = PRODUCT_CODE,
				ACTIVITY_TYPE = ACTIVITY_TYPE,
				THRU_DATE = THRU_DATE,
				MAIN_FIRM_NO = MAIN_FIRM_NO,
				CONTRACT_START_DATE = CONTRACT_START_DATE,
				CONTRACT_END_DATE = CONTRACT_END_DATE,
				FIRM_ID = FIRM_ID,
				FIRM_NAME = FIRM_NAME,
				ITP_STUDENT = ITP_STUDENT,
				ITP_Passed = ITP_Passed,
				COMMENTS = COMMENTS,
				EVENT_ATTENDEES = EVENT_ATTENDEES,
				TP_Monthly = TP_Monthly,
				INVOICE_DATE = INVOICE_DATE,
				REFERENCE_NUM = REFERENCE_NUM,
				INVOICE_DESCRIPTION = INVOICE_DESCRIPTION,
				CHARGES = CHARGES,
				CREDITS = CREDITS,
				BALANCE = BALANCE,
				TRANS_TRANSACTION_DATE = TRANS_TRANSACTION_DATE,
				TRANS_NUMBER = TRANS_NUMBER,
				TRANSACTION_TYPE = TRANSACTION_TYPE,
				TRANSACTION_DESCRIPTION = TRANSACTION_DESCRIPTION,
				TRANSACTION_AMOUNT = TRANSACTION_AMOUNT,
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
				case "MEMBER_TYPE": return "n.";
				case "CATEGORY": return "n.";
				case "TITLE": return "n.";
				case "CITY": return "n.";
				case "COUNTY": return "n.";
				case "COMPANY_SORT": return "n.";
				case "FULL_ADDRESS": return "n.";
				case "Company": return "n.";
				case "LAST_FIRST": return "n.";
				case "STATUS": return "n.";
				case "DESCRIPTION": return "a.";
				case "TRANSACTION_DATE": return "a.";
				case "EFFECTIVE_DATE": return "a.";
				case "PRODUCT_CODE": return "a.";
				case "ACTIVITY_TYPE": return "a.";
				case "THRU_DATE": return "a.";
				case "MAIN_FIRM_NO": return "f.";
				case "CONTRACT_START_DATE": return "si.";
				case "CONTRACT_END_DATE": return "si.";
				case "FIRM_ID": return "si.";
				case "FIRM_NAME": return "si.";
				case "ITP_STUDENT": return "si.";
				case "ITP_Passed": return "si.";
				case "COMMENTS": return "si.";
				case "EVENT_ATTENDEES": return "ec.";
				case "TP_Monthly": return "g.";
				case "INVOICE_DATE": return "i.";
				case "REFERENCE_NUM": return "i.";
				case "INVOICE_DESCRIPTION": return "i.";
				case "CHARGES": return "i.";
				case "CREDITS": return "i.";
				case "BALANCE": return "i.";
				case "TRANS_TRANSACTION_DATE": return "t.";
				case "TRANS_NUMBER": return "t.";
				case "TRANSACTION_TYPE": return "t.";
				case "TRANSACTION_DESCRIPTION": return "t.";
				case "TRANSACTION_AMOUNT": return "t.";
			}
			return "";
		}
	}

}
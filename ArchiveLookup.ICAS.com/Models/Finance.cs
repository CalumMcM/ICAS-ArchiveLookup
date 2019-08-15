using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchiveLookup.ICAS.com.Models
{
	public class Finance
	{
		public string ID { get; set; }
		public string MAJOR_KEY { get; set; } 
		public string STUDENT_NO { get; set; }
		public string INVOICE_DATE { get; set; } 
		public string REFERENCE_NUM { get; set; } 
		public string INVOICE_DESCRIPTION { get; set; }
		public string CHARGES { get; set; } 
		public string CREDITS { get; set; } 
		public string BALANCE { get; set; }
		public string Note { get; set; } 
		public string TRANS_TRANSACTION_DATE { get; set; }
		public string TRANSACTION_TYPE { get; set; } 
		public string TRANSACTION_DESCRIPTION { get; set; }
		public string TRANSACTION_AMOUNT { get; set; } 
		public string MAIN_FIRM_NO { get; set; }

	}
}
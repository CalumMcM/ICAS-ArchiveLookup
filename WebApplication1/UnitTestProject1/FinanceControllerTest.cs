using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArchiveLookup.ICAS.com.Models;
using ArchiveLookup.ICAS.com.Controllers;

namespace ArchiveLookup.ICAS.com.test
{
	[TestClass]
	public class FinanceControllerTest
	{
		/*
		[TestMethod]
		public void PersonControllerGeneratesQueryGivenGoodCriteria()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			criteria.FIRST_NAME = "Calum";
			criteria.LAST_NAME = "McMeekin";
			FinanceController financeController = new FinanceController();
			string[] databasePrefix = new string[23] { "n.", "n.", "n.", "n.", "n.", "n.", "n.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "ec.", "g." };
			//Act
			var response = financeController.queryGenerator(criteria, true);
			//Assert
			Assert.AreEqual("WHERE n.FIRST_NAME = @FIRST_NAME AND n.LAST_NAME = @LAST_NAME", response, "Query Generator failed to generate the correct query");
		}
		
		[TestMethod]
		public void PersonControllerReturnsCorrectResultFromQueryOnDatabase()
		{
			//Arrange
			PersonQuery criteria = new PersonQuery();
			criteria.FIRST_NAME = "Calum";
			criteria.ID = "259365";
			PersonController personController = new PersonController();
			//Act
			var response = personController.Post(criteria);
			//Assert
			//Assert.AreEqual("");
		}
		*/
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixForGivenType()
		{
			//Arrange 
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var nResponse = criteria.getDatabasePrefix("FIRST_NAME");
			var ecResponse = criteria.getDatabasePrefix("EVENT_ATTENDEES");
			//Assert
			Assert.AreEqual("n.", nResponse);
			Assert.AreEqual("ec.", ecResponse);
		}
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixForn()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var nHeaders = new string[16] { "ID", "MAJOR_KEY", "FIRST_NAME", "MIDDLE_NAME", "LAST_NAME", "FUNCTIONAL_TITLE", "MEMBER_TYPE", "CATEGORY", "TITLE", "CITY", "COUNTY", "COMPANY_SORT", "FULL_ADDRESS", "Company", "LAST_FIRST", "STATUS" };
			//Assert
			foreach (string header in nHeaders)
			{
				Assert.AreEqual("n.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixForsi()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var siHeaders = new string[7] { "CONTRACT_START_DATE", "CONTRACT_END_DATE", "FIRM_ID", "FIRM_NAME", "ITP_STUDENT", "ITP_Passed", "COMMENTS"};
			//Assert
			foreach (string header in siHeaders)
			{
				Assert.AreEqual("si.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixForec()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var ecHeaders = new string[1] { "EVENT_ATTENDEES" };
			//Assert
			foreach (string header in ecHeaders)
			{
				Assert.AreEqual("ec.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixForg()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var gHeaders = new string[1] { "TP_Monthly" };
			//Assert
			foreach (string header in gHeaders)
			{
				Assert.AreEqual("g.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixFora()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var aHeaders = new string[6] { "DESCRIPTION", "TRANSACTION_DATE", "PRODUCT_CODE", "EFFECTIVE_DATE", "THRU_DATE", "ACTIVITY_TYPE"};
			//Assert
			foreach(string header in aHeaders)
			{
				Assert.AreEqual("a.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixForf()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var fHeaders = new string[1] { "MAIN_FIRM_NO" };
			//Assert
			foreach (string header in fHeaders)
			{
				Assert.AreEqual("f.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixFori()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var iHeaders = new string[6] { "INVOICE_DATE", "REFERENCE_NUM", "INVOICE_DESCRIPTION", "CHARGES", "CREDITS", "BALANCE" };
			//Assert
			foreach (string header in iHeaders)
			{
				Assert.AreEqual("i.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixFort()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var tHeaders = new string[5] { "TRANS_TRANSACTION_DATE", "TRANS_NUMBER", "TRANSACTION_TYPE", "TRANSACTION_DESCRIPTION", "TRANSACTION_AMOUNT" };
			//Assert
			foreach (string header in tHeaders)
			{
				Assert.AreEqual("t.", criteria.getDatabasePrefix(header));
			}
		}
	}
}

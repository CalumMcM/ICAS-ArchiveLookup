using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArchiveLookup.ICAS.com.Models;
using ArchiveLookup.ICAS.com.Controllers;

namespace ArchiveLookup.ICAS.com.test
{
	[TestClass]
	public class PersonControllerTest
	{
		[TestMethod]
		public void PersonControllerGeneratesQueryGivenGoodCriteria()
		{
			//Arrange
			PersonQuery criteria = new PersonQuery();
			criteria.FIRST_NAME = "Calum";
			criteria.LAST_NAME = "McMeekin";
			PersonController personController = new PersonController();
			string[] databasePrefix = new string[23] { "n.", "n.", "n.", "n.", "n.", "n.", "n.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "si.", "ec.", "g." };
			//Act
			var response = personController.queryGenerator(criteria, true);
			//Assert
			Assert.AreEqual("WHERE n.FIRST_NAME = @FIRST_NAME AND n.LAST_NAME = @LAST_NAME", response, "Query Generator failed to generate the correct query");
		}
		/*
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
		public void PersonQueryReturnsCorrectDatabasePrefixForGivenType()
		{
			//Arrange 
			PersonQuery criteria = new PersonQuery();
			//Act
			var nResponse = criteria.getDatabasePrefix("FIRST_NAME");
			var siReponse = criteria.getDatabasePrefix("TPCE_STUDENT");
			var ecResponse = criteria.getDatabasePrefix("EVENT_ATTENDEES");
			//Assert
			Assert.AreEqual("n.", nResponse);
			Assert.AreEqual("si.", siReponse);
			Assert.AreEqual("ec.", ecResponse);
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixForn()
		{
			//Arrange
			PersonQuery criteria = new PersonQuery();
			//Act
			var nHeaders = new string[16] {"LAST_FIRST", "Company", "FULL_ADDRESS", "COMPANY_SORT", "COUNTY", "CITY", "TITLE", "CATEGORY", "MEMBER_TYPE", "ID", "MAJOR_KEY", "FIRST_NAME", "MIDDLE_NAME", "LAST_NAME","FUNCTIONAL_TITLE", "STATUS" };
			//Assert
			foreach (string header in nHeaders)
			{
				Assert.AreEqual("n.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixForsi()
		{
			//Arrange
			PersonQuery criteria = new PersonQuery();
			//Act
			var siHeaders = new string[16] { "STUDENT_NO", "COMMENTS", "INTAKE_YEAR", "TPCE_STUDENT", "TRE_STUDENT", "CONTRACT_START_DATE", "CONTRACT_END_DATE", "FIRM_ID", "FIRM_NAME", "FINAL_CERTIFICATE_DATE", "EXAM_CERTIFICATE_DATE", "BE_PASS", "BE_PASS", "LOGBOOK_VERIFIED_DATE", "ITP_STUDENT", "ITP_Passed" };
			//Assert
			foreach (string header in siHeaders)
			{
				Assert.AreEqual("si.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixForec()
		{
			//Arrange
			PersonQuery criteria = new PersonQuery();
			//Act
			var ecHeaders = new string[1] { "EVENT_ATTENDEES" };
			//Assert
			foreach (string header in ecHeaders)
			{
				Assert.AreEqual("ec.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixForg()
		{
			//Arrange
			PersonQuery criteria = new PersonQuery();
			//Act
			var gHeaders = new string[1] { "TP_Monthly" };
			//Assert
			foreach (string header in gHeaders)
			{
				Assert.AreEqual("g.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixFora()
		{
			//Arrange
			PersonQuery criteria = new PersonQuery();
			//Act
			var aHeaders = new string[8] { "UNITS", "AMOUNT", "THRU_DATE", "DESCRIPTION", "TRANSACTION_DATE", "EFFECTIVE_DATE", "PRODUCT_CODE", "ACTIVITY_TYPE" };
			//Assert
			foreach(string header in aHeaders)
			{
				Assert.AreEqual("a.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixForf()
		{
			//Arrange
			PersonQuery criteria = new PersonQuery();
			//Act
			var fHeaders = new string[1] { "MAIN_FIRM_NO" };
			//Assert
			foreach (string header in fHeaders)
			{
				Assert.AreEqual("f.", criteria.getDatabasePrefix(header));
			}
		}
	}
}

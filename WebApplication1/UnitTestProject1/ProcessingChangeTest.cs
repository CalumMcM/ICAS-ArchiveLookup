using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArchiveLookup.ICAS.com.Models;
using ArchiveLookup.ICAS.com.Controllers;

namespace ArchiveLookup.ICAS.com.test
{
	[TestClass]
	public class ProcessingChangeTest
	{
		[TestMethod]
		public void PcControllerGeneratesQueryGivenGoodCriteria()
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
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixForGivenType()
		{
			//Arrange 
			LicenceQuery criteria = new LicenceQuery();
			//Act
			var nResponse = criteria.getDatabasePrefix("FIRST_NAME");
			var aReponse = criteria.getDatabasePrefix("DESCRIPTION");
			var fResponse = criteria.getDatabasePrefix("FIRM_NO");
			var siResponse = criteria.getDatabasePrefix("FIRM_ID");
			//Assert
			Assert.AreEqual("n.", nResponse);
			Assert.AreEqual("a.", aReponse);
			Assert.AreEqual("ar.", fResponse);
			Assert.AreEqual("si.", siResponse);
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixForn()
		{
			//Arrange
			LicenceQuery criteria = new LicenceQuery();
			//Act
			var nHeaders = new string[5] {"ID", "MAJOR_KEY", "FIRST_NAME", "MIDDLE_NAME", "LAST_NAME", };
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
			LicenceQuery criteria = new LicenceQuery();
			//Act
			var siHeaders = new string[1] { "FIRM_ID"};
			//Assert
			foreach (string header in siHeaders)
			{
				Assert.AreEqual("si.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixFora()
		{
			//Arrange
			LicenceQuery criteria = new LicenceQuery();
			//Act
			var aHeaders = new string[3] {"DESCRIPTION", "ACTIVITY_TYPE", "SOURCE_CODE" };
			//Assert
			foreach(string header in aHeaders)
			{
				Assert.AreEqual("a.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixForar()
		{
			//Arrange
			LicenceQuery criteria = new LicenceQuery();
			//Act
			var arHeaders = new string[1] { "FIRM_NO" };
			//Assert
			foreach (string header in arHeaders)
			{
				Assert.AreEqual("ar.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void PersonQueryReturnsCorrectDatabasePrefixForf()
		{
			//Arrange
			LicenceQuery criteria = new LicenceQuery();
			//Act
			var fHeaders = new string[1] { "SORT_NAME" };
			//Assert
			foreach (string header in fHeaders)
			{
				Assert.AreEqual("f.", criteria.getDatabasePrefix(header));
			}
		}
	}
}

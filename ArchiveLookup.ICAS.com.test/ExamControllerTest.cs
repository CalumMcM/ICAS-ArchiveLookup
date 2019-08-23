using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArchiveLookup.ICAS.com.Models;
using ArchiveLookup.ICAS.com.Controllers;

namespace ArchiveLookup.ICAS.com.test
{
	[TestClass]
	public class ExamControllerTest
	{
		[TestMethod]
		public void ExamQueryReturnsCorrectDatabasePrefixForGivenType()
		{
			//Arrange 
			ExamQuery criteria = new ExamQuery();
			//Act
			var nResponse = criteria.getDatabasePrefix("FIRST_NAME");
			var aReponse = criteria.getDatabasePrefix("DESCRIPTION");
			var fResponse = criteria.getDatabasePrefix("FIRM_NO");
			//Assert
			Assert.AreEqual("n.", nResponse);
			Assert.AreEqual("a.", aReponse);
			Assert.AreEqual("ar.", fResponse);
		}
		[TestMethod]
		public void ExamQueryReturnsCorrectDatabasePrefixForn()
		{
			//Arrange
			ExamQuery criteria = new ExamQuery();
			//Act
			var nHeaders = new string[4] {"MAJOR_KEY", "FIRST_NAME", "MIDDLE_NAME", "LAST_NAME"};
			//Assert
			foreach (string header in nHeaders)
			{
				Assert.AreEqual("n.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void ExamQueryReturnsCorrectDatabasePrefixFora()
		{
			//Arrange
			ExamQuery criteria = new ExamQuery();
			//Act
			var aHeaders = new string[1] {"DESCRIPTION"};
			//Assert
			foreach(string header in aHeaders)
			{
				Assert.AreEqual("a.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void ExamQueryReturnsCorrectDatabasePrefixForar()
		{
			//Arrange
			ExamQuery criteria = new ExamQuery();
			//Act
			var arHeaders = new string[1] { "FIRM_NO" };
			//Assert
			foreach (string header in arHeaders)
			{
				Assert.AreEqual("ar.", criteria.getDatabasePrefix(header));
			}
		}
		[TestMethod]
		public void ExamQueryReturnsCorrectDatabasePrefixForcr()
		{
			//Arrange
			ExamQuery criteria = new ExamQuery();
			//Act
			var crHeaders = new string[1] { "STUDENT_ID" };
			//Assert
			foreach (string header in crHeaders)
			{
				Assert.AreEqual("cr.", criteria.getDatabasePrefix(header));
			}
		}
	}
}

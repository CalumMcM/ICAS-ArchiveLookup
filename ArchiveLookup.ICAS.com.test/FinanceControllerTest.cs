using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArchiveLookup.ICAS.com.Models;
using ArchiveLookup.ICAS.com.Controllers;

namespace ArchiveLookup.ICAS.com.test
{
	[TestClass]
	public class FinanceControllerTest
	{
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixForGivenType()
		{
			//Arrange 
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var nResponse = criteria.getDatabasePrefix("ID");
			var ecResponse = criteria.getDatabasePrefix("STUDENT_NO");
			//Assert
			Assert.AreEqual("n.", nResponse);
			Assert.AreEqual("si.", ecResponse);
		}
		[TestMethod]
		public void FinanceQueryReturnsCorrectDatabasePrefixForn()
		{
			//Arrange
			FinanceQuery criteria = new FinanceQuery();
			//Act
			var nHeaders = new string[2] { "ID", "MAJOR_KEY" };
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
			var siHeaders = new string[1] { "STUDENT_NO" };
			//Assert
			foreach (string header in siHeaders)
			{
				Assert.AreEqual("si.", criteria.getDatabasePrefix(header));
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
			var iHeaders = new string[1] { "REFERENCE_NUM" };
			foreach (string header in iHeaders)
			{
				Assert.AreEqual("i.", criteria.getDatabasePrefix(header));
			}
		}
	}
}

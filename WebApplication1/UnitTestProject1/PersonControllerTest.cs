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
			var response = personController.queryGenerator(criteria, databasePrefix, true);
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
	}
}

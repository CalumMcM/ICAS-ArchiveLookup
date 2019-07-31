﻿using System;
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
			//Act
			var response = personController.queryGenerator(criteria, true);
			//Assert
			Assert.AreEqual("WHERE n.FIRST_NAME = @FIRST_NAME AND n.LAST_NAME = @LAST_NAME", response, "Query Generator failed to generate the correct query");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonController : ApiController
    {
		public List <Person> Post(PersonQuery query)
		{
			var newPerson = new List<Person>();
			//Use Dapper to call the database
			return newPerson;
		} 
    }

}

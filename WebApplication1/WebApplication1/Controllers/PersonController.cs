using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using Dapper;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class PersonController : ApiController
    {
		//public List <Person> Post(PersonQuery query)
		public List<Person> Get(string query)
		{
			var persons = new List<Person>();
			
			using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ArchiveLookup"].ConnectionString))
			{
				var sql = @"SELECT	n.[ID]
								,n.[MAJOR_KEY]
								,n.[FULL_NAME]
								,n.[FIRST_NAME]
								,n.[LAST_FIRST]
								,n.[COMPANY]
								,n.[MEMBER_TYPE]
								,mt.[DESCRIPTION]
								,n.[EMAIL]
								FROM [imis].[dbo].[Name] as n
								JOIN activity as a
								on n.id = a.id
								JOIN Member_Types as mt
								on n.MEMBER_TYPE  = mt.MEMBER_TYPE
								WHERE n.FIRST_NAME = @query"; //Will this use the string query variable?
				persons = connection.Query<Person>(sql, new { query = query }).ToList();
			}
			return persons;
		} 
    }

}

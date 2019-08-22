using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Data.SqlClient;
using System.Web.Configuration;
using log4net;
using ArchiveLookup.ICAS.com.Models;

namespace ArchiveLookup.ICAS.com.Controllers
{
	public class HomeController : Controller
	{
		private ILog _Logger = LogManager.GetLogger(typeof(HomeController));
		private string _CurrentUsername = System.Web.HttpContext.Current.User.Identity.Name;
		public ActionResult Admin()
		{
			return View();
		}
		public ActionResult Channels()
		{
			foreach (string username in GandalfApproved("Admin"))
			{
				if (_CurrentUsername.EndsWith(username))
				{
					return View();
				}
			}
			return new HttpStatusCodeResult(403);
		}
		public ActionResult Concession()
		{
			foreach (string username in GandalfApproved("Concession"))
			{
				if (_CurrentUsername.EndsWith(username))
				{
					return View();
				}
			}
			return new HttpStatusCodeResult(403);
		}
		public ActionResult Examinations()
		{
			foreach (string username in GandalfApproved("Examinations"))
			{
				if (_CurrentUsername.EndsWith(username))
				{
					return View();
				}
			}
			return new HttpStatusCodeResult(403);
		}
		public ActionResult Finance()
		{
			foreach (string username in GandalfApproved("Finance"))
			{
				if (_CurrentUsername.EndsWith(username))
				{
					return View();
				}
			}
			return new HttpStatusCodeResult(403);
		}
		public ActionResult Insights()
		{
			foreach (string username in GandalfApproved("Insights"))
			{
				if (_CurrentUsername.EndsWith(username))
				{
					return View();
				}
			}
			return new HttpStatusCodeResult(403);
		}
		public ActionResult Legal()
		{
			foreach (string username in GandalfApproved("Legal"))
			{
				if (_CurrentUsername.EndsWith(username))
				{
					return View();
				}
			}
			return new HttpStatusCodeResult(403);
		}
		public ActionResult ProcessingChange()
		{
			foreach (string username in GandalfApproved("ProcessingChange"))
			{
				if (_CurrentUsername.EndsWith(username))
				{
					return View();
				}
			}
			return new HttpStatusCodeResult(403);
		}
		public ActionResult ArchiveLookup()
		{
			return View();
		}
		public ActionResult LoginPage()
		{
			return View();
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public string[] GandalfApproved(string tabName)
		{
			AdminGetController api = new AdminGetController();
			List<PageAccess> results = api.Post(tabName);
			string[] approved = new string[results.Count];
			int position = 0;
			foreach (PageAccess result in results)
			{
				approved[position] = result.UserName;
				++position;
			}
			return approved;
		}
	}
}
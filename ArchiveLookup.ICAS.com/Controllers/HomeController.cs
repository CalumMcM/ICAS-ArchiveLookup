using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace ArchiveLookup.ICAS.com.Controllers
{
	public class HomeController : Controller
	{
		private string[] ChannelsAccess = new string[3] { "cmcmeekin", "mrawes", "mherriot" };
		private string[] ConcessionAccess = new string[5] { "cmcmeekin", "mrawes", "rburns", "jshaw", "gfagan" };
		private string[] ExaminationsAccess= new string[5] { "cmcmeekin", "mrawes", "rburns", "jshaw", "gfagan" };
		private string[] FinanceAccess = new string[3] { "cmcmeekin", "mrawes", "sfuller" };
		private string[] InsightsAccess = new string[2] { "cmcmeekin", "mrawes" };
		private string[] LegalAccess = new string[4] { "cmcmeekin", "mrawes", "ispowart", "ncosans" };
		private string[] ProcessingChangeAccess = new string[4] { "cmcmeekin", "mrawes", "jgrant", "rrichardson" };

		private string _CurrentUsername = System.Web.HttpContext.Current.User.Identity.Name;
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Channels()
		{
			foreach (string username in ChannelsAccess)
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
			foreach (string username in ConcessionAccess)
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
			foreach (string username in ExaminationsAccess)
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
			foreach (string username in FinanceAccess)
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
			foreach (string username in InsightsAccess)
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
			foreach (string username in LegalAccess)
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
			foreach (string username in ProcessingChangeAccess)
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
	}
}
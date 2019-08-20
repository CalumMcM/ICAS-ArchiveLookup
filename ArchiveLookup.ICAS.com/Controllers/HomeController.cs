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
		private string[] ChannelsAccess = new string[2] { "cmcmeekin", "mrawes" };
		private string[] ConcessionAccess = new string[2] { "cmcmeekin", "mrawes" };
		private string[] ExaminationsAccess= new string[2] { "cmcmeekin", "mrawes" };
		private string[] FinanceAccess = new string[2] { "cmcmeekin", "mrawes" };
		private string[] InsightsAccess = new string[2] { "cmcmeekin", "mrawes" };
		private string[] LegalAccess = new string[3] { "cmcmeekin", "mrawes", "" };

		private string _CurrentUsername = System.Web.HttpContext.Current.User.Identity.Name;
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Channels()
		{
			return View();
		}
		public ActionResult Concession()
		{
			return View();
		}
		public ActionResult Examinations()
		{
			return View();
		}
		public ActionResult Finance()
		{
			if (!_CurrentUsername.EndsWith("cmcmeekin"))
			{
				return View();
			} else
			{
				return new HttpStatusCodeResult(403);
			}
		}
		public ActionResult Insights()
		{
			return View();
		}
		public ActionResult Legal()
		{
			return View();
		}
		public ActionResult ProcessingChange()
		{
			return View();
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
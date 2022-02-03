using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKapi.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
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

		public ActionResult Test()
		{
			return View();
		}

		[AllowAnonymous]
		public ActionResult HomePage() //BURASI VERİ TABANI İŞLEMLERİ OLMAYACAĞI İÇİN TEK SAYFAYLA ÇALIŞILACAK.
		{

			return View();
		}

	}
}
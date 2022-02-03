using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKapi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var listallofthem = abm.GetList();
            return View(listallofthem);
        }

        [HttpGet]
        public ActionResult AddAbout()
		{

            return View();
		}
        [HttpPost]
        public ActionResult AddAbout(About about )
        {
             abm.AboutAddBL(about);

            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
		{
            return PartialView();
		}
    }
}
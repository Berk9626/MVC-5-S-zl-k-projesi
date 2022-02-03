using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKapi.Controllers
{
    public class AuthorizationController : Controller //yetkilendirme. ama b kişisiyle otantike olması gerekecek kullanan kişinin
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EfAdminDal()); 
        public ActionResult Index()
		{
			var adminvalues = am.GetList();
			return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
		{
            return View();
		}
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            am.AdminAddBL(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var updatedadmin = am.GetById(id);
            return View(updatedadmin);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            am.AdminUpdate(admin);

            return RedirectToAction("Index");
        }


    }
}
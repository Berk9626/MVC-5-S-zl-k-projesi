using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKapi.Controllers
{ //genel olarak bu controllerda sol tarafta yer alan başlık isimlerine tıkladığımızda cıntentleri göreceğiz. Temel mantık bu

    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
		{
            var headinglist = hm.GetList();
			return View(headinglist);
            
		}

		public PartialViewResult Index(int id = 0) //burası contentimiz olacak.
        {
            var contentlist = cm.GetListByHeadingId(id);
            return PartialView(contentlist);
            
        }
    }
}
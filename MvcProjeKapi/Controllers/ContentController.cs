using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKapi.Controllers
{
    public class ContentController : Controller
	{
		// GET: Content

		ContentManager cm = new ContentManager(new EfContentDal());

		public ActionResult Index()
        {
            return View();
        } 

        
        public ActionResult GetAllContent(string p)
		{
			if (p == null)
			{
                var sonuc = cm.GetList();
                return View(sonuc.ToList());
			}
			else
            {
                var values = cm.GetList(p);
                return View(values);
            }

           
		}

        public ActionResult ContentByHeading(int id) 
        {
            var contentvalue = cm.GetListByHeadingId(id);

            return View(contentvalue);

        }
    }
}
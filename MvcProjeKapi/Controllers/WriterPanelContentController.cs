using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKapi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
            p =(string) Session["WriterMail"];
			var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writeridinfo);

			return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
		{
            ViewBag.d = id;

            return View();
		}

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            content.ContentStatus = true;
            string mail = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.WriterId = writeridinfo;
            cm.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
		{
            return View();
		}
    }
}
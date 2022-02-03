using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKapi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager img = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var list = img.GetList();
            return View(list);
        }
    }
}
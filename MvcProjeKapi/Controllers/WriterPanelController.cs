using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKapi.Controllers
{
    
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        //ilk sisteme giriş yapan kullanıcının başlıklarını görüntülemek istiyorum.
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context c = new Context();
      
        [HttpGet]
        public ActionResult WriterProfile()
        {
           int id;
           string p = (string)Session["WriterMail"];
           id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
           var writervalue = wm.GetById(id);
           return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);

            if (result.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading","WriterPanel");


            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }
        public ActionResult MyHeading(string p)
		{
           
            p =(string) Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
          
            var values = hm.GetListByWriter(writeridinfo);      
            return View(values);
		}

        [HttpGet]
        public ActionResult NewHeading() //yazar yeni bir başlık oluşturacak diyelim
        {
           
            //ViewBag.m = deger;


            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()   
                                                  }
                                                  ).ToList();
            ViewBag.vlc = valueCategory;
            return View();

        
        
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading) //yazar yeni bir başlık oluşturacak diyelim
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writeridinfo;
            heading.HeadingStatus = true;
            hm.HeadingAddBL(heading);
            return RedirectToAction("MyHeading");

        }

        [HttpGet]
        public ActionResult EditHeading(int id)
		{
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                  ).ToList();
            ViewBag.vlc = valueCategory;

           var headingValue =  hm.GetById(id);
            return View(headingValue);
		}
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
		{
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
		}

        public ActionResult DeleteHeading(int id)
		{
           var deletedheading = hm.GetById(id);
            deletedheading.HeadingStatus = false;
            hm.HeadingDelete(deletedheading); 
            return RedirectToAction("MyHeading");
            
		}
        public ActionResult AllHeading(int p =1)
		{
            var headings = hm.GetList().ToPagedList(p,4);
            return View(headings);
		}


    }
}
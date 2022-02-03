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
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headingvalue = hm.GetList();
            return View(headingvalue);

        }

        [HttpGet]
        public ActionResult AddHeading()
		{
            //ekleme işlemi sayfası yüklendiği zaman ben bir tane liste göndereceğim.Bu aşağıdaki liste listeden seçilecek olan bir değer alacak.
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text= x.CategoryName,
                                                      Value= x.CategoryId.ToString()//text biz verileri dropdown(combobox) üstünden listeleyeceğiz.2 parametresi olacak.Biri value member,    
                                                  }//ikincisi display member. Value seçmiş olduğum değerin Id'si,display member seçilen değerin görülen kendi kısmı,(Idval addispl
                                                  ).ToList(); //sen şurdan ilgili tablonun bütün değerlerini alacaksın.Amacım başlıklara ekleme işlemini gerçekleştirirken o başlığa ait kategorinin listesini getirmek

            List<SelectListItem> valuerWriter = (from x in wm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text= x.WriterName + " " +x.WriterSurname,
                                                       Value=x.WriterId.ToString()
                                                   }).ToList();



            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valuerWriter;
            return View();
		}

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            hm.HeadingAddBL(heading);

            return RedirectToAction("Index");
        }

        public ActionResult EditHeading(int id)
		{
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()//text biz verileri dropdown(combobox) üstünden listeleyeceğiz.2 parametresi olacak.Biri value member,    
                                                  }//ikincisi display member. Value seçmiş olduğum değerin Id'si,display member seçilen değerin görülen kendi kısmı,(Idval addispl
                                                ).ToList(); //sen şurdan ilgili tablonun bütün değerlerini alacaksın.Amacım başlıklara ekleme işlemini gerçekleştirirken o başlığa ait kategorinin listesini getirmek


            ViewBag.vlc = valueCategory;
            var editedvalue = hm.GetById(id);

			return View(editedvalue);

		}
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
		{
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
		}

        public ActionResult DeleteHeading(int id) //sen sadece gönderilen Id'ye ait değeri false ya da trueya çevireceksin
		{
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
		}
        public ActionResult HeadingReport()
		{
            var headingvalue = hm.GetList();
            return View(headingvalue);
        }




    }
}
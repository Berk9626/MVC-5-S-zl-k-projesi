using MvcProjeKapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKapi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {//aslında bu köprü görevi görecek. Viewimizi INDEX üzerinden oluşturacağız. Index üzerinden CategoryChart'ı çağıracağız
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
		}

        public List<CategoriesClass> BlogList()
		{
            List<CategoriesClass> ct = new List<CategoriesClass>();

            ct.Add(new CategoriesClass()
            {
                CategoryName="Yazılım",
                CategoryCount= 8 //blog sayısı 
            
            });

            ct.Add(new CategoriesClass() {
            
            CategoryCount=7,
            CategoryName = "Teknoloji"
            
            
            });
            ct.Add(new CategoriesClass()
            {

                CategoryCount = 4,
                CategoryName = "Seyahat"


            });
            ct.Add(new CategoriesClass()
            {

                CategoryCount = 1,
                CategoryName = "Spor"
            });

            return ct;
        }
    }
}
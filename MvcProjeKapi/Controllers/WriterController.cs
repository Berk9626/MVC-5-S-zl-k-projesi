using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKapi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator validationRules = new WriterValidator();

        public ActionResult Index()
        {
            var writerValue = wm.GetList();
            return View(writerValue);
        }
        [HttpGet]

        public ActionResult AddWriter()
		{
            return View();
		}
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            
            ValidationResult result = validationRules.Validate(writer);

			if (result.IsValid)
			{
                wm.WriterAdd(writer);
                return RedirectToAction("Index");


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

        [HttpGet]
        public ActionResult EditWriter(int id)
		{
            var updatedwriter = wm.GetById(id);
            return View(updatedwriter);
		}

        [HttpPost]

        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = validationRules.Validate(writer);

            if (result.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("Index");


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
    }
}
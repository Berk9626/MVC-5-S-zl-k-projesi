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
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles ="B")]
        public ActionResult Index()
        {
            var categoryvalues = categoryManager.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
		{
            return View();

		}

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult result = categoryvalidator.Validate(category);

			if (result.IsValid)
			{
                categoryManager.CategoryAddBL(category);
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
        
        public ActionResult DeleteCategory(int id)
		{
           var deletedvalue= categoryManager.GetById(id);
           categoryManager.CategoryDelete(deletedvalue);
           return RedirectToAction("Index");

		}

        [HttpGet]
        public ActionResult EditCategory(int id)
		{
            var updatedcategory = categoryManager.GetById(id);
            return View(updatedcategory);
		}

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);

            return RedirectToAction("Index");
        }



    }
}
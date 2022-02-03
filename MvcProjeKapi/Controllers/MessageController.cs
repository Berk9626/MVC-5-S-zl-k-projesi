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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(string p)
        { //admine gelen mesajlar listelenecek
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }

        public ActionResult SendBox(string p)
		{
            var messagelist = mm.GetListSendnbox(p);
            return View(messagelist);
		}

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }


        [HttpGet]
        public ActionResult NewMessage()
		{
            return View(); 
		}
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messagevalidator.Validate(message);
			if (results.IsValid)
			{
                
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBL(message);
                return RedirectToAction("SendBox");

			}
			else
			{
				foreach (var item in results.Errors)
				{
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

            return View();

           
        }


    }
}
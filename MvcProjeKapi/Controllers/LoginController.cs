using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKapi.Controllers
{
    [AllowAnonymous] //Bunu kullandığım zaman artık Login index Gobal.asax.cs klasörüne tanımladığımız attribute dışında tüm sayfalar dışardan açılmazken bu açmamızı sağlıyor.
    //Global'deki bu attribute ile genel filtrelemeden bir nevi kurtulmuş olduk. Hem writera hem logine erişebiliyorum controller bazında tanımladığım için

    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adm = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
            
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();  
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            //Context c = new Context();
            //var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);

            //var catchedAdmin = adm.GetById(admin.AdminId);
            //var lastadmin = adm.CheckUserandPassword(catchedAdmin);

            var xy = adm.GetByUserName(admin);
            var lastadmin = adm.CheckUserandPassword(xy);


			if (lastadmin != null)
			{
                FormsAuthentication.SetAuthCookie(lastadmin.AdminUserName,false); //sisteme giriş yapan kullanıcının bilgileri. Form yetkisi kimde olacak = sisteme giriş yapan kullanıcıda
                Session["AdminUserName"] = lastadmin.AdminUserName; //bununla bir oturum yönetimi oluşturuluyor
                return RedirectToAction("Index", "AdminCategory");
			}
			else
			{
                return RedirectToAction("Index","Login");
			}

            return View();
        }

        [HttpGet]
        public ActionResult WriterLogin()
		{
            return View();
		}
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
		{
            
            var catchedwritermailinfo = wm.GetByWriterMail(writer);
            var lastcheckwriter = wm.CheckMailandPassword(catchedwritermailinfo);


            if (lastcheckwriter != null)
            {
                FormsAuthentication.SetAuthCookie(lastcheckwriter.WriterMail, false); //sisteme giriş yapan kullanıcının bilgileri. Form yetkisi kimde olacak = sisteme giriş yapan kullanıcıda
                Session["WriterMail"] = lastcheckwriter.WriterMail; //bununla bir oturum yönetimi oluşturuluyor
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
		{
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
		}
    }
}
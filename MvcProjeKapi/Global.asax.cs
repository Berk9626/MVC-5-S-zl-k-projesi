using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcProjeKapi
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalFilters.Filters.Add(new AuthorizeAttribute()); //authorize işlemi proje seviyesine çıkmış olacak. Bunu yadığımda hiçbir sayfaya gidemiyorum
			//temel sebebi session ile sisteme otantike olmam yani girişl yapmam gerekiyor. Ne login ne de diğer sayfalara giremiyorum. Login/Index olan otantike işleminin
			//olacağı kısma da giremiyorum. Demek ki bu kısmın muaf olması gerek.

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}

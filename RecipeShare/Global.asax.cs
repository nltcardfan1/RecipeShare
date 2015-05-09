using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RecipeShare.App_Code;

//using RecipeShare.App_Code;

namespace RecipeShare
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

		void Application_Error(object sender,EventArgs e)
		{
			// Code that runs when an unhandled error occurs
			Logger.LogException(Server.GetLastError(),"Global Error");
		}
    }
}

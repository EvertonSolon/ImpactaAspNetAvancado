using Loja.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Loja.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();


        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var cultura = new CultureHelper();
            var currentThread = Thread.CurrentThread;

            currentThread.CurrentCulture = cultura.CultureInfo;
            currentThread.CurrentUICulture = cultura.CultureInfo;

        }

        //protected void Application_Error()
        //{
        //    var ex = new Exception();
        //    throw ex;
        //}
    }
}

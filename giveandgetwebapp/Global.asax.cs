using FluentScheduler;
using giveandgetwebapp.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace giveandgetwebapp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Job scheduling
            var jobRegistry = new Registry();
            jobRegistry.Schedule<JobCheckOutOfDate>().ToRunNow().AndEvery(1).Hours();
            JobManager.Initialize(jobRegistry);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

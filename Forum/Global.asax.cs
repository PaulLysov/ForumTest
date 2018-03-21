using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Forum.Domain;
using Forum.Domain.Migrations;
using WebMatrix.WebData;

namespace Forum
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			DataBaseInitialize();
		}

		private void DataBaseInitialize()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());

			using (var dataContext = new DataContext())
			{
				if (!dataContext.Database.Exists())
					dataContext.Database.Initialize(true);

				WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Users", "Id", "Email", true);
			}
		}
	}
}

using System.Data.Entity;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Forum.Domain;
using Forum.Domain.Migrations;
using Serilog;
using Serilog.Events;

namespace Forum
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			ConfigureLog();

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			DataBaseInitialize();
		}

		private void ConfigureLog()
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Is(LogEventLevel.Debug)
				//.WriteTo.RollingFile(HostingEnvironment.ApplicationPhysicalPath + @"App_Data\\Logs\\{Date}.log", shared: true)
				.CreateLogger();
		}

		private void DataBaseInitialize()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
			using (var dataContext = new DataContext())
			{
				if (!dataContext.Database.Exists())
					dataContext.Database.Initialize(true);
			}
		}
	}
}

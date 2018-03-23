using System;
using System.Data.Entity;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Forum.Domain;
using Forum.Domain.Migrations;
using Serilog;
using Serilog.Events;
using WebMatrix.WebData;

namespace Forum
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			ConfigureLog();

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
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

		private void ConfigureLog()
		{
			Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Is(LogEventLevel.Debug)
			.WriteTo.RollingFile(HostingEnvironment.ApplicationPhysicalPath + @"App_Data\\Logs\\{Date}.log", shared: true)
			.CreateLogger();
		}

		private void Application_Error(object sender, EventArgs e)
		{
			var exception = Server.GetLastError();
			if (exception != null)
			{
				var message = exception.InnerException?.Message ?? exception.Message;
				Log.Error(exception, $"Global exception Message = [{message}] " +
								 $"Request.UrlReferrer = [{Request.UrlReferrer}], " +
								 $"Request.UserHostAddress = [{Request.UserHostAddress}], " +
								 $"Request.UserAgent = [{Request.UserAgent}],");
			}
		}
	}
}

using System.Web;
using System.Web.Optimization;

namespace Forum
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/AngularJs").Include(
					  "~/Scripts/angular.min.js",
					  "~/Scripts/angular-route.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/AngularApp")
				.IncludeDirectory("~/Scripts/Factories", "*.js")
				.IncludeDirectory("~/Scripts/Controllers", "*.js")
				.Include("~/Scripts/AngularMVCApp.js"));

			//css 
			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css"));
		}
	}
}

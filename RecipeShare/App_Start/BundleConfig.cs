using System.Web;
using System.Web.Optimization;

namespace RecipeShare
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js",
					  "~/Scripts/DataTables/jquery.dataTables.js",
					  "~/Scripts/jquery-ui.js"));

			bundles.Add(new ScriptBundle("~/bundles/misc").Include(
					 "~/Scripts/toastr.js",
					 "~/Scripts/setup.js"));

			bundles.Add(new ScriptBundle("~/bundles/KO").Include(
				"~/Scripts/knockout-3.3.0.js",
				"~/Scripts/knockout.validation.js",
				"~/Scripts/knockout.mapping-latest.js"));
			#if DEBUG
			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css",
					  "~/Content/style.css",
					  "~/Content/font-awesome.css",
					  "~/Content/DataTables/css/jquery.dataTables.css",
					  "~/Content/jquery-ui.css",
					  "~/Content/toastr.css"));
			#else 
			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.min.css",
					  "~/Content/site.css",
					  "~/Content/style.css",
					  "~/Content/font-awesome.min.css",
					  "~/Content/DataTables/css/jquery.dataTables.min.css",
					  "~/Content/jquery-ui.css",
					  "~/Content/toastr.min.cdd"));
#endif
		}
	}
}

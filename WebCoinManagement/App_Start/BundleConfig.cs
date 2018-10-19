using System.Web;
using System.Web.Optimization;

namespace WebCoinManagement {
    public class BundleConfig {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                    "~/Scripts/Login/main.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/portal").Include(
                    "~/Scripts/Portal/plugins.js",
                    "~/Scripts/Portal/main.js",
                    "~/Scripts/Portal/lib/chart-js/Chart.bundle.js",
                    "~/Scripts/Portal/dashboard.js",
                    "~/Scripts/Portal/widgets.js",
                    "~/Scripts/Portal/lib/vector-map/jquery.vmap.js",
                    "~/Scripts/Portal/lib/vector-map/jquery.vmap.min.js",
                    "~/Scripts/Portal/lib/vector-map/jquery.vmap.sampledata.js",
                    "~/Scripts/Portal/lib/vector-map/country/jquery.vmap.world.js"
                ));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                    "~/Content/Login/main.css",
                    "~/Content/Login/util.css",
                    "~/Content/Login/vendor/animate/animate.css",
                    "~/Content/Login/vendor/css-hamburgers/hamburgers.min.css",
                    "~/Content/Login/vendor/animsition/css/animsition.min.css",
                    "~/Content/Login/vendor/select2/select2.min.css",
                    "~/Content/Login/vendor/daterangepicker/daterangepicker.css"
                ));

            bundles.Add(new StyleBundle("~/Content/portal").Include(
                    "~/Content/Portal/scss/widgets.css",
                    "~/Content/Portal/css/normalize.css",
                    "~/Content/Portal/css/bootstrap.min.css",
                    "~/Content/Portal/css/font-awesome.min.css",
                    "~/Content/Portal/css/themify-icons.css",
                    "~/Content/Portal/css/flag-icon.min.css",
                    "~/Content/Portal/css/cs-skin-elastic.css",
                    "~/Content/Portal/scss/style.css",
                    "~/Content/Portal/css/lib/vector-map/jqvmap.min.css"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}

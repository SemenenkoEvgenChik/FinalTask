using System.Web.Optimization;

namespace Hospital.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                       "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/Site.css"
            ));
            bundles.Add(new ScriptBundle("~/Scripts").Include(

                "~/Scripts/bootstrap.min.js"
            ));
        }
    }
}

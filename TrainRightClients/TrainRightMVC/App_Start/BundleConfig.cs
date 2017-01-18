using System.Web.Optimization;

namespace TrainRightMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add((new ScriptBundle("~/bundles/jquery")).Include("~/Scripts/jquery-{version}.js", new IItemTransform[0]));
            bundles.Add((new ScriptBundle("~/Scripts/kendo/2016.1.226/scripts")).Include("~/Scripts/kendo/2016.1.226/jszip.min.js", new IItemTransform[0]).Include("~/Scripts/kendo/2016.1.226/kendo.all.min.js", new IItemTransform[0]).Include("~/Scripts/kendo/2016.1.226/kendo.aspnetmvc.min.js", new IItemTransform[0]));
            bundles.Add((new StyleBundle("~/Content/kendo/2016.1.226/css")).Include("~/Content/kendo/2016.1.226/kendo.common.min.css", new IItemTransform[0]).Include("~/Content/kendo/2016.1.226/kendo.mobile.all.min.css", new IItemTransform[0]).Include("~/Content/kendo/2016.1.226/kendo.dataviz.min.css", new IItemTransform[0]).Include("~/Content/kendo/2016.1.226/kendo.default.min.css", new IItemTransform[0]).Include("~/Content/kendo/2016.1.226/kendo.dataviz.default.min.css", new IItemTransform[0]));
            bundles.Add((new ScriptBundle("~/bundles/modernizr")).Include("~/Scripts/modernizr-*", new IItemTransform[0]));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(new string[2]
            {"~/Scripts/bootstrap.js", "~/Scripts/respond.js"}));

            bundles.Add((new StyleBundle("~/Content/css")).Include(new string[2]
            {"~/Content/bootstrap.css", "~/Content/site.css"}));

            

            
        }
    }
}

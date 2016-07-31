﻿namespace Hotel.App
{
    using System.Web.Optimization;

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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/main-script").Include(
                     "~/Scripts/main-script.js"));

            bundles.Add(new ScriptBundle("~/bundles/owlcarouselScript").Include(
                        "~/Scripts/owl.carousel.js"));

            bundles.Add(new StyleBundle("~/Content/OwlCarousel/owlcarouselCss").Include(
                       "~/Content/OwlCarousel/owl.carousel.css",
                       "~/Content/OwlCarousel/owl.theme.css",
                       "~/Content/OwlCarousel/owl.transitions.css"));
        }
    }
}
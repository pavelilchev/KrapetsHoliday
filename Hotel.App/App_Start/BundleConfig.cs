namespace Hotel.App
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
                        "~/Scripts/OwlCarousel/owl.carousel.min.js"));

            bundles.Add(new StyleBundle("~/Content/owlcarouselCss").Include(
                       "~/Content/OwlCarousel/owl.carousel.css",
                       "~/Content/OwlCarousel/owl.theme.css",
                       "~/Content/OwlCarousel/owl.transitions.css"));

            bundles.Add(new ScriptBundle("~/bundles/lightbox").Include(
                      "~/Scripts/Lightbox/lightbox.min.js"));

            bundles.Add(new StyleBundle("~/Content/lightboxCss").Include(
                       "~/Content/Lightbox/lightbox.css"));

            bundles.Add(new ScriptBundle("~/bundles/reviews").Include(
                    "~/Scripts/reviews.js"));

            bundles.Add(new ScriptBundle("~/bundles/contactus").Include(
                   "~/Scripts/contactus.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                  "~/Scripts/jquery.unobtrusive-ajax.min.js"));
            
            bundles.Add(new StyleBundle("~/Content/UI").Include(
                       "~/Content/jQueryUI/jquery-ui.min.css",
                       "~/Content/jQueryUI/jquery-ui.structure.min.css",
                       "~/Content/jQueryUI/jquery-ui.theme.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/UI").Include(
                 "~/Scripts/jQueryUI/jquery-ui.min.js",
                 "~/Scripts/jQueryUI/appointment.js"));
        }
    }
}

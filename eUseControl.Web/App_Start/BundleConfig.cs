using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace eUseControl.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/icomoon/css")
                .Include("~/fonts/icomoon/style.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/DMSans/css")
                .Include("~/fonts.DMSans.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/flaticon/css")
                .Include("~/fonts/flaticon/fonts/flaticon.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/main/css")
                .Include("~/Content/main.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css")
                .Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js")
                .Include("~/Scripts/bootstrap.min.js"));


            // REGISTRATION
            bundles.Add(new StyleBundle("~/bundles/registration/css")
                .Include("~/Content/Registration.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css")
               .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
                "~/Scripts/jquery.validate.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive/js").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
               "~/Scripts/jquery-3.6.0.js"));

            // SlideShow
            bundles.Add(new StyleBundle("~/bundles/slideshow/css")
              .Include("~/Content/slideshow.css", new CssRewriteUrlTransform()));


        }
    }
}
using System.Web.Optimization;

namespace eUseControl.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //css
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                        "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/elegant/css").Include(
                        "~/Content/elegant-icons.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/font/css").Include(
                        "~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/jquery/css").Include(
                        "~/Content/jquery-ui.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/nice/css").Include(
                        "~/Content/nice-select.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/owlcarousel/css").Include(
                        "~/Content/owl.carousel.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/slicknav/css").Include(
                        "~/Content/slicknav.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                        "~/Content/style.css", new CssRewriteUrlTransform()));
            //scripts
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                "~/Scripts/jquery-3.7.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui/js").Include(
                "~/Scripts/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquerynice/js").Include(
                "~/Scripts/jquery.nice-select.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryslicknav/js").Include(
                "~/Scripts/jquery.slicknav.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                "~/Scripts/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/mixitup/js").Include(
                "~/Scripts/mixitup.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/owlcarousel/js").Include(
                "~/Scripts/owl.carousel.min.js"));
        }
    }
}
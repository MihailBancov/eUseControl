using System.Web.Optimization;

namespace eUseControl.Web
{
    public class BunleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //css
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                        "~/Content/CSS/bootstrap.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/elegant/css").Include(
                        "~/Content/CSS/elegant-icons.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/font/css").Include(
                        "~/Content/CSS/font-awesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/jquery/css").Include(
                        "~/Content/CSS/jquery-ui.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/nice/css").Include(
                        "~/Content/CSS/nice-select.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/owlcarousel/css").Include(
                        "~/Content/CSS/owl.carousel.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/slicknav/css").Include(
                        "~/Content/CSS/slicknav.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                        "~/Content/CSS/style.css", new CssRewriteUrlTransform()));
            //scripts
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Scripts/MyScripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                "~/Scripts/MyScripts/jquery-3.3.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui/js").Include(
                "~/Scripts/MyScripts/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquerynice/js").Include(
                "~/Scripts/MyScripts/jquery.nice-select.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryslicknav/js").Include(
                "~/Scripts/MyScripts/jquery.slicknav.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                "~/Scripts/MyScripts/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/mixitup/js").Include(
                "~/Scripts/MyScripts/mixitup.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/owlcarousel/js").Include(
                "~/Scripts/MyScripts/owl.carousel.min.js"));
        }
    }
}
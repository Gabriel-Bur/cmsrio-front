using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //oneui CSS
            bundles.Add(new StyleBundle("~/Content/oneui").Include(
                        "~/Content/css/bootstrap.min.css",
                        "~/Content/css/oneui.min.css"));





            //oneUI JS
            bundles.Add(new ScriptBundle("~/bundles/oneuijs").Include(
                        "~/Content/js/oneui.min.js",
                        "~/Content/js/core/jquery.min.js",
                        "~/Content/js/core/bootstrap.min.js",
                        "~/Content/js/core/jquery.slimscroll.min.js",
                        "~/Content/js/core/jquery.scrollLock.min.js",
                        "~/Content/js/core/jquery.countTo.min.js",
                        "~/Content/js/core/jquery.placeholder.min.js",
                        "~/Content/js/core/js.cookie.min.js",
                        "~/Content/js/app.js",
                        "~/Content/js/plugins/gmapsjs/gmaps.min.js",
                        "~/Content/js/pages/base_comp_maps_full.js"
                        ));





            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


        }
    }
}

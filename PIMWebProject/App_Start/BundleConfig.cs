using System.Web;
using System.Web.Optimization;

namespace PIMWebProject
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Login").Include(
                "~/Scripts/Login/login.js",
                "~/Content/Login/login.css"));

            bundles.Add(new ScriptBundle("~/InAllFile").Include(
                "~/Scripts/inallfile.js"));

            bundles.Add(new ScriptBundle("~/Config").Include(
                "~/Scripts/config.js"));

            bundles.Add(new ScriptBundle("~/Trade.js").Include(
                "~/Scripts/Trades/trades.js"));

            bundles.Add(new ScriptBundle("~/AddTrade.js").Include(
                "~/Scripts/Trades/add-trade.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Mask").Include(
                        "~/Scripts/jquery.mask.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                        "~/Scripts/inputmask/jquery.inputmask.js",
                        "~/Scripts/jquery.moneymask.js"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/login.css",
                      "~/Content/nav.css",
                      "~/Content/trades.css",
                      "~/Content/add-trade.css",
                      "~/Content/config.css"));
        }
    }
}

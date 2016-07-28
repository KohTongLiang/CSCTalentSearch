using System.Web;
using System.Web.Optimization;

namespace TalentSearch
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.UseCdn = true;   //enable CDN support
            BundleTable.EnableOptimizations = true;
            
            bundles.Add(new ScriptBundle("~/bundles/jquery", "https://code.jquery.com/jquery-1.12.4.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr", "https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.6.2/modernizr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap", "https://cdnjs.cloudflare.com/ajax/libs/respond.js/1.4.2/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                      "~/Scripts/script.js"));
            

            
        }
    }
}

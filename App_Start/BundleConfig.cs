using System.Web;
using System.Web.Optimization;

namespace Odata_101
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new StyleBundle("~/todomvc/css").Include(
                "~/Libs/todomvc-common/base.css",
                 "~/Libs/todomvc-app-css/index.css"
            ));

            bundles.Add(new ScriptBundle("~/app/app.js")
                .Include(
                "~/Libs/todomvc-common/base.js",
                "~/Libs/angular/angular.js",
                 "~/Libs/angular-resource/angular-resource.js",
                  "~/Libs/angular-route/angular-route.js",
                "~/Libs/angular-odata-resources/odataresources.min.js",
                "~/js/ang-load.js",
                "~/js/ang-directies.js",
                "~/js/ang-services.js",
                "~/js/ang-controllers.js"));

        }
    }
}

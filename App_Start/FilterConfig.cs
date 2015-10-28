using System.Web;
using System.Web.Mvc;

namespace Odata_101
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new HandleErrorAttribute());
        }
    }
}

using System.Web;
using System.Web.Mvc;

namespace Lab_26_MVC_Again_Again
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

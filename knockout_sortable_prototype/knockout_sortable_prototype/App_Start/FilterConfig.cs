using System.Web;
using System.Web.Mvc;

namespace knockout_sortable_prototype
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
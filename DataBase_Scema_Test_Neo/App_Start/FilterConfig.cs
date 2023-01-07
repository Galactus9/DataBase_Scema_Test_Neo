using System.Web;
using System.Web.Mvc;

namespace DataBase_Scema_Test_Neo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

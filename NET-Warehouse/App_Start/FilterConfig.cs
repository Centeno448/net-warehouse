﻿using System.Web;
using System.Web.Mvc;

namespace NET_Warehouse
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

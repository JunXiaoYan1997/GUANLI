using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GUANLI.Filters;

namespace GUANLI.App_Start
{
    public class FilterConfig
    {
        public static void RegisterFilter(GlobalFilterCollection fileter)
        {
            //fileter.Add(new CustomAuthorizeAttribute());
        }
    }
}
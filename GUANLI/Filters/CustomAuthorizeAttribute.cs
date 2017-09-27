using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GUANLI.Models;

namespace GUANLI.Filters
{
    //public enum userIdentity { none,identity,authorize};
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {
        //public string code { get; set; }
        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (filterContext.HttpContext.Session["user"] == null)
        //    {
        //        //返回登陆页面
        //        UrlHelper url = new UrlHelper(filterContext.RequestContext);
        //        filterContext.Result = new RedirectResult(url.Action("Index", "Login"));
        //    }
        //    string controllername = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        //    Role role = filterContext.HttpContext.Session["role"] as Role;
        //    Module module = role.Module.FirstOrDefault(m => m.Controller == controllername);
        //    if (module == null)
        //    {
        //        UrlHelper url = new UrlHelper(filterContext.RequestContext);
        //        filterContext.Result = new RedirectResult(url.Action("Index", "Login"));
        //    }
        //}
    }
}
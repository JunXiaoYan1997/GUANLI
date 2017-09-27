using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GUANLI.Models;
using GUANLI.Filters;

namespace GUANLI.Controllers
{
    //[CustomAuthorize(code ="identity")]
    public class LoginController : Controller
    {
        rbac rb = new rbac();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Log(string user_name,string user_pwd)
        {
            //rbac rb = new rbac();
            //User us1 = rb.User.FirstOrDefault(u => u.user_name==us.user_name&&u.user_pwd==us.user_pwd);
            //{
            //    if (us1 != null)
            //    {
            //        Session["id"] = us.user_id;
            //        Session["name"] = us.user_name;
            //        return RedirectToAction("index","Home");
            //    }
            //    else
            //    {
            //          return View("index");
            //    }
            //}
            User user = rb.User.FirstOrDefault(u => u.user_name == user_name && u.user_pwd == user_pwd);
            if (user == null) return Json(new { code = 404 });
            Session["user"] = user;
            //保存角色列表
            List<Role> ro = user.Role.ToList();
            Session["roles"] = ro;
            Session["role"] = ro[0];
            Session["rolemodules"] = user.Role.ToDictionary(r => r.role_id, r => r.Module);
            return Json(new { code = 200 });
        }
        public ActionResult zhuc()
        {
            return View();
        }
        public ActionResult zc(string user_name, string user_pwd)
        {
            User us = new User();
            us.user_name = user_name;
            us.user_pwd = user_pwd;
            Role role = rb.Role.FirstOrDefault(u => u.role_id == 1);
            us.Role.Add(role);
            rb.User.Add(us);
            rb.SaveChanges();

            return Json(new { code = 200 });
        }
    }
}
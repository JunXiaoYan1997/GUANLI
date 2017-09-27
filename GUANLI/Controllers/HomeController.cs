using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GUANLI.Models;

namespace GUANLI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        //头部
        public ActionResult tou()
        {
            //头部显示用户名称和列表
            User us = Session["user"] as User;
            List<Role> ro = Session["roles"] as List<Role>;
            List<SelectListItem> rlist = new List<SelectListItem>();
            Role role = Session["role"] as Role;
            foreach (Role item in ro)
            {
                rlist.Add(new SelectListItem()
                {
                    Text = item.role_name,
                    Value = item.role_id.ToString(),
                    Selected = item.role_id == role.role_id
                });
            }
            ViewBag.rlist = rlist;
            return PartialView(us);
        }
           
        //列表
        public ActionResult wei(int id=0)
        {
            //int roleid = 0;
            //if (id == 0)
            //{
            //    roleid = id;
            //}
            //else
            //{
            //    roleid = int.Parse(Request["roleid"]);
            //}
            if (Request["roleid"] != null)
            {
                id = int.Parse(Request["roleid"]);
            }
            else
            {
                Role role = Session["role"] as Role;
                id = role.role_id;
            }
            Dictionary<int, ICollection<Module>> dic = Session["roleModules"] as Dictionary<int, ICollection<Module>>;
            ICollection<Module> module = dic[id];
            return PartialView(module);
        }
    }
}
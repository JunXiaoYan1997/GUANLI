using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GUANLI.Models;

namespace GUANLI.Controllers
{
    public class ModulManageController : Controller
    {
        // GET: ModulManage
        rbac context = new rbac();
        public ActionResult Index()
        {
           // List<Module> mlist = context.Module.ToList();
            return View();
        }
        public ActionResult showdata()
        {
            context.Configuration.ProxyCreationEnabled = false;
            List<Module> mlist = context.Module.ToList();
            var result = new { code = 0, msg = "", count = 500, data = mlist };
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        //添加
        public ActionResult tian()
        {
            return View();
        }
        public ActionResult tianjia(FormCollection fm)
        {
            Module mo = new Module();
            mo.name = fm["uname"];
            mo.Controller = fm["ucontro"];
            context.Module.Add(mo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
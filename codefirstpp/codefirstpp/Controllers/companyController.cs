using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using codefirstpp.Models;

namespace codefirstpp.Controllers
{
    public class companyController : Controller
    {
        MyContext obj = new MyContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult displaydept()
        {
            var deptinfo = obj.department.ToList();
            return View(deptinfo);
        }

        public ActionResult adddept()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adddept(dept d)
        {
            obj.department.Add(d);
            obj.SaveChanges();
            return View("displaydept",obj.department.ToList());
        }

        public ActionResult editdept(int id)
        {
            var dinfo =  obj.department.Find(id);
            return View(dinfo);
        }
        [HttpPost]
        public ActionResult editdept(dept d)
        {
            var dinfo = obj.department.Find(d.did);
            dinfo.dname = d.dname;

            obj.SaveChanges();
            return View("displaydept",obj.department.ToList());

        }

        public ActionResult deletedept(int id)
        {
            var dinfo = obj.department.Find(id);
            obj.department.Remove(dinfo);
            obj.SaveChanges();
            return View("displaydept", obj.department.ToList());
        }



    }
}
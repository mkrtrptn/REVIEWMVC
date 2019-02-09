using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using codefirstpp.Models;
using System.Data.Entity;

namespace codefirstpp.Controllers
{
    public class companyController : Controller
    {
        MyContext obj = new MyContext();
        
        public ActionResult Index()
        {
            return View();
        }

        //department CRUD operations 

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


        //Employee CRUD Operations
        public ActionResult displayemp()
        {
            var einfo = obj.Emps.ToList();
            return View(einfo);
        }
        
        public ActionResult addemp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addemp(emp e)
        {
            obj.Emps.Add(e);
            obj.SaveChanges();
            return View("displayemp",obj.Emps.ToList());
        }

        public ActionResult editemp(int id)
        {
            var einfo = obj.Emps.Find(id);
            return View(einfo);
        }

        [HttpPost]
        public ActionResult editemp(emp e)
        {
            obj.Entry(e).State = EntityState.Modified;
            obj.SaveChanges();
            return View("displayemp",obj.Emps.ToList());
        }

        public ActionResult empdelete(int id)
        {
            var einfo = obj.Emps.Find(id);
            obj.Emps.Remove(einfo);
            obj.SaveChanges();
            return View("displayemp",obj.Emps.ToList());
        }



    }
}
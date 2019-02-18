using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using webapiclientserverapp.Models;

namespace webapiclientserverapp.Controllers
{


    public class employeeAPIController : ApiController
    {
        REVIEWEntities obj = new REVIEWEntities();

        [HttpGet]
        public List<emp> getemployees()
        {

            obj.Configuration.LazyLoadingEnabled = false;
            return obj.emps.ToList();
        }


        [HttpGet]
        public emp getemployee(int eid)
        {

            try
            {
                obj.Configuration.LazyLoadingEnabled = false;
                var empinfo = obj.emps.Find(eid);
                return empinfo;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public string postemployee(emp e)
        {
            try
            {
                obj.emps.Add(e);
                obj.SaveChanges();
                return "success";
            }
            catch (Exception)
            {
                return "failed";
            }
        }

        [HttpPut]
        public string putemployee(emp e)
        {
            try
            {
                obj.Configuration.LazyLoadingEnabled = false;

                var einfo = obj.emps.Find(e.eid);
                einfo.name = e.name;
                einfo.phone = e.phone;
                einfo.did = e.did;
                einfo.email = e.email;
                obj.emps.Add(einfo);
                obj.SaveChanges();
                return "success";

            }
            catch (Exception)
            {
                return "failed";
            }
        }

        [HttpDelete]
        public string deleteemployee(int eid)
        {
            try
            {
                var einfo = obj.emps.Find(eid);
                obj.emps.Remove(einfo);
                obj.SaveChanges();
                return "success";
            }
            catch (Exception)
            {
                return "failed";
            }
        }




    }
}

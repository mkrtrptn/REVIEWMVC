using codefirstinventory.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace codefirstinventory.Controllers
{
    public class eorderController : Controller
    {

        MyContext db = new MyContext();
        public ActionResult Index()
        {
            List<SelectListItem> category = new List<SelectListItem>();
            category.Add(new SelectListItem { Text = "-Select Category-" });
            foreach (var c in db.categories.ToList())
            {
                category.Add(new SelectListItem { Text = c.catedesc, Value = c.cateid.ToString() });
            }
            ViewBag.cat = category;

            return View();
        }

        // ajax call to getproducts based on selected category from dropdown
        public JsonResult getproducts(int cateid)
        {
            var prod = from p in db.products where p.cateid == cateid select new { p.prodid, p.proddesc };
            return Json(prod, JsonRequestBehavior.AllowGet);
        }

        public JsonResult postorder(order o)
        {
            try
            {
                var prod = db.products.ToList();
                var price = prod.First(p => p.prodid == o.prodid);
                var total = price.prodprice * o.quantity;


                var od = new order();
                od.prodid = o.prodid;
                od.quantity = o.quantity;
                od.bill = total;
                db.orders.Add(od);

                db.SaveChanges();
                return Json(total, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return Json("error");

            }


        }


        public JsonResult getorders()
        {
           
            var orders = from o in db.orders
                         join p in db.products on o.prodid equals p.prodid
                         select new /*newcommonclassifrequired*/
                         {
                             /*orderid = */o.orderid,
                             /*proddesc = */p.proddesc,
                             /*prodprice =*/ p.prodprice,
                            /* quantity =*/ o.quantity,
                            /* bill =*/ o.bill
                          };


            return Json(orders);
        }





    }
}
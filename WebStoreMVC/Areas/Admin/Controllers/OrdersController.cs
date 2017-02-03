using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;
using WebStoreMVC.ServiceReference1;

namespace WebStoreMVC.Areas.Admin
{
    public class OrdersController : Controller
    {
        private Service1Client db = new Service1Client();

        // GET: Orders
  

        public ActionResult Index()
        {
            var list = db.GetOrders();
            return View(list);
        }

        //// GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            Order order = db.GetOrderByid(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
       
        //// GET: Orders/Create
  
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Orders/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            var test = order;
            try
            {
                if (ModelState.IsValid)
                {
                    db.AddOrder(order);
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = db.GetOrderByid(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.EditOrder(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            Order order = db.GetOrderByid(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           db.RemoveOrder(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using WebStoreMVC.ServiceReference1;

namespace WebStoreMVC.Areas.Admin
{
    //[Authorize(Roles = "Administrator")]
    public class OrderDetailsController : Controller
    {
        private Service1Client db = new Service1Client();

        // GET: OrderDetails
        public ActionResult Index()
        {
            var list = db.GetOrderDetails();
            return View(list);
        }

        //// GET: OrderDetails/Details/5
        public ActionResult Details(int id)
        {
            OrderDetail orderDetail = db.GetOrderDetailByid(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.GetOrders(), "OrderId", "UserName");
            ViewBag.ProduitId = new SelectList(db.GetProduits(), "ProduitId", "Title");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.AddOrderDetail(orderDetail);
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.GetOrders(), "OrderId", "UserName", orderDetail.OrderId);
            ViewBag.ProduitId = new SelectList(db.GetProduits(), "ProduitId", "Title", orderDetail.ProduitId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int id)
        {
            OrderDetail orderDetail = db.GetOrderDetailByid(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.GetOrders(), "OrderId", "UserName", orderDetail.OrderId);
            ViewBag.ProduitId = new SelectList(db.GetProduits(), "ProduitId", "Title", orderDetail.ProduitId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.EditOrderDetail(orderDetail);
              return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.GetOrders(), "OrderId", "UserName", orderDetail.OrderId);
            ViewBag.ProduitId = new SelectList(db.GetProduits(), "ProduitId", "Title", orderDetail.ProduitId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int id)
        {
            OrderDetail orderDetail = db.GetOrderDetailByid(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.RemoveOrderDetail(id);
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

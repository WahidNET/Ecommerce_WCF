using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using WebStoreMVC.ServiceReference1;

namespace WebStoreMVC.Areas.Admin
{
    //[Authorize(Roles = "Administrator")]
    public class CartsController : Controller
    {
        private Service1Client db = new Service1Client();
       

        // GET: Carts
        public ActionResult Index()
        {
            var list = db.GetCarts();
            return View(list);
        }

        // GET: Carts/Details/5
        public ActionResult Details(int id)
        {
            Cart cart = db.GetCartByid(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            ViewBag.ProduitId = new SelectList(db.GetProduits(), "ProduitId", "Title");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.AddCart(cart);
                return RedirectToAction("Index");
            }

            ViewBag.ProduitId = new SelectList(db.GetProduits(), "ProduitId", "Title", cart.ProduitId);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int id)
        {
            Cart cart = db.GetCartByid(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProduitId = new SelectList(db.GetProduits(), "ProduitId", "Title", cart.ProduitId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.EditCart(cart);
                return RedirectToAction("Index");
            }
            ViewBag.ProduitId = new SelectList(db.GetProduits(), "ProduitId", "Title", cart.ProduitId);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int id)
        {
            Cart cart = db.GetCartByid(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.RemoveCart(id);
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

using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using WebStoreMVC.ServiceReference1;

namespace WebStoreMVC.Areas.Admin
{
    //[Authorize(Roles = "Administrator")]
    public class MarquesController : Controller
    {
        private Service1Client db = new Service1Client();

        // GET: Marques
        public ActionResult Index()
        {
            var list = db.GetMarques();
            return View(list);
        }

        // GET: Marques/Details/5
        public ActionResult Details(int id)
        {

            Marque marque = db.GetMarqueByid(id);
            if (marque == null)
            {
                return HttpNotFound();
            }
            return View(marque);
        }

        // GET: Marques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marque marque)
        {
            if (ModelState.IsValid)
            {
                db.AddMarque(marque);
                return RedirectToAction("Index");
            }

            return View(marque);
        }

        // GET: Marques/Edit/5
        public ActionResult Edit(int id)
        {
            Marque marque = db.GetMarqueByid(id);
            if (marque == null)
            {
                return HttpNotFound();
            }
            return View(marque);
        }

        // POST: Marques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Marque marque)
        {
            if (ModelState.IsValid)
            {
                db.EditMarque(marque);
                return RedirectToAction("Index");
            }
            return View(marque);
        }

        // GET: Marques/Delete/5
        public ActionResult Delete(int id)
        {
      
            Marque marque = db.GetMarqueByid(id);
            if (marque == null)
            {
                return HttpNotFound();
            }
            return View(marque);
        }

        // POST: Marques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.RemoveMarque(id);
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

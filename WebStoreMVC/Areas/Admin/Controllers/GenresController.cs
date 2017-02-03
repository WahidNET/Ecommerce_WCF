using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using WebStoreMVC.ServiceReference1;

namespace WebStoreMVC.Areas.Admin
{
    //[Authorize(Roles = "Administrator")]
    public class GenresController : Controller
    {
        private Service1Client db = new Service1Client();

         //GET: Genres
        public ActionResult Index()
        {
            var list = db.GetGenres();
            return View(list);
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
           
            Genre genre = db.GetGenreByid(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.AddGenre(genre);
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            Genre genre = db.GetGenreByid(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.EditGenre(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            Genre genre = db.GetGenreByid(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.RemoveGenre(id);
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

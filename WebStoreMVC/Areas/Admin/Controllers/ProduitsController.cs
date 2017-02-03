using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStoreMVC.ServiceReference1;
using PagedList;
using System.IO;


namespace WebStoreMVC.Areas.Admin
{
    [Authorize(Roles = "Admin")]
    public class ProduitsController : Controller
    {

        private Service1Client db = new Service1Client();
        // GET: Produits
        public ActionResult Index(int? page, string crit)
        {
          
            var list = db.GetProduits();
            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            return View(list.ToPagedList(pageIndex, pageSize));
        }

        public ActionResult SearchByCriteria(string crit, int? page)
        {

            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;


            if (crit != null)
            {
                var list = db.GetProduitSearchByCriteria(crit);
                return View("Index", list.ToPagedList(pageIndex, pageSize));

            }
            var defaultList = db.GetProduits();

            return View("Index", defaultList.ToPagedList(pageIndex, pageSize));
        }


        public ActionResult SearchProductBy(string crit, int? page)
        {

            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.GetProduitByGenre(crit);

            return View("Index", list.ToPagedList(pageIndex, pageSize));
        }
        public ActionResult SearchProductByMarque(string crit, int? page)
        {
            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.GetProduitByMarque(crit);

            return View("Index", list.ToPagedList(pageIndex, pageSize));
        }

        //// GET: Produits/Details/5
        public ActionResult Details(int id)
        {
            Produit produit = db.GetProduitByid(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        //// GET: Produits/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.GetGenres(), "GenreId", "Name");
            ViewBag.MarqueId = new SelectList(db.GetMarques(), "MarqueId", "Name");
            return View();
        }

        //// POST: Produits/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produit produit, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Image/"), fileName);
                file.SaveAs(path);
                if (ModelState.IsValid)
                {
                    produit.Image = "/Content/Image/" + fileName;
                    db.AddProduit(produit);
                    return RedirectToAction("Index");
                }
            }



            ViewBag.GenreId = new SelectList(db.GetGenres(), "GenreId", "Name");
            ViewBag.MarqueId = new SelectList(db.GetMarques(), "MarqueId", "Name");
            return View(produit);
        }

        // GET: Produits/Edit/5
        public ActionResult Edit(int id)
        {
            Produit produit = db.GetProduitByid(id);
            if (produit == null)
            {
                return HttpNotFound();
            }

            ViewBag.GenreId = new SelectList(db.GetGenres(), "GenreId", "Name", produit.GenreId);
            ViewBag.MarqueId = new SelectList(db.GetMarques(), "MarqueId", "Name", produit.MarqueId);
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produit produit, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Image/"), fileName);
                file.SaveAs(path);
                if (ModelState.IsValid)
                {
                    produit.Image = "/Content/Image/" + fileName;
                    db.EditProduit(produit);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.GenreId = new SelectList(db.GetGenres(), "GenreId", "Name", produit.GenreId);
            ViewBag.MarqueId = new SelectList(db.GetMarques(), "MarqueId", "Name", produit.MarqueId);
            return View(produit);
        }

        // GET: Produits/Delete/5
        public ActionResult Delete(int id)
        {

            Produit produit = db.GetProduitByid(id);
            if (produit == null)
            {
                ;
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.RemoveProduit(id);
            return RedirectToAction("Index");
        }


    }
}

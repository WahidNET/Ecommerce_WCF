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
using WebStoreMVC.Models;


namespace WebStoreMVC.Controllers
{
    public class ProduitsController : Controller
    {

        private Service1Client db = new Service1Client();
        // GET: Produits
        public ActionResult Index(int? page, string crit)
        {

            var list = db.GetProduits();
            int pageSize = 8;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            return View(list.ToPagedList(pageIndex, pageSize));
        }

        public ActionResult SearchByCriteria(string crit, int? page)
        {

            int pageSize = 8;
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

            int pageSize = 8;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.GetProduitByGenre(crit);

            return View("Index", list.ToPagedList(pageIndex, pageSize));
        }
        public ActionResult SearchProductByMarque(string crit, int? page)
        {
            int pageSize = 8;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.GetProduitByMarque(crit);

            return View("Index", list.ToPagedList(pageIndex, pageSize));
        }

        ////// GET: Produits/Details/5
        public ActionResult Details(int id)
        {
            Produit produit = db.GetProduitByid(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }
        [Authorize]
        public ActionResult CustumerOrder()
        {
            var name = System.Web.HttpContext.Current.User.Identity.Name;
            var order = db.GetOrderByCustumer(name);

            return View(order);
        }
        public ActionResult DetailsCustumerOrder(int id)
        {
            var orderDetail = db.GetOrderDetailsCustumer(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        //public ActionResult CustumerOrder()
        //{
        //    var cart = ShoppingCart.GetCart(this.HttpContext);
        //    string myShoppingCartId = ShoppingCart.MyShoppingCartId(this.HttpContext);
        //    // Set up our ViewModel
        //    var viewModel = new ShoppingCartViewModel
        //    {
        //        CartItems = db.ShoppingGetCartItems(myShoppingCartId).ToList(),
        //        CartTotal = db.ShoppingGetTotal(myShoppingCartId)
        //    };
        //    // Return the view
        //    return View(viewModel);
        //}
        ////// GET: Produits/Create
        //public ActionResult Create()
        //{
        //    ViewBag.GenreId = new SelectList(db.GetGenres(), "GenreId", "Name");
        //    ViewBag.MarqueId = new SelectList(db.GetMarques(), "MarqueId", "Name");
        //    return View();
        //}

        ////// POST: Produits/Create
        ////// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ////// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Produit produit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.AddProduit(produit);
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.GenreId = new SelectList(db.GetGenres(), "GenreId", "Name");
        //    ViewBag.MarqueId = new SelectList(db.GetMarques(), "MarqueId", "Name");
        //    return View(produit);
        //}

        //// GET: Produits/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    Produit produit = db.GetProduitByid(id);
        //    if (produit == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.GenreId = new SelectList(db.GetGenres(), "GenreId", "Name", produit.GenreId);
        //    ViewBag.MarqueId = new SelectList(db.GetMarques(), "MarqueId", "Name", produit.MarqueId);
        //    return View(produit);
        //}

        //// POST: Produits/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Produit produit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.EditProduit(produit);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.GenreId = new SelectList(db.GetGenres(), "GenreId", "Name", produit.GenreId);
        //    ViewBag.MarqueId = new SelectList(db.GetMarques(), "MarqueId", "Name", produit.MarqueId);
        //    return View(produit);
        //}

        //// GET: Produits/Delete/5
        //public ActionResult Delete(int id)
        //{

        //    Produit produit = db.GetProduitByid(id);
        //    if (produit == null)
        //    {
        //        ;
        //        return HttpNotFound();
        //    }
        //    return View(produit);
        //}

        //// POST: Produits/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    db.RemoveProduit(id);
        //    return RedirectToAction("Index");
        //}

    }
}

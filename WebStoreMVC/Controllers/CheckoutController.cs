using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStoreMVC.Models;
using WebStoreMVC.ServiceReference1;
using WebStoreMVC.ViewModels;

namespace WebStoreMVC.Controllers
{
    public class CheckoutController : Controller
    {
        private Service1Client db = new Service1Client();
        //const string PromoCode = "FREE";

        //
        // GET: /Checkout/AddressAndPayment
        [Authorize]
        public ActionResult AddressAndPayment(decimal total)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            ViewBag.currentUser = (ApplicationUser)currentUser;
            Order order = new Order();
            order.FristName = currentUser.FristName;
            order.LastName = currentUser.LastName;
            order.Phone = currentUser.Phone;
            order.Stat = currentUser.Stat;
            order.PostalCode = currentUser.PostalCode;
            order.Country = currentUser.Country;
            order.City = currentUser.City;
            order.OrderDate = DateTime.Now;
            order.Adresse = currentUser.Adresse;
            order.Email = currentUser.Email;
            order.UserName = currentUser.UserName;
            order.Total = total;
            return View(order);
        }

        //
        // POST: /Checkout/AddressAndPayment

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {


            string myShoppingCartId = ShoppingCart.MyShoppingCartId(this.HttpContext);

            var order = new Order();
            TryUpdateModel(order);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(order);
                }
                else
                {
                    order.UserName = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    //storeDB.Orders.Add(order);
                    var orderAndIdAttach = db.AddOrder(order);
                    //storeDB.SaveChanges();

                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    //cart.CreateOrder(order);
                    db.ShoppingCreateOrder(orderAndIdAttach, myShoppingCartId);
                    return RedirectToAction("Complete", new { id = orderAndIdAttach.OrderId });
                }

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }


        //GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            string myShoppingCartId = ShoppingCart.MyShoppingCartId(this.HttpContext);
            string name = User.Identity.Name;
            // Validate customer owns this order
            bool isValid = db.ShoppingIsValid(id, name);

            if (isValid)
            {
                var order = db.GetOrderByid(id);
               db.ShoppingRetireProduit(id);
               db.ShoppingEmptyCart(myShoppingCartId);
               return View(order);
            }
            else
            {
                return View("Error");
            }
        }
    }
}

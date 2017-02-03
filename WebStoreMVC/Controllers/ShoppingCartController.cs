using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStoreMVC.ViewModels;
namespace WebStoreMVC.Controllers
{
   
    // TODO corrige le controlleur + rajouter la vue 
  
    public class ShoppingCartController : Controller
    {
        ServiceReference1.Service1Client db = new ServiceReference1.Service1Client();
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            string myShoppingCartId = ShoppingCart.MyShoppingCartId(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = db.ShoppingGetCartItems(myShoppingCartId).ToList(),
                CartTotal = db.ShoppingGetTotal(myShoppingCartId)
            };
            // Return the view
            return View(viewModel);
        }
      
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            string myShoppingCartId = ShoppingCart.MyShoppingCartId(this.HttpContext);
            // Retrieve the album from the database
            var produit = db.GetProduitByid(id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

           db.ShoppingAddToCart(produit,myShoppingCartId);
           var results = new ShoppingCartRemoveViewModel
           {
               
               CartTotal = db.ShoppingGetTotal(myShoppingCartId),
               CartCount = db.ShoppingGetCount(myShoppingCartId),
             
           };
           return Json(results);
        }

        public ActionResult AddManyToCart(int id,int number)
        {
            string myShoppingCartId = ShoppingCart.MyShoppingCartId(this.HttpContext);
            // Retrieve the album from the database
            var produit = db.GetProduitByid(id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            db.ShoppingAddMoreProductToCart(produit,myShoppingCartId,number);

            var results = new ShoppingCartRemoveViewModel
            {

                CartTotal = db.ShoppingGetTotal(myShoppingCartId),
                CartCount = db.ShoppingGetCount(myShoppingCartId),

            };
            return Json(results);

        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            string myShoppingCartId = ShoppingCart.MyShoppingCartId(this.HttpContext);

            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string produitName = db.GetCartByid(id).Produit.Title;

            // Remove from cart
            int? itemCount = db.ShoppingRemoveFromCart(id, myShoppingCartId);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(produitName) +
                    " has been removed from your shopping cart.",
                CartTotal = db.ShoppingGetTotal(myShoppingCartId),
                CartCount = db.ShoppingGetCount(myShoppingCartId),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            string myShoppingCartId = ShoppingCart.MyShoppingCartId(this.HttpContext);

            
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = db.ShoppingGetCount(myShoppingCartId);
            return PartialView("CartSummary");
        }
    }

}

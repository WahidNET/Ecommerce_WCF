using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using StoreDal;
using System.Web;
using System.ServiceModel;

namespace StoreWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {


        public IList<Produit> GetProduits()
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {/*var quizz = (from s in dbContext.Quizzs.Include("Course") select s).ToList();
return quizz;
//dbContext.Quizzs.Include(q => q.Course).ToList();
}*/
                var products = (from s in db.Produit.Include("Marque").Include("Genre") select s).ToList();
                return products;


            }
        }

        public IList<Produit> GetProduitSearchByCriteria(string search)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var products = (from s in db.Produit.Include("Marque").Include("Genre")
                                where s.Title.Contains(search) || s.Genre.Name.Contains(search) || s.Marque.Name.Contains(search)
                                select s).ToList();

                return products;
            }

        }
        public IList<Produit> GetProduitByGenre(string genre)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var products = (from s in db.Produit.Include("Marque").Include("Genre")
                                where s.Genre.Name.Equals(genre)
                                select s).ToList();

                return products;
            }

        }

        public IList<Produit> GetProduitByMarque(string marque)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var products = (from s in db.Produit.Include("Marque").Include("Genre")
                                where s.Marque.Name.Equals(marque)
                                select s).ToList();
                return products;
            }
        }

        public Produit GetProduitByid(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Produit.Include(p => p.Marque)
                    .Include(p => p.Genre)
                    .FirstOrDefault(p => p.ProduitId == id);
                return result;
            }
        }

        public IList<Produit> GetProduitByCategoryId(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                return db.Produit.Where(p => p.GenreId == id).ToList();
            }
            throw new NotImplementedException();
        }

        public Produit AddProduit(Produit produit)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Produit.Add(produit);
                if (db.SaveChanges() > 0) return result;
                return null;
            }

        }

        public Produit RemoveProduit(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                if (id != 0)
                {
                    var result = db.Produit.Remove(db.Produit.Find(id));
                    if (db.SaveChanges() > 0) return result;
                }
                return null;
            }

        }

        public Produit EditProduit(Produit produit)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = produit;
                db.Entry(result).State = EntityState.Modified;
                if (db.SaveChanges() > 0) return result;
            }
            return null;
        }

        public IList<Produit> GetProduitByCriterias(string nom)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {

            }
            throw new NotImplementedException();
        }

        public IList<Genre> GetGenres()
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Genre.ToList();
                return result;
            }
        }

        public Genre GetGenreByid(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Genre.Find(id);
                return result;

            }
        }

        public Genre AddGenre(Genre genre)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Genre.Add(genre);
                if (db.SaveChanges() > 0) return result;
                return null;

            }
        }

        public Genre RemoveGenre(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                if (id != 0)
                {
                    var result = db.Genre.Remove(db.Genre.Find(id));
                    if (db.SaveChanges() > 0) return result;
                }
                return null;
            }
        }

        public Genre EditGenre(Genre genre)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = genre;
                db.Entry(result).State = EntityState.Modified;
                if (db.SaveChanges() > 0) return result;
            }
            return null;
        }

        public IList<Marque> GetMarques()
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Marque.ToList();
                return result;
            }
        }

        public Marque GetMarqueByid(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Marque.Find(id);
                return result;

            }

        }

        public Marque AddMarque(Marque marque)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Marque.Add(marque);
                if (db.SaveChanges() > 0) return result;
                return null;

            }
        }

        public Marque RemoveMarque(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                if (id != 0)
                {
                    var result = db.Marque.Remove(db.Marque.Find(id));
                    if (db.SaveChanges() > 0) return result;
                }
                return null;
            }
        }

        public Marque EditMarque(Marque marque)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = marque;
                db.Entry(result).State = EntityState.Modified;
                if (db.SaveChanges() > 0) return result;
            }
            return null;
        }

        public IList<Cart> GetCarts()
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = (from s in db.Cart.Include("Produit") select s).OrderBy(p => p.DateCreated).ToList();
                return result;
                //var cart = db.Cart.ToList();
                //return cart;
            }

        }

        public Cart GetCartByid(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Cart.Include("Produit").Where(c => c.RecordId == id).FirstOrDefault();

                return result;
            }
        }

        public Cart AddCart(Cart cart)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Cart.Add(cart);
                if (db.SaveChanges() > 0) return result;
                return null;


            }

        }

        public Cart RemoveCart(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                if (id != 0)
                {
                    var result = db.Cart.Remove(db.Cart.Find(id));
                    if (db.SaveChanges() > 0) return result;
                }
                return null;
            }
            throw new NotImplementedException();
        }

        public Cart EditCart(Cart cart)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = cart;
                db.Entry(result).State = EntityState.Modified;
                if (db.SaveChanges() > 0) return result;
            }
            return null;
        }
      

        public IList<Order> GetOrderByCustumer(string email)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = (from s in db.Order where s.Email == email & s.OrderDate == s.OrderDate select s).ToList();
                return result;


            }

        }

        public IList<Order> GetOrders()
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var order = db.Order.ToList();
                return order;

            }
        }

        public Order GetOrderByid(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Order.Find(id);
                return result;

            }

        }

        public Order AddOrder(Order order)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Order.Add(order);
                if (db.SaveChanges() > 0) return result;
                return null;

            }

        }

        public Order RemoveOrder(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                if (id != 0)
                {
                    var result = db.Order.Remove(db.Order.Find(id));
                    if (db.SaveChanges() > 0) return result;
                }
                return null;
            }
            throw new NotImplementedException();
        }

        public Order EditOrder(Order order)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = order;
                db.Entry(result).State = EntityState.Modified;
                if (db.SaveChanges() > 0) return result;
            }
            return null;
        }

        public IList<OrderDetail> GetOrderLinesbyOrder(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {

            }
            throw new NotImplementedException();
        }
  

        public IList<OrderDetail> GetOrderDetails()
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = (from s in db.OrderDetail.Include("Order").Include("Produit") select s).ToList();
                return result;
                //var orderDatail = db.OrderDetail.ToList();
                //return orderDatail;

            }

        }

        public IList<OrderDetail> GetOrderDetailsCustumer(int OrderID)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = (from s in db.OrderDetail.Include("Order").Include("Produit") where s.OrderId == OrderID select s).ToList();
                return result;
                //var orderDatail = db.OrderDetail.ToList();
                //return orderDatail;

            }

        }


        public OrderDetail GetOrderDetailByid(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.OrderDetail.Find(id);
                return result;
            }

        }

        public OrderDetail AddOrderDetail(OrderDetail orderDetail)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.OrderDetail.Add(orderDetail);
                if (db.SaveChanges() > 0) return result;
                return null;

            }
        }

        public OrderDetail RemoveOrderDetail(int id)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                if (id != 0)
                {
                    var result = db.OrderDetail.Remove(db.OrderDetail.Find(id));
                    if (db.SaveChanges() > 0) return result;
                }
                return null;

            }
            throw new NotImplementedException();
        }

        public OrderDetail EditOrderDetail(OrderDetail orderDetail)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = orderDetail;
                db.Entry(result).State = EntityState.Modified;
                if (db.SaveChanges() > 0) return result;
            }
            return null;
        }

        #region ShoppingCart


        string ShoppingCartId { get; set; }

        public void ShoppingAddToCart(Produit produit, string ShoppingCartId)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                // Get the matching cart and produit instances
                var cartItem = db.Cart.SingleOrDefault(
                    c => c.CartId == ShoppingCartId
                    && c.ProduitId == produit.ProduitId);

                if (cartItem == null)
                {
                    // Create a new cart item if no cart item exists
                    cartItem = new Cart
                    {
                        ProduitId = produit.ProduitId,
                        CartId = ShoppingCartId,
                        Count = 1,
                        DateCreated = DateTime.Now
                    };
                    db.Cart.Add(cartItem);

                }
                else
                {
                    // If the item does exist in the cart, 
                    // then add one to the quantity
                    cartItem.Count++;
                }


                // Save changes
                db.SaveChanges();
            }
        }
        public void ShoppingAddMoreProductToCart(Produit produit, string ShoppingCartId, int number)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                // Get the matching cart and produit instances
                var cartItem = db.Cart.SingleOrDefault(
                    c => c.CartId == ShoppingCartId
                    && c.ProduitId == produit.ProduitId);

                if (cartItem == null)
                {
                    // Create a new cart item if no cart item exists
                    cartItem = new Cart
                    {
                        ProduitId = produit.ProduitId,
                        CartId = ShoppingCartId,
                        Count = 1,
                        DateCreated = DateTime.Now
                    };
                    db.Cart.Add(cartItem);

                }
                else
                {
                    // If the item does exist in the cart, 
                    // then add one to the quantity
                    cartItem.Count = number;
                }
                // Save changes


                db.SaveChanges();
            }
        }
        public void ShoppingRetireProduit(int numOrder)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.OrderDetail.Where(o => o.OrderId == numOrder).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ShoppingUpdateStock(item);
                    }
                }
            }

        }
        public void ShoppingUpdateStock(OrderDetail order)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Produit.Find(order.ProduitId);
                result.Quantite -= order.Quantity;
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int? ShoppingRemoveFromCart(int id, string ShoppingCartId)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                // Get the cart
                var cartItem = db.Cart.Single(
                    cart => cart.CartId == ShoppingCartId
                    && cart.RecordId == id);

                int? itemCount = 0;

                if (cartItem != null)
                {
                    db.Cart.Remove(cartItem);
                    //if (cartItem.Count > 1)
                    //{
                    //    cartItem.Count--;
                    //    itemCount = cartItem.Count;
                    //}
                    //else
                    //{
                    //    db.Cart.Remove(cartItem);
                    //}
                    //// Save changes
                    db.SaveChanges();
                }
                return itemCount;
            }
        }
        public void ShoppingEmptyCart(string ShoppingCartId)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var cartItems = db.Cart.Where(
                    cart => cart.CartId == ShoppingCartId);

                foreach (var cartItem in cartItems)
                {
                    db.Cart.Remove(cartItem);
                }
                // Save changes
                db.SaveChanges();
            }
        }
        public List<Cart> ShoppingGetCartItems(string ShoppingCartId)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                return db.Cart.Include("Produit").Where(
                    cart => cart.CartId == ShoppingCartId).ToList();
            }
        }
        public int ShoppingGetCount(string ShoppingCartId)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                // Get the count of each item in the cart and sum them up
                int? count = (from cartItems in db.Cart
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count).Sum();
                // Return 0 if all entries are null
                return count ?? 0;
            }
        }
        public decimal ShoppingGetTotal(string ShoppingCartId)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                // Multiply produit price by count of that produit to get 
                // the current price for each of those produits in the cart
                // sum all produit price totals to get the cart total
                decimal? total = (from cartItems in db.Cart
                                  where cartItems.CartId == ShoppingCartId
                                  select (int?)cartItems.Count *
                                  cartItems.Produit.Price).Sum();

                return total ?? decimal.Zero;
            }
        }

        public void ShoppingMigrateCart(string userName, string ShoppingCartId)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var shoppingCart = db.Cart.Where(
                    c => c.CartId == ShoppingCartId);

                foreach (Cart item in shoppingCart)
                {
                    item.CartId = userName;
                }
                db.SaveChanges();
            }
        }
        public int ShoppingCreateOrder(Order order, string myShoppingCartId)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                decimal? orderTotal = 0;

                var cartItems = ShoppingGetCartItems(myShoppingCartId);


                // Iterate over the items in the cart, 
                // adding the order details for each
                foreach (var item in cartItems)
                {
                    var orderDetail = new OrderDetail
                    {
                        ProduitId = item.ProduitId,
                        OrderId = order.OrderId,
                        UnitPrice = item.Produit.Price,
                        Quantity = item.Count
                    };
                    // Set the order total of the shopping cart
                    orderTotal += (item.Count * item.Produit.Price);

                    db.OrderDetail.Add(orderDetail);

                }
                // Set the order's total to the orderTotal count
                order.Total = orderTotal;

                // Save the order
                db.SaveChanges();
                // Empty the shopping cart
                //EmptyCart();
                // Return the OrderId as the confirmation number
                return order.OrderId;
            }

        }

        public bool ShoppingIsValid(int id, string name)
        {
            using (StoreDbEntities db = new StoreDbEntities())
            {
                var result = db.Order.Any(o => o.OrderId == id && o.UserName == name);
                return result;
            }
        }
        #endregion



       
    }



}


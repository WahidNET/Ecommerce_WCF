using System.Collections.Generic;
using System.ServiceModel;

namespace StoreWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        #region Produit

        [OperationContract]
        IList<Produit> GetProduits();

        [OperationContract]
        Produit GetProduitByid(int id);

        [OperationContract]
        IList<Produit> GetProduitByCategoryId(int id);
        [OperationContract]
        IList<Produit> GetProduitSearchByCriteria(string search);
        [OperationContract]
        IList<Produit> GetProduitByGenre(string genre);
        [OperationContract]

        IList<Produit> GetProduitByMarque(string marque);
        [OperationContract]
        Produit AddProduit(Produit produit);

        [OperationContract]
        Produit RemoveProduit(int id);

        [OperationContract]
        Produit EditProduit(Produit produit);

        [OperationContract]
        IList<Produit> GetProduitByCriterias(string nom);
        #endregion

        #region Genre

        [OperationContract]
        IList<Genre> GetGenres();

        [OperationContract]
        Genre GetGenreByid(int id);

        [OperationContract]
        Genre AddGenre(Genre genre);

        [OperationContract]
        Genre RemoveGenre(int id);

        [OperationContract]
        Genre EditGenre(Genre genre);

        #endregion


        #region Marque

        [OperationContract]
        IList<Marque> GetMarques();

        [OperationContract]
        Marque GetMarqueByid(int id);

        [OperationContract]
        Marque AddMarque(Marque marque);

        [OperationContract]
        Marque RemoveMarque(int id);

        [OperationContract]
        Marque EditMarque(Marque marque);

        #endregion



        #region Cart

        [OperationContract]
        IList<Cart> GetCarts();

        [OperationContract]
        Cart GetCartByid(int id);

        [OperationContract]
        Cart AddCart(Cart cart);

        [OperationContract]
        Cart RemoveCart(int id);

        [OperationContract]
        Cart EditCart(Cart cart);
        #endregion
        #region Order
        [OperationContract]
        IList<Order> GetOrderByCustumer(string email);

        [OperationContract]
        IList<Order> GetOrders();

        [OperationContract]
        Order GetOrderByid(int id);

        [OperationContract]
        Order AddOrder(Order order);

        [OperationContract]
        Order RemoveOrder(int id);

        [OperationContract]
        Order EditOrder(Order order);
        [OperationContract]
        IList<OrderDetail> GetOrderDetailsCustumer(int OrderID);
        #endregion



        #region OrderDetail


        [OperationContract]
        IList<OrderDetail> GetOrderDetails();

        [OperationContract]
        IList<OrderDetail> GetOrderLinesbyOrder(int id);
  
        [OperationContract]
        OrderDetail GetOrderDetailByid(int id);

        [OperationContract]
        OrderDetail AddOrderDetail(OrderDetail orderDetail);

        [OperationContract]
        OrderDetail RemoveOrderDetail(int id);

        [OperationContract]
        OrderDetail EditOrderDetail(OrderDetail orderDetail);

        #endregion
        #region Shopping
        [OperationContract]
        void ShoppingAddToCart(Produit produit, string ShoppingCartId);
        [OperationContract]
        void ShoppingAddMoreProductToCart(Produit produit, string ShoppingCartId, int number);
        [OperationContract]
        int ShoppingCreateOrder(Order orderAndIdAttach, string myShoppingCartId);
        [OperationContract]
        void ShoppingEmptyCart(string ShoppingCartId);
        [OperationContract]
        System.Collections.Generic.List<Cart> ShoppingGetCartItems(string ShoppingCartId);
        [OperationContract]
        int ShoppingGetCount(string ShoppingCartId);
        [OperationContract]
        decimal ShoppingGetTotal(string ShoppingCartId);
        [OperationContract]
        void ShoppingMigrateCart(string userName, string ShoppingCartId);
        [OperationContract]
        int? ShoppingRemoveFromCart(int id, string ShoppingCartId);
        [OperationContract]
        bool ShoppingIsValid(int id, string name);
        [OperationContract]
        void ShoppingRetireProduit(int numOrder);

        #endregion


        // Use a data contract as illustrated in the sample below to add composite types to service operations.
    }
}

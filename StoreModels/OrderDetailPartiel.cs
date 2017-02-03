using System.ComponentModel.DataAnnotations;


    [MetadataType(typeof(OrderDetailMetaData))]
    public partial class OrderDetail
    {

    }
    public class OrderDetailMetaData
    {
       
       
        [Required]
        [Display(Name = "N° de commande")]
        public int OrderId { get; set; }
        [Required]
        [Display(Name = "Produit")]
        public int ProduitId { get; set; }
        [Display(Name = "Quantité")]
        public int Quantity { get; set; }
        [Display(Name = "Montant")]
        public decimal UnitPrice { get; set; }

    }


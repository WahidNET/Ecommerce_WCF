using System.ComponentModel.DataAnnotations;

//Soit on rajoute le namespace partous de nos vue partiel soit on les retire

    [MetadataType(typeof(CartMetaData))]
    public partial class Cart
    {
    }
    public class CartMetaData
    {

        public int RecordId { get; set; }
        [Required]
        [Display(Name = "Enregistrement")]
        public string CartId { get; set; }
        [Required]
        [Display(Name ="Produit" )]
        public int ProduitId { get; set; }
        public int Count { get; set; }
        [Display(Name = "Date")]
        public System.DateTime DateCreated { get; set; }

    }

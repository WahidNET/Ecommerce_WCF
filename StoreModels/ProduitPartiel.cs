using System;
using System.ComponentModel.DataAnnotations;


    [MetadataType(typeof(ProduitMetaData))]
    public partial class Produit
    {

    }

    public class ProduitMetaData
    {
        public int ProduitId { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public Nullable<int> GenreId { get; set; }
        [Required]
        [Display(Name = "Marque")]
        public Nullable<int> MarqueId { get; set; }
        [Required]
        [Display(Name = "Nom du produit")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Prix")]
        public Nullable<decimal> Price { get; set; }
        public string Image { get; set; }
        [Required]
        [Display(Name = "Quantité disponible")]
        public string Quantite { get; set; }
    }
using System.ComponentModel.DataAnnotations;


    [MetadataType(typeof(GenreMetaData))]
    public partial class Genre
    {
    }

    public class GenreMetaData
    {
        [Required]
        [Display(Name = "Categorie")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(1024)]
        public string Description { get; set; }
       
    }

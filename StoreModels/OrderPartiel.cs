using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



    [MetadataType(typeof(OrderMetaData))]
    public partial class Order
    {
    }
    public class OrderMetaData
    {

        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Utilisateur")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("Nom")]
        [StringLength(160)]
        public string FristName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Prénom")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        [DisplayName("Ville")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        [DisplayName("Etat")]
        public string Stat { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Code Postal")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        [DisplayName("Pays")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        [DisplayName("Téléphone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[ScaffoldColumn(false)]
        //public decimal Total { get; set; }

    }

using System.ComponentModel.DataAnnotations;

[MetadataType(typeof(MarqueMetaData))]
public partial class Marque
{

}

public class MarqueMetaData
{
        [Display(Name = "De Marque")]
    public string Name { get; set; }
}

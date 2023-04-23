using System.ComponentModel.DataAnnotations;

namespace HWK4.Models
{
    public class Car
    {
        //Data Specifications
            [Key]
            public int IndexNo { get; set; }
            public string CarName { get; set; }
            public int ReleaseYear { get; set; }
            public string CarCompany { get; set; }
            public string ModelName { get; set; }
            public int CarPrice { get; set; }
        }
    
}
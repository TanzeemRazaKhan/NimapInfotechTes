using System.ComponentModel.DataAnnotations.Schema;

namespace NimapTest.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }= "";
        // Foreign key for Category

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        // Navigation property


        public virtual Category Categories { get; set; } 
    }

}

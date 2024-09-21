using System.ComponentModel.DataAnnotations;

namespace NimapTest.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; } = "";
        
        public Category() { }
    }
}

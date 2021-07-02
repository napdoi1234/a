using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF2.Models
{
    [Table("Product")]
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Manufacture { get; set; }
        public CategoryModel Category { get; set; }
        public int CategoryId { get; set; }
    }
}
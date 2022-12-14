using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAssigment2.Models
{
    public class Product
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacture { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

    [Column(TypeName = "decimal(18, 2)")] // Định dạng tiền tệ
    public decimal Price { get; set; }
    
    public string ImageUrl { get; set; }
    
    // Khóa ngoại
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}
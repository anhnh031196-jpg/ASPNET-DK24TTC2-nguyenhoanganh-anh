using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderDetail
{
    public int Id { get; set; }

    // Khóa ngoại liên kết với đơn hàng
    public int OrderId { get; set; }
    [ForeignKey("OrderId")]
    public Order Order { get; set; } // Navigation property đến Order

    // Khóa ngoại liên kết với sản phẩm
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; } // Navigation property đến Product

    [Required]
    public int Quantity { get; set; }

    // Lưu giá sản phẩm tại thời điểm mua (để bảo toàn lịch sử giao dịch)
    [Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; } 

    [StringLength(255)]
    public string Options { get; set; } // Ví dụ: "50% đường, thêm trân châu"
}
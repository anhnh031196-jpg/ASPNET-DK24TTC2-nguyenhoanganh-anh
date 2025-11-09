using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity; // Cần cho UserId

public class Order
{
    public int Id { get; set; }

    // Thông tin người đặt hàng (có thể là User đã đăng nhập)
    // Dùng string cho UserId khi tích hợp ASP.NET Core Identity
    public string UserId { get; set; } 
    [ForeignKey("UserId")]
    public IdentityUser User { get; set; } // Navigation property đến User

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Vui lòng nhập tên người nhận.")]
    [StringLength(100)]
    public string CustomerName { get; set; }
    
    [Required(ErrorMessage = "Vui lòng nhập địa chỉ giao hàng.")]
    [StringLength(255)]
    public string DeliveryAddress { get; set; }
    
    [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
    [Phone]
    public string PhoneNumber { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    // Trạng thái đơn hàng: 1-Mới, 2-Đang giao, 3-Đã giao, 4-Hủy
    public int OrderStatus { get; set; } = 1; 

    // Navigation property: Một đơn hàng có nhiều chi tiết đơn hàng
    public ICollection<OrderDetail> OrderDetails { get; set; }
}
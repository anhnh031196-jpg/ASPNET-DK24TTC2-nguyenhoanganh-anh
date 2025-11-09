using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationUser : IdentityUser
{
	// Bổ sung các trường thông tin cá nhân (Profile Information)

	[Required(ErrorMessage = "Vui lòng nhập họ tên.")]
	[StringLength(100)]
	public string FullName { get; set; }

	[StringLength(255)]
	public string DefaultAddress { get; set; } // Địa chỉ giao hàng mặc định

	public DateTime? DateOfBirth { get; set; } // Ngày sinh (dùng cho khuyến mãi sinh nhật)

	public bool IsActive { get; set; } = true; // Trạng thái tài khoản

	public DateTime RegistrationDate { get; set; } = DateTime.Now; // Ngày đăng ký

	// Bổ sung các trường liên quan đến giao dịch (Transaction Information)

	[Column(TypeName = "decimal(18, 2)")]
	public decimal TotalSpent { get; set; } = 0; // Tổng tiền đã chi tiêu (dùng cho cấp độ thành viên)

	public int OrderCount { get; set; } = 0; // Số lượng đơn hàng đã hoàn thành

	// Navigation property (Mối quan hệ)

	// Một người dùng có thể có nhiều đơn hàng
	public ICollection<Order> Orders { get; set; }

	// Lưu ý: Các trường mặc định như Email, PhoneNumber, PasswordHash đã có sẵn
	// từ lớp cơ sở IdentityUser.
}
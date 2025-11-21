using System;
using System.ComponentModel.DataAnnotations;

namespace WebsiteDatLichChuyenNha.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [Display(Name = "Họ và Tên")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số Điện Thoại")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn ngày chuyển")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Chuyển")]
        public DateTime MoveDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ đi")]
        [Display(Name = "Địa Chỉ Đi")]
        public string FromAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ đến")]
        [Display(Name = "Địa Chỉ Đến")]
        public string ToAddress { get; set; } = string.Empty;

        [Display(Name = "Khoảng Cách (km)")]
        public double Distance { get; set; }

        [Display(Name = "Ước Tính Chi Phí")]
        public decimal EstimatedCost { get; set; }

        [Display(Name = "Ghi Chú")]
        public string? Notes { get; set; }

        [Display(Name = "Ghi Chú Admin")]
        public string? AdminNotes { get; set; }

        [Display(Name = "Trạng Thái")]
        public string Status { get; set; } = "Mới"; // Mới, Đã xác nhận, Đang xử lý, Hoàn thành, Hủy

        [Display(Name = "Ngày Tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign key to User
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}

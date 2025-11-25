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

        [Required(ErrorMessage = "Vui lòng chọn ngày sửa chữa")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Sửa Chữa")]
        public DateTime ServiceDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn loại dịch vụ")]
        [Display(Name = "Loại Dịch Vụ")]
        public string ServiceType { get; set; } = string.Empty;

        [Display(Name = "Ước Tính Chi Phí")]
        public decimal EstimatedCost { get; set; }

        [Display(Name = "Mô Tả Sự Cố / Ghi Chú")]
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

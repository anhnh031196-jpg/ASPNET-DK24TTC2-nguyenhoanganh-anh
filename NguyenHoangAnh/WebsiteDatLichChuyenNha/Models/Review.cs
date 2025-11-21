using System.ComponentModel.DataAnnotations;

namespace WebsiteDatLichChuyenNha.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Đánh giá phải từ 1 đến 5 sao")]
        [Display(Name = "Số Sao")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nhận xét")]
        [StringLength(1000, ErrorMessage = "Nhận xét không được quá 1000 ký tự")]
        [Display(Name = "Nhận Xét")]
        public string Comment { get; set; } = string.Empty;

        [Display(Name = "Phản Hồi Admin")]
        [StringLength(1000)]
        public string? AdminReply { get; set; }

        [Display(Name = "Ngày Đánh Giá")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày Phản Hồi")]
        public DateTime? RepliedAt { get; set; }

        [Display(Name = "Hiển Thị Công Khai")]
        public bool IsPublic { get; set; } = true;
    }
}

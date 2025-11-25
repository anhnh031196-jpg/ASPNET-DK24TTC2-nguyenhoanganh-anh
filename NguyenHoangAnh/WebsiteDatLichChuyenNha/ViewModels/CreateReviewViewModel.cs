using System.ComponentModel.DataAnnotations;

namespace WebsiteDichVuSuaNha.ViewModels
{
    public class CreateReviewViewModel
    {
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn số sao")]
        [Range(1, 5, ErrorMessage = "Đánh giá phải từ 1 đến 5 sao")]
        [Display(Name = "Số Sao")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nhận xét")]
        [StringLength(1000, ErrorMessage = "Nhận xét không được quá 1000 ký tự", MinimumLength = 10)]
        [Display(Name = "Nhận Xét")]
        public string Comment { get; set; } = string.Empty;
    }
}

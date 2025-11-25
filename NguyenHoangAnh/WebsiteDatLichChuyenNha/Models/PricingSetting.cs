using System.ComponentModel.DataAnnotations;

namespace WebsiteDatLichChuyenNha.Models
{
    public class PricingSetting
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Phí dịch vụ cơ bản (VNĐ)")]
        public decimal BaseServiceFee { get; set; } = 200000;

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

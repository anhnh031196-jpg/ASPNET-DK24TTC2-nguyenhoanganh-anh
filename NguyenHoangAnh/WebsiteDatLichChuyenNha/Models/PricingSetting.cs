using System.ComponentModel.DataAnnotations;

namespace WebsiteDatLichChuyenNha.Models
{
    public class PricingSetting
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Giá mỗi km (VNĐ)")]
        public decimal PricePerKm { get; set; } = 15000;

        [Required]
        [Display(Name = "Phí dịch vụ cố định (VNĐ)")]
        public decimal BaseServiceFee { get; set; } = 200000;

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

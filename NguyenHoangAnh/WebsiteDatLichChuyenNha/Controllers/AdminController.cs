using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteDatLichChuyenNha.Data;
using WebsiteDatLichChuyenNha.Models;
using Microsoft.EntityFrameworkCore;

namespace WebsiteDatLichChuyenNha.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Index - Dashboard
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            ViewBag.TotalBookings = bookings.Count;
            ViewBag.NewBookings = bookings.Count(b => b.Status == "Mới");
            ViewBag.ProcessingBookings = bookings.Count(b => b.Status == "Đang xử lý");
            ViewBag.CompletedBookings = bookings.Count(b => b.Status == "Hoàn thành");

            return View(bookings);
        }

        // GET: Admin/Bookings - Manage all bookings
        public async Task<IActionResult> Bookings()
        {
            var bookings = await _context.Bookings
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
            return View(bookings);
        }

        // GET: Admin/BookingDetails
        public async Task<IActionResult> BookingDetails(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Admin/UpdateStatus
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status, string adminNotes)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = status;
            if (!string.IsNullOrEmpty(adminNotes))
            {
                booking.AdminNotes = adminNotes;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("BookingDetails", new { id });
        }

        // GET: Admin/Customers
        public async Task<IActionResult> Customers()
        {
            var customers = await _context.Bookings
                .GroupBy(b => new { b.CustomerName, b.PhoneNumber })
                .Select(g => new
                {
                    CustomerName = g.Key.CustomerName,
                    PhoneNumber = g.Key.PhoneNumber,
                    TotalBookings = g.Count(),
                    LastBooking = g.Max(b => b.CreatedAt)
                })
                .OrderByDescending(c => c.LastBooking)
                .ToListAsync();

            return View(customers);
        }

        // GET: Admin/Pricing
        public async Task<IActionResult> Pricing()
        {
            var pricing = await _context.PricingSettings.FirstOrDefaultAsync();
            if (pricing == null)
            {
                pricing = new PricingSetting
                {
                    PricePerKm = 15000,
                    BaseServiceFee = 200000
                };
            }
            return View(pricing);
        }

        // POST: Admin/UpdatePricing
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePricing(PricingSetting model)
        {
            if (ModelState.IsValid)
            {
                var pricing = await _context.PricingSettings.FirstOrDefaultAsync();
                if (pricing == null)
                {
                    model.UpdatedAt = DateTime.Now;
                    _context.PricingSettings.Add(model);
                }
                else
                {
                    pricing.PricePerKm = model.PricePerKm;
                    pricing.BaseServiceFee = model.BaseServiceFee;
                    pricing.UpdatedAt = DateTime.Now;
                }

                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật bảng giá thành công!";
                return RedirectToAction("Pricing");
            }

            return View("Pricing", model);
        }

        // GET: Admin/Reviews
        public async Task<IActionResult> Reviews()
        {
            var reviews = await _context.Reviews
                .Include(r => r.Booking)
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return View(reviews);
        }

        // GET: Admin/ReviewDetails
        public async Task<IActionResult> ReviewDetails(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.Booking)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Admin/ReplyReview
        [HttpPost]
        public async Task<IActionResult> ReplyReview(int id, string adminReply)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            review.AdminReply = adminReply;
            review.RepliedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            TempData["Success"] = "Phản hồi đánh giá thành công!";
            return RedirectToAction("ReviewDetails", new { id });
        }

        // POST: Admin/ToggleReviewVisibility
        [HttpPost]
        public async Task<IActionResult> ToggleReviewVisibility(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            review.IsPublic = !review.IsPublic;
            await _context.SaveChangesAsync();

            TempData["Success"] = review.IsPublic ? "Đánh giá đã được hiển thị công khai." : "Đánh giá đã được ẩn.";
            return RedirectToAction("ReviewDetails", new { id });
        }
    }
}

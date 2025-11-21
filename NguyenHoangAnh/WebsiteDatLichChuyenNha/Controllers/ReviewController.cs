using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteDatLichChuyenNha.Data;
using WebsiteDatLichChuyenNha.Models;
using WebsiteDatLichChuyenNha.ViewModels;

namespace WebsiteDatLichChuyenNha.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Review/Create/{bookingId}
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create(int bookingId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Check if booking exists and belongs to user
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == bookingId && b.UserId == user.Id);

            if (booking == null)
            {
                TempData["Error"] = "Không tìm thấy đơn hàng hoặc bạn không có quyền đánh giá đơn hàng này.";
                return RedirectToAction("History", "Booking");
            }

            // Check if booking is completed
            if (booking.Status != "Hoàn thành")
            {
                TempData["Error"] = "Chỉ có thể đánh giá đơn hàng đã hoàn thành.";
                return RedirectToAction("History", "Booking");
            }

            // Check if review already exists
            var existingReview = await _context.Reviews
                .FirstOrDefaultAsync(r => r.BookingId == bookingId);

            if (existingReview != null)
            {
                TempData["Error"] = "Bạn đã đánh giá đơn hàng này rồi.";
                return RedirectToAction("History", "Booking");
            }

            ViewBag.Booking = booking;
            return View(new CreateReviewViewModel { BookingId = bookingId });
        }

        // POST: Review/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                // Verify booking ownership
                var booking = await _context.Bookings
                    .FirstOrDefaultAsync(b => b.Id == model.BookingId && b.UserId == user.Id);

                if (booking == null || booking.Status != "Hoàn thành")
                {
                    TempData["Error"] = "Không thể đánh giá đơn hàng này.";
                    return RedirectToAction("History", "Booking");
                }

                var review = new Review
                {
                    BookingId = model.BookingId,
                    UserId = user.Id,
                    Rating = model.Rating,
                    Comment = model.Comment,
                    CreatedAt = DateTime.Now,
                    IsPublic = true
                };

                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Cảm ơn bạn đã đánh giá! Đánh giá của bạn đã được gửi thành công.";
                return RedirectToAction("History", "Booking");
            }

            var bookingData = await _context.Bookings.FindAsync(model.BookingId);
            ViewBag.Booking = bookingData;
            return View(model);
        }

        // GET: Review/MyReviews
        [Authorize]
        public async Task<IActionResult> MyReviews()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var reviews = await _context.Reviews
                .Include(r => r.Booking)
                .Where(r => r.UserId == user.Id)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return View(reviews);
        }

        // GET: Review/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.Booking)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id && r.IsPublic);

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }
    }
}

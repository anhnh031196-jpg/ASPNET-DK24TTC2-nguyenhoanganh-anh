using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebsiteDatLichChuyenNha.Data;
using WebsiteDatLichChuyenNha.Models;
using Microsoft.EntityFrameworkCore;

namespace WebsiteDatLichChuyenNha.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Booking/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var pricing = await _context.PricingSettings.FirstOrDefaultAsync();
            ViewBag.PricePerKm = pricing?.PricePerKm ?? 15000;
            ViewBag.BaseServiceFee = pricing?.BaseServiceFee ?? 200000;
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Calculate estimated cost
                var pricing = await _context.PricingSettings.FirstOrDefaultAsync();
                if (pricing != null)
                {
                    booking.EstimatedCost = (decimal)booking.Distance * pricing.PricePerKm + pricing.BaseServiceFee;
                }

                booking.CreatedAt = DateTime.Now;
                booking.Status = "Mới";

                // Link booking to user if authenticated
                if (User.Identity?.IsAuthenticated == true)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        booking.UserId = user.Id;
                        booking.CustomerName = user.FullName;
                        booking.PhoneNumber = user.PhoneNumber ?? booking.PhoneNumber;
                    }
                }

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                return RedirectToAction("Success", new { id = booking.Id });
            }

            var pricingData = await _context.PricingSettings.FirstOrDefaultAsync();
            ViewBag.PricePerKm = pricingData?.PricePerKm ?? 15000;
            ViewBag.BaseServiceFee = pricingData?.BaseServiceFee ?? 200000;
            return View(booking);
        }

        // GET: Booking/Success
        public async Task<IActionResult> Success(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // GET: Booking/Track
        public IActionResult Track()
        {
            return View();
        }

        // POST: Booking/TrackResult
        [HttpPost]
        public async Task<IActionResult> TrackResult(string phoneNumber)
        {
            var bookings = await _context.Bookings
                .Where(b => b.PhoneNumber == phoneNumber)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return View(bookings);
        }

        // GET: Booking/History (for customers to view their bookings)
        [Authorize]
        public async Task<IActionResult> History()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var bookings = await _context.Bookings
                .Where(b => b.UserId == user.Id)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return View(bookings);
        }
    }
}

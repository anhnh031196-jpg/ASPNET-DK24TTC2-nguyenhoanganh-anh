using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebsiteDatLichChuyenNha.Data;
using WebsiteDatLichChuyenNha.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;

    // User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Configure cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();


// Initialize database and seed roles
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // Ensure database is created
    context.Database.EnsureCreated();

    // Seed roles
    string[] roles = { "Admin", "Staff", "Customer" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Create default admin user
    var adminEmail = "admin@suachuanha.vn";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FullName = "Administrator",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(adminUser, "Admin@123");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

    // Seed sample customers
    var customer1Email = "nguyenvana@gmail.com";
    var customer1 = await userManager.FindByEmailAsync(customer1Email);
    if (customer1 == null)
    {
        customer1 = new ApplicationUser
        {
            UserName = customer1Email,
            Email = customer1Email,
            FullName = "Nguyễn Văn A",
            PhoneNumber = "0901234567",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(customer1, "Customer@123");
        await userManager.AddToRoleAsync(customer1, "Customer");
    }

    var customer2Email = "tranthib@gmail.com";
    var customer2 = await userManager.FindByEmailAsync(customer2Email);
    if (customer2 == null)
    {
        customer2 = new ApplicationUser
        {
            UserName = customer2Email,
            Email = customer2Email,
            FullName = "Trần Thị B",
            PhoneNumber = "0912345678",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(customer2, "Customer@123");
        await userManager.AddToRoleAsync(customer2, "Customer");
    }

    // Seed sample bookings
    if (!context.Bookings.Any())
    {
        var sampleBookings = new List<Booking>
        {
            new Booking
            {
                CustomerName = "Nguyễn Văn A",
                PhoneNumber = "0901234567",
                ServiceDate = DateTime.Now.AddDays(3),
                Address = "123 Nguyễn Huệ, Quận 1, TP.HCM",
                ServiceType = "Sửa chữa điện",
                EstimatedCost = 200000,
                Notes = "Đèn phòng khách không sáng, cần kiểm tra",
                Status = "Đã xác nhận",
                CreatedAt = DateTime.Now.AddDays(-2),
                UserId = customer1.Id
            },
            new Booking
            {
                CustomerName = "Trần Thị B",
                PhoneNumber = "0912345678",
                ServiceDate = DateTime.Now.AddDays(5),
                Address = "456 Lê Lợi, Quận 3, TP.HCM",
                ServiceType = "Sửa chữa nước",
                EstimatedCost = 200000,
                Notes = "Vòi nước bồn rửa bát bị rò rỉ",
                Status = "Mới",
                CreatedAt = DateTime.Now.AddDays(-1),
                UserId = customer2.Id
            },
            new Booking
            {
                CustomerName = "Lê Văn C",
                PhoneNumber = "0923456789",
                ServiceDate = DateTime.Now.AddDays(-5),
                Address = "789 Trần Hưng Đạo, Quận 5, TP.HCM",
                ServiceType = "Sơn nhà & Chống thấm",
                EstimatedCost = 200000,
                Notes = "Tường phòng ngủ bị ẩm mốc, cần xử lý chống thấm",
                Status = "Hoàn thành",
                CreatedAt = DateTime.Now.AddDays(-10)
            },
            new Booking
            {
                CustomerName = "Phạm Thị D",
                PhoneNumber = "0934567890",
                ServiceDate = DateTime.Now.AddDays(1),
                Address = "321 Võ Văn Tần, Quận 3, TP.HCM",
                ServiceType = "Sửa chữa tổng hợp",
                EstimatedCost = 200000,
                Notes = "Cửa phòng ngủ bị kẹt, khóa cửa hỏng",
                Status = "Đang xử lý",
                CreatedAt = DateTime.Now.AddDays(-3),
                AdminNotes = "Đã phân công thợ Minh đến sửa vào 14h chiều nay"
            },
            new Booking
            {
                CustomerName = "Hoàng Văn E",
                PhoneNumber = "0945678901",
                ServiceDate = DateTime.Now.AddDays(-15),
                Address = "555 Điện Biên Phủ, Bình Thạnh, TP.HCM",
                ServiceType = "Sửa chữa điện",
                EstimatedCost = 200000,
                Notes = "Thay công tắc và ổ cắm điện",
                Status = "Hoàn thành",
                CreatedAt = DateTime.Now.AddDays(-20),
                UserId = customer1.Id
            }
        };

        context.Bookings.AddRange(sampleBookings);
        await context.SaveChangesAsync();

        // Seed sample reviews for completed bookings
        var completedBookings = context.Bookings.Where(b => b.Status == "Hoàn thành").ToList();
        if (completedBookings.Any())
        {
            var sampleReviews = new List<Review>
            {
                new Review
                {
                    BookingId = completedBookings[0].Id,
                    UserId = completedBookings[0].UserId ?? customer1.Id,
                    Rating = 5,
                    Comment = "Thợ đến đúng giờ, làm việc nhanh gọn và chuyên nghiệp. Tường nhà sau khi xử lý không còn bị ẩm mốc nữa. Rất hài lòng!",
                    CreatedAt = DateTime.Now.AddDays(-4),
                    IsPublic = true,
                    AdminReply = "Cảm ơn quý khách đã tin tưởng sử dụng dịch vụ. Chúng tôi rất vui khi được phục vụ!",
                    RepliedAt = DateTime.Now.AddDays(-3)
                },
                new Review
                {
                    BookingId = completedBookings[1].Id,
                    UserId = customer1.Id,
                    Rating = 4,
                    Comment = "Dịch vụ tốt, thợ nhiệt tình. Tuy nhiên thời gian chờ hơi lâu một chút.",
                    CreatedAt = DateTime.Now.AddDays(-14),
                    IsPublic = true
                }
            };

            context.Reviews.AddRange(sampleReviews);
            await context.SaveChangesAsync();
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();



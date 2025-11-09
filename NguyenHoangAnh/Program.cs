using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DongNguyenTraSua.Data;
using DongNguyenTraSua.Models; // Namespace chứa ApplicationUser, Product, Order, v.v.

var builder = WebApplication.CreateBuilder(args);

// ====================================================================
// 1. Cấu hình Services (Dependency Injection Container)
// ====================================================================

// --- 1.1. Cấu hình DbContext và Kết nối SQL Server (EF Core) ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- 1.2. Cấu hình ASP.NET Core Identity ---
// Sử dụng ApplicationUser (Custom User Model) và IdentityRole mặc định
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    // Cấu hình yêu cầu mật khẩu (ví dụ: yêu cầu mật khẩu yếu hơn cho phát triển)
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;
})
.AddEntityFrameworkStores<ApplicationDbContext>(); // Đăng ký lưu trữ Identity vào DbContext

// --- 1.3. Cấu hình MVC và Razor Runtime Compilation ---
builder.Services.AddControllersWithViews();

// --- 1.4. Cấu hình Session (Dùng cho Giỏ hàng) ---
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Giỏ hàng tồn tại 30 phút
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Cookie cần thiết cho phiên làm việc
});

var app = builder.Build();

// ====================================================================
// 2. Cấu hình HTTP Request Pipeline (Middleware)
// ====================================================================

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Thêm trang báo lỗi cho Dev, sử dụng cơ sở dữ liệu lỗi
    app.UseMigrationsEndPoint();
}
else
{
    // Sử dụng trang báo lỗi thân thiện với người dùng
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Cho phép truy cập các file trong thư mục wwwroot (CSS, JS, Images)

app.UseRouting();

// Thêm Middleware cho Xác thực (Đăng nhập/Đăng ký) và Phân quyền
app.UseAuthentication();
app.UseAuthorization();

// Thêm Middleware cho Session (Phải đứng trước UseEndpoints)
app.UseSession();

// Cấu hình Định tuyến (Routing)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Cấu hình định tuyến cho Razor Pages của Identity
app.MapRazorPages();

app.Run();
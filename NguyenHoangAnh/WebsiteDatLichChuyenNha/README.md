# 🚚 **Website Đặt Lịch Chuyển Nhà - MoveMaster**

---

## 📖 Giới thiệu

Website **MoveMaster** là một hệ thống đặt lịch chuyển nhà được xây dựng bằng **ASP.NET Core MVC**. Ứng dụng hỗ trợ cả **khách hàng** và **quản trị viên** với các chức năng đầy đủ: tạo đơn đặt lịch, tính phí tự động, tra cứu, quản lý trạng thái, đánh giá dịch vụ và phản hồi từ admin.

---

## ✨ Tính năng nổi bật

- **🗓️ Đặt lịch chuyển nhà** – nhập thông tin khách hàng, địa chỉ, khoảng cách và tự động tính **ước tính chi phí**.
- **🔎 Tra cứu đơn hàng** – khách hàng có thể tra cứu lịch sử đơn bằng số điện thoại.
- **📊 Dashboard admin** – thống kê tổng số đơn, trạng thái (Mới, Đang xử lý, Hoàn thành, Hủy).
- **🛠️ Quản lý đơn hàng** – xem chi tiết, cập nhật trạng thái, ghi chú admin, phân công nhân viên.
- **💰 Quản lý bảng giá** – thiết lập giá mỗi km và phí dịch vụ cố định.
- **⭐ Hệ thống đánh giá** – khách hàng sau khi hoàn thành đơn có thể **đánh giá 1‑5 sao** và để lại nhận xét.
- **🗨️ Phản hồi admin** – admin có thể trả lời đánh giá, bật/tắt hiển thị công khai.
- **🔐 Bảo mật** – CSRF, anti‑forgery token, Identity authentication, role‑based authorization (Admin, Staff, Customer).
- **📱 Responsive** – giao diện Bootstrap 5, tối ưu cho Desktop, Tablet và Mobile.

---

## 🛠️ Công nghệ sử dụng

| Layer | Technology |
|-------|------------|
| **Backend** | ASP.NET Core 9.0 MVC |
| **Database** | SQLite + Entity Framework Core |
| **Frontend** | HTML5, CSS3, JavaScript, Bootstrap 5 |
| **Identity** | ASP.NET Core Identity (ApplicationUser) |
| **Styling** | Modern, premium UI – màu chủ đạo Indigo (`#4F46E5`), phụ Emerald Green (`#10B981`). |

---

## 📂 Cấu trúc dự án (các thư mục quan trọng)

```
Controllers/
│   ├─ AdminController.cs      // Dashboard & quản lý (đơn, khách, bảng giá, review)
│   ├─ BookingController.cs    // Đặt lịch, tính phí, tra cứu, lịch sử
│   ├─ ReviewController.cs     // Tạo, xem, phản hồi review
│   └─ HomeController.cs       // Trang chủ

Models/
│   ├─ Booking.cs              // Đơn đặt lịch
│   ├─ Review.cs               // Đánh giá
│   ├─ PricingSetting.cs       // Bảng giá
│   └─ ApplicationUser.cs      // Identity user

Data/
│   └─ ApplicationDbContext.cs // EF Core DbContext + seed dữ liệu

ViewModels/
│   ├─ CreateReviewViewModel.cs // Dữ liệu tạo review
│   └─ ...

Views/
│   ├─ Admin/…                // Razor views cho admin
│   ├─ Booking/…              // Razor views cho khách
│   ├─ Review/…               // Razor views cho review
│   └─ Home/…                 // Trang chủ
```

---

## 🚀 Hướng dẫn chạy ứng dụng

### 1️⃣ Yêu cầu môi trường
- **.NET 9.0 SDK** (hoặc mới hơn)
- **SQLite** (được tích hợp trong .NET, không cần cài đặt riêng)
- **Git** (để clone repo)

### 2️⃣ Clone và khởi chạy
```bash
# Clone repo
git clone https://github.com/your-repo/WebsiteDatLichChuyenNha.git
cd WebsiteDatLichChuyenNha

# Restore packages & build
dotnet restore
dotnet build

# Chạy ứng dụng
dotnet run --project WebsiteDatLichChuyenNha
```

Mặc định ứng dụng sẽ lắng nghe tại **http://localhost:5216**. Mở trình duyệt và truy cập để xem giao diện.

### 3️⃣ Tạo tài khoản admin (đầu tiên)
1. Đăng ký tài khoản thường tại `/Account/Register`.
2. Mở **SQL Server Explorer** hoặc dùng **SQLite Browser** để cập nhật trường `AspNetRoles` và `AspNetUserRoles` – gán role `Admin` cho tài khoản vừa tạo.
3. Đăng nhập lại, bạn sẽ thấy các menu admin xuất hiện.

---

## 📋 API & Route chính
| Route | Method | Description |
|-------|--------|-------------|
| `/Booking/Create` | GET/POST | Tạo đơn đặt lịch, tính phí tự động |
| `/Booking/Success/{id}` | GET | Trang hiển thị thông tin đơn đã đặt thành công |
| `/Booking/Track` | GET/POST | Tra cứu lịch sử đơn bằng số điện thoại |
| `/Booking/History` | GET (Auth) | Xem lịch sử đơn của người dùng hiện tại |
| `/Review/Create/{bookingId}` | GET/POST (Auth) | Tạo đánh giá cho đơn đã hoàn thành |
| `/Review/MyReviews` | GET (Auth) | Danh sách đánh giá của người dùng |
| `/Admin/Index` | GET (Admin) | Dashboard thống kê |
| `/Admin/Bookings` | GET (Admin) | Quản lý toàn bộ đơn |
| `/Admin/BookingDetails/{id}` | GET (Admin) | Xem chi tiết đơn và cập nhật trạng thái |
| `/Admin/Pricing` | GET/POST (Admin) | Thiết lập bảng giá |
| `/Admin/Reviews` | GET (Admin) | Quản lý các đánh giá |
| `/Admin/ReplyReview` | POST (Admin) | Phản hồi admin cho đánh giá |
| `/Admin/ToggleReviewVisibility` | POST (Admin) | Ẩn/hiện đánh giá công khai |

---

## 🗂️ Database schema (SQLite)

| Table | Columns |
|-------|---------|
| **Bookings** | `Id`, `CustomerName`, `PhoneNumber`, `MoveDate`, `FromAddress`, `ToAddress`, `Distance`, `EstimatedCost`, `Notes`, `AdminNotes`, `Status`, `CreatedAt`, `UserId` |
| **PricingSettings** | `Id`, `PricePerKm`, `BaseServiceFee`, `UpdatedAt` |
| **Reviews** | `Id`, `BookingId`, `UserId`, `Rating`, `Comment`, `AdminReply`, `CreatedAt`, `RepliedAt`, `IsPublic` |
| **AspNetUsers** (Identity) | `Id`, `UserName`, `Email`, `FullName`, `PhoneNumber`, … |
| **AspNetRoles**, **AspNetUserRoles**, … | Identity tables |

---

## 🎨 Thiết kế UI
- **Font**: `Outfit` (Google Fonts)
- **Màu chủ đạo**: Indigo `#4F46E5`
- **Màu phụ**: Emerald Green `#10B981`
- **Hiệu ứng**: fade‑in, hover transition, button ripple
- **Responsive**: sử dụng Grid & Flex của Bootstrap 5 để tự động điều chỉnh layout.

---

## 📦 Deploy (tùy chọn)
```bash
# Publish cho môi trường production
dotnet publish -c Release -o ./publish
# Sau đó copy thư mục publish lên server IIS / Nginx (reverse‑proxy) và cấu hình ASP.NET Core Module.
```

---

## 📝 Ghi chú & Roadmap
- **[✔]** Đã triển khai hệ thống **đánh giá & phản hồi**.
- **[✔]** Bảng giá có thể chỉnh sửa trực tiếp từ admin.
- **[ ]** Thêm **payment gateway** để khách hàng thanh toán online.
- **[ ]]** Tích hợp **email notification** khi đơn chuyển sang trạng thái mới.
- **[ ]** Thêm **đánh giá bằng hình ảnh** và **gallery** cho admin.

---

## 👥 Đóng góp
Mọi đóng góp đều được hoan nghênh! Hãy fork repo, tạo pull request và mô tả chi tiết thay đổi.

---

**Phát triển bởi:** *MoveMaster Team*  
**Ngày tạo:** 21/11/2025  
**Phiên bản hiện tại:** `v1.2.0`

# 🔐 Thông tin đăng nhập hệ thống

## 📋 Tổng quan

Hệ thống sử dụng **ASP.NET Core Identity** để quản lý xác thực và phân quyền người dùng.

---

## 👥 Tài khoản mặc định

Khi chạy ứng dụng lần đầu tiên, hệ thống sẽ tự động tạo các tài khoản sau:

### 1. 👨‍💼 **Admin** (Quản trị viên)

```
Email:    admin@suachuanha.vn
Password: Admin@123
Role:     Admin
```

**Quyền hạn:**
- ✅ Truy cập tất cả chức năng admin
- ✅ Quản lý đơn hàng (xem, cập nhật trạng thái, ghi chú)
- ✅ Quản lý khách hàng
- ✅ Quản lý bảng giá
- ✅ Quản lý đánh giá (phản hồi, ẩn/hiện)
- ✅ Xem dashboard thống kê

**Thông tin chi tiết:**
- Họ tên: Administrator
- Email đã xác thực: ✅ Có

---

### 2. 👤 **Customer 1** (Khách hàng)

```
Email:    nguyenvana@gmail.com
Password: Customer@123
Role:     Customer
```

**Quyền hạn:**
- ✅ Đặt lịch sửa chữa
- ✅ Xem lịch sử đơn hàng của mình
- ✅ Tra cứu đơn hàng
- ✅ Đánh giá dịch vụ
- ✅ Quản lý thông tin cá nhân
- ✅ Đổi mật khẩu

**Thông tin chi tiết:**
- Họ tên: Nguyễn Văn A
- Số điện thoại: 0901234567
- Email đã xác thực: ✅ Có

---

### 3. 👤 **Customer 2** (Khách hàng)

```
Email:    tranthib@gmail.com
Password: Customer@123
Role:     Customer
```

**Quyền hạn:**
- ✅ Đặt lịch sửa chữa
- ✅ Xem lịch sử đơn hàng của mình
- ✅ Tra cứu đơn hàng
- ✅ Đánh giá dịch vụ
- ✅ Quản lý thông tin cá nhân
- ✅ Đổi mật khẩu

**Thông tin chi tiết:**
- Họ tên: Trần Thị B
- Số điện thoại: 0912345678
- Email đã xác thực: ✅ Có

---

## 🔑 Vai trò (Roles) trong hệ thống

### 1. **Admin**
- Quản trị viên hệ thống
- Có quyền truy cập tất cả chức năng
- Quản lý đơn hàng, khách hàng, bảng giá, đánh giá

### 2. **Staff** (Nhân viên)
- Nhân viên hỗ trợ
- Có thể xem và cập nhật đơn hàng
- Không có quyền quản lý bảng giá

### 3. **Customer** (Khách hàng)
- Người dùng thông thường
- Đặt lịch, xem lịch sử, đánh giá dịch vụ

---

## 🚪 Các trang đăng nhập/đăng ký

### Đăng nhập
- **URL**: `/Account/Login`
- **Method**: GET/POST
- **Yêu cầu**: Email + Password
- **Tùy chọn**: Remember Me (Ghi nhớ đăng nhập)

### Đăng ký
- **URL**: `/Account/Register`
- **Method**: GET/POST
- **Yêu cầu**:
  - Họ tên
  - Email
  - Số điện thoại
  - Mật khẩu
  - Xác nhận mật khẩu
- **Vai trò mặc định**: Customer

### Đăng xuất
- **URL**: `/Account/Logout`
- **Method**: POST

---

## 👤 Quản lý tài khoản

### Xem/Cập nhật thông tin cá nhân
- **URL**: `/Account/Profile`
- **Có thể cập nhật**:
  - Họ tên
  - Số điện thoại
- **Không thể thay đổi**: Email (dùng làm username)

### Đổi mật khẩu
- **URL**: `/Account/ChangePassword`
- **Yêu cầu**:
  - Mật khẩu hiện tại
  - Mật khẩu mới
  - Xác nhận mật khẩu mới

---

## 🔒 Yêu cầu mật khẩu

Mật khẩu phải đáp ứng các yêu cầu sau:
- ✅ Tối thiểu **6 ký tự**
- ❌ Không yêu cầu chữ hoa
- ❌ Không yêu cầu chữ thường
- ❌ Không yêu cầu số
- ❌ Không yêu cầu ký tự đặc biệt

> **Lưu ý**: Đây là cấu hình cho môi trường development. Trong production nên tăng cường yêu cầu bảo mật.

---

## 🛡️ Bảo mật

### Authentication
- Sử dụng **ASP.NET Core Identity**
- Cookie-based authentication
- CSRF Protection với Anti-forgery tokens

### Authorization
- Role-based authorization
- Phân quyền theo vai trò (Admin, Staff, Customer)

### Password Hashing
- Sử dụng Identity's default password hasher
- Bcrypt-based hashing

---

## 📝 Cách tạo tài khoản mới

### Qua giao diện web
1. Truy cập `/Account/Register`
2. Điền thông tin đầy đủ
3. Click "Đăng ký"
4. Tự động đăng nhập và chuyển về trang chủ

### Qua code (seed data)
Xem file `Program.cs` để biết cách tạo user trong seed data:

```csharp
var user = new ApplicationUser
{
    UserName = email,
    Email = email,
    FullName = "Tên đầy đủ",
    PhoneNumber = "0123456789",
    EmailConfirmed = true
};

await userManager.CreateAsync(user, "Password@123");
await userManager.AddToRoleAsync(user, "Customer");
```

---

## 🔍 Kiểm tra user đang đăng nhập

### Trong Controller
```csharp
// Lấy user hiện tại
var user = await _userManager.GetUserAsync(User);

// Kiểm tra đã đăng nhập chưa
if (User.Identity?.IsAuthenticated == true)
{
    // User đã đăng nhập
}

// Lấy thông tin
var userId = _userManager.GetUserId(User);
var userName = User.Identity?.Name;

// Kiểm tra role
if (User.IsInRole("Admin"))
{
    // User là admin
}
```

### Trong View (Razor)
```cshtml
@if (User.Identity?.IsAuthenticated == true)
{
    <p>Xin chào, @User.Identity.Name</p>
    
    @if (User.IsInRole("Admin"))
    {
        <a asp-controller="Admin" asp-action="Index">Admin Panel</a>
    }
}
else
{
    <a asp-controller="Account" asp-action="Login">Đăng nhập</a>
}
```

---

## 🗄️ Database

Thông tin user được lưu trong các bảng:
- **AspNetUsers** - Thông tin user
- **AspNetRoles** - Vai trò
- **AspNetUserRoles** - Liên kết user-role
- **AspNetUserClaims** - Claims của user
- **AspNetUserLogins** - Thông tin đăng nhập external
- **AspNetUserTokens** - Tokens

---

## ⚠️ Lưu ý bảo mật

### Development
- ✅ Mật khẩu đơn giản để test
- ✅ Email confirmation tự động

### Production
- ⚠️ **BẮT BUỘC đổi mật khẩu admin**
- ⚠️ Tăng cường yêu cầu mật khẩu
- ⚠️ Bật email confirmation
- ⚠️ Bật two-factor authentication
- ⚠️ Sử dụng HTTPS
- ⚠️ Bật lockout sau nhiều lần đăng nhập sai

---

## 📞 Hỗ trợ

Nếu quên mật khẩu hoặc gặp vấn đề đăng nhập:
1. Liên hệ admin
2. Hoặc reset database và chạy lại seed data

---

**Ngày cập nhật**: 25/11/2025  
**Version**: 2.0.0

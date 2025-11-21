# 🔐 HỆ THỐNG ĐĂNG NHẬP & QUẢN LÝ TÀI KHOẢN

## ✨ TÍNH NĂNG MỚI ĐÃ THÊM

### 🎯 **TỔNG QUAN**
Đã tích hợp **ASP.NET Core Identity** với phân quyền 3 cấp: **Admin**, **Staff**, và **Customer**.

---

## 👥 **PHÂN QUYỀN HỆ THỐNG**

### 1. **Admin** (Quản trị viên)
- Toàn quyền truy cập tất cả chức năng
- Quản lý đơn hàng, khách hàng, bảng giá
- Cập nhật trạng thái đơn hàng
- Phân công nhân viên

### 2. **Staff** (Nhân viên)
- Truy cập trang quản trị
- Xem và cập nhật đơn hàng
- Không thể thay đổi bảng giá

### 3. **Customer** (Khách hàng)
- Đăng ký tài khoản mới
- Đặt lịch chuyển nhà
- Xem lịch sử đơn hàng cá nhân
- Quản lý thông tin cá nhân

---

## 🔑 **TÀI KHOẢN MẶC ĐỊNH**

### Admin Account
```
Email: admin@movemaster.vn
Mật khẩu: Admin@123
```

---

## 📋 **CHỨC NĂNG CHI TIẾT**

### 1. **Đăng Ký Tài Khoản** (`/Account/Register`)
- Form đăng ký với validation
- Tự động gán role "Customer"
- Yêu cầu: Họ tên, Email, SĐT, Mật khẩu
- Tự động đăng nhập sau khi đăng ký thành công

### 2. **Đăng Nhập** (`/Account/Login`)
- Email + Mật khẩu
- Checkbox "Ghi nhớ đăng nhập"
- Cập nhật thời gian đăng nhập cuối
- Redirect về trang trước đó sau khi đăng nhập

### 3. **Thông Tin Cá Nhân** (`/Account/Profile`)
- Xem và chỉnh sửa thông tin
- Họ tên, Email (readonly), SĐT
- Link đến đổi mật khẩu
- Link đến lịch sử đơn hàng

### 4. **Đổi Mật Khẩu** (`/Account/ChangePassword`)
- Nhập mật khẩu hiện tại
- Nhập mật khẩu mới (tối thiểu 6 ký tự)
- Xác nhận mật khẩu mới

### 5. **Lịch Sử Đơn Hàng** (`/Booking/History`)
- **Yêu cầu đăng nhập**
- Chỉ hiển thị đơn hàng của user hiện tại
- Xem trạng thái real-time
- Thông tin đầy đủ: Địa chỉ, chi phí, ngày chuyển

### 6. **Đăng Xuất** (`/Account/Logout`)
- POST request với CSRF protection
- Xóa session và cookie
- Redirect về trang chủ

---

## 🔒 **BẢO MẬT**

### Authentication Features:
✅ **Password Hashing** - Mật khẩu được mã hóa an toàn  
✅ **CSRF Protection** - Chống tấn công Cross-Site Request Forgery  
✅ **Role-based Authorization** - Phân quyền theo vai trò  
✅ **Secure Cookies** - Cookie được mã hóa  
✅ **Email Validation** - Kiểm tra định dạng email  
✅ **Password Requirements** - Yêu cầu mật khẩu tối thiểu 6 ký tự  

### Authorization:
- Trang **Admin** yêu cầu role Admin hoặc Staff
- Trang **Profile** và **History** yêu cầu đăng nhập
- Tự động redirect đến `/Account/Login` nếu chưa đăng nhập
- Hiển thị `/Account/AccessDenied` nếu không đủ quyền

---

## 🎨 **GIAO DIỆN**

### Navbar Updates:
- **Chưa đăng nhập**: Hiển thị "Đăng Nhập" và "Đăng Ký"
- **Đã đăng nhập**: 
  - Dropdown menu với tên user
  - Link đến Profile
  - Link đến Lịch Sử Đơn Hàng
  - Nút Đăng Xuất
- **Admin/Staff**: Hiển thị menu "Quản Trị"

---

## 🗄️ **DATABASE CHANGES**

### Bảng Mới:
- `AspNetUsers` - Thông tin người dùng
- `AspNetRoles` - Danh sách vai trò
- `AspNetUserRoles` - Liên kết user-role
- `AspNetUserClaims` - Claims của user
- `AspNetUserLogins` - External logins
- `AspNetUserTokens` - Tokens
- `AspNetRoleClaims` - Claims của role

### Bảng Cập Nhật:
- **Bookings**:
  - Thêm `UserId` (Foreign Key đến AspNetUsers)
  - Thêm navigation property `User`

### ApplicationUser Properties:
- `Id` (inherited from IdentityUser)
- `UserName` (Email)
- `Email`
- `PhoneNumber`
- `FullName` (custom)
- `CreatedAt` (custom)
- `LastLoginAt` (custom)

---

## 🚀 **CÁCH SỬ DỤNG**

### Khách Hàng Mới:
1. Click "Đăng Ký" trên navbar
2. Điền form đăng ký
3. Tự động đăng nhập
4. Đặt lịch chuyển nhà
5. Xem lịch sử đơn hàng trong Profile

### Khách Hàng Cũ:
1. Click "Đăng Nhập"
2. Nhập email và mật khẩu
3. Truy cập Profile để xem thông tin
4. Xem lịch sử đơn hàng

### Admin:
1. Đăng nhập với tài khoản admin
2. Truy cập "Quản Trị" trên navbar
3. Quản lý tất cả đơn hàng
4. Cập nhật trạng thái và phân công

---

## 📊 **WORKFLOW**

### Đặt Lịch với Tài Khoản:
```
User đăng nhập
    ↓
Vào trang Đặt Lịch
    ↓
Form tự động điền Tên & SĐT từ profile
    ↓
Nhập thông tin chuyển nhà
    ↓
Booking được link với UserId
    ↓
Xem trong Lịch Sử Đơn Hàng
```

### Đặt Lịch Không Tài Khoản:
```
Khách vãng lai
    ↓
Vào trang Đặt Lịch
    ↓
Nhập đầy đủ thông tin
    ↓
Booking không có UserId
    ↓
Tra cứu bằng SĐT
```

---

## 🎯 **LỢI ÍCH**

### Cho Khách Hàng:
✅ Không cần nhập lại thông tin mỗi lần đặt  
✅ Theo dõi lịch sử đơn hàng dễ dàng  
✅ Quản lý thông tin cá nhân  
✅ Bảo mật thông tin  

### Cho Admin:
✅ Phân quyền rõ ràng  
✅ Quản lý khách hàng tốt hơn  
✅ Liên kết đơn hàng với khách hàng  
✅ Phân tích hành vi khách hàng  

---

## 🔧 **TECHNICAL DETAILS**

### Packages Added:
```xml
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="9.0.0" />
```

### Services Configured:
```csharp
- AddIdentity<ApplicationUser, IdentityRole>()
- AddEntityFrameworkStores<ApplicationDbContext>()
- AddDefaultTokenProviders()
```

### Password Policy:
- Minimum length: 6 characters
- No digit required
- No uppercase required
- No special character required
- (Có thể tùy chỉnh trong Program.cs)

---

## 📝 **TESTING**

### Test Scenarios:

1. **Đăng ký tài khoản mới**
   - Vào `/Account/Register`
   - Điền form và submit
   - Kiểm tra tự động đăng nhập

2. **Đăng nhập Admin**
   - Vào `/Account/Login`
   - Email: admin@movemaster.vn
   - Password: Admin@123
   - Kiểm tra menu "Quản Trị" xuất hiện

3. **Đặt lịch với tài khoản**
   - Đăng nhập
   - Vào "Đặt Lịch"
   - Kiểm tra tên và SĐT tự động điền
   - Submit và xem trong "Lịch Sử Đơn Hàng"

4. **Phân quyền**
   - Đăng xuất
   - Thử truy cập `/Admin/Index`
   - Kiểm tra redirect đến Login

---

## 🎉 **KẾT QUẢ**

Website đã có **hệ thống đăng nhập hoàn chỉnh** với:
- ✅ Đăng ký / Đăng nhập / Đăng xuất
- ✅ Phân quyền 3 cấp (Admin, Staff, Customer)
- ✅ Quản lý thông tin cá nhân
- ✅ Lịch sử đơn hàng cá nhân
- ✅ Bảo mật với ASP.NET Identity
- ✅ UI/UX thân thiện

---

**Phát triển bởi: MoveMaster Team**  
**Ngày cập nhật: 21/11/2025**

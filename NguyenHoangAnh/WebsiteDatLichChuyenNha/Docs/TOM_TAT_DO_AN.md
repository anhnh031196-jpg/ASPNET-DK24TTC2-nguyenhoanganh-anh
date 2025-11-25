# TÓM TẮT ĐỒ ÁN

---

## THÔNG TIN ĐỒ ÁN

**Tên đồ án**: Website Dịch Vụ Sửa Chữa Nhà Cửa - Nguyễn Hoàng Anh

**Sinh viên thực hiện**: Nguyễn Hoàng Anh

**Lớp**: DK24TTC2

**Ngành**: Công nghệ thông tin

**Giảng viên hướng dẫn**: [Tên giảng viên]

**Thời gian thực hiện**: [Tháng bắt đầu] - 11/2025

---

## TÓM TẮT

Trong bối cảnh công nghệ số ngày càng phát triển, việc ứng dụng công nghệ thông tin vào các lĩnh vực dịch vụ truyền thống đang trở thành xu hướng tất yếu. Đồ án **"Website Dịch Vụ Sửa Chữa Nhà Cửa - Nguyễn Hoàng Anh"** được phát triển nhằm số hóa quy trình đặt lịch và quản lý dịch vụ sửa chữa nhà cửa, giúp kết nối khách hàng với đội ngũ thợ lành nghề một cách nhanh chóng, hiệu quả và minh bạch.

Hệ thống được xây dựng trên nền tảng **ASP.NET Core 9.0 MVC** - framework hiện đại của Microsoft, kết hợp với **Entity Framework Core** để quản lý cơ sở dữ liệu **Microsoft SQL Server**. Ứng dụng triển khai kiến trúc **Model-View-Controller (MVC)** đảm bảo tính module hóa, dễ bảo trì và mở rộng. Hệ thống xác thực và phân quyền được xây dựng dựa trên **ASP.NET Core Identity** với 3 vai trò chính: Admin, Staff và Customer.

### **Chức năng chính của hệ thống**

**Đối với khách hàng:**
- Đặt lịch sửa chữa trực tuyến với các loại dịch vụ: điện, nước, sơn sửa, chống thấm, tổng hợp
- Tra cứu trạng thái đơn hàng bằng số điện thoại mà không cần đăng nhập
- Xem lịch sử đơn hàng và theo dõi tiến trình xử lý (yêu cầu đăng nhập)
- Đánh giá chất lượng dịch vụ với thang điểm 1-5 sao kèm nhận xét chi tiết
- Quản lý thông tin tài khoản cá nhân

**Đối với quản trị viên (Admin/Staff):**
- Dashboard thống kê tổng quan: tổng đơn, đơn mới, đang xử lý, hoàn thành
- Quản lý đơn hàng: xem chi tiết, cập nhật trạng thái, phân công thợ, ghi chú
- Quản lý khách hàng: xem danh sách và lịch sử đặt lịch
- Quản lý bảng giá dịch vụ
- Quản lý đánh giá: xem, phản hồi, ẩn/hiện đánh giá công khai

### **Cơ sở dữ liệu**

Hệ thống sử dụng 4 bảng chính:
- **Bookings**: Lưu trữ thông tin đơn đặt lịch (khách hàng, dịch vụ, trạng thái, chi phí)
- **Reviews**: Quản lý đánh giá của khách hàng và phản hồi từ admin
- **PricingSettings**: Cấu hình bảng giá dịch vụ cơ bản
- **AspNetUsers**: Quản lý người dùng với các trường mở rộng (FullName, CreatedAt, LastLoginAt)

### **Giao diện người dùng**

Website được thiết kế với giao diện hiện đại, thân thiện và responsive trên mọi thiết bị. Sử dụng **Bootstrap 5.3** kết hợp với **Google Fonts (Inter)** hỗ trợ đầy đủ tiếng Việt. Màu sắc chủ đạo là Indigo (#4F46E5) và Emerald Green (#10B981), tạo cảm giác chuyên nghiệp và đáng tin cậy. Các hiệu ứng fade-in, smooth transitions và hover effects được áp dụng để nâng cao trải nghiệm người dùng.

### **Bảo mật**

Hệ thống đảm bảo tính bảo mật cao với:
- Xác thực người dùng qua ASP.NET Core Identity
- Mã hóa mật khẩu theo chuẩn PBKDF2
- CSRF Protection cho tất cả form
- Role-based Authorization phân quyền truy cập
- Validation dữ liệu đầu vào ở cả client-side và server-side

### **Kết quả đạt được**

Đồ án đã hoàn thành đầy đủ các chức năng đề ra, bao gồm:
- 5 Controllers chính với 30+ action methods
- 20+ Views với giao diện responsive
- 4 Models và 5 ViewModels
- Hệ thống Migration và Seed Data tự động
- Tài liệu kỹ thuật đầy đủ (README, CHANGELOG, MIGRATION_GUIDE, USER_CREDENTIALS)

Hệ thống đã được test thành công trên môi trường development với dữ liệu mẫu, đảm bảo hoạt động ổn định và đáp ứng đầy đủ yêu cầu nghiệp vụ.

### **Ý nghĩa thực tiễn**

Đồ án không chỉ là một bài tập học thuật mà còn có giá trị ứng dụng thực tế cao:
- Giúp doanh nghiệp sửa chữa nhà cửa quản lý đơn hàng hiệu quả, tiết kiệm thời gian và chi phí
- Tạo sự thuận tiện cho khách hàng trong việc đặt lịch và theo dõi tiến trình
- Xây dựng hệ thống đánh giá minh bạch, nâng cao chất lượng dịch vụ
- Có thể mở rộng thành nền tảng marketplace kết nối nhiều đơn vị cung cấp dịch vụ

### **Hướng phát triển**

Hệ thống có tiềm năng phát triển với các tính năng mở rộng:
- Tích hợp thanh toán online (VNPay, MoMo, ZaloPay)
- Gửi thông báo tự động qua Email/SMS
- Upload hình ảnh sự cố và kết quả sửa chữa
- Hệ thống chat trực tiếp với thợ
- Tích hợp Google Maps tính khoảng cách và phí di chuyển
- Phát triển ứng dụng mobile (Flutter/React Native)
- Áp dụng AI để tư vấn và dự đoán chi phí

### **Kết luận**

Đồ án **"Website Dịch Vụ Sửa Chữa Nhà Cửa - Nguyễn Hoàng Anh"** đã thành công trong việc xây dựng một hệ thống quản lý dịch vụ hoàn chỉnh, áp dụng các công nghệ hiện đại và đáp ứng nhu cầu thực tế. Qua quá trình thực hiện, sinh viên đã củng cố và nâng cao kiến thức về lập trình web với ASP.NET Core MVC, Entity Framework Core, thiết kế cơ sở dữ liệu, xây dựng giao diện người dùng và triển khai hệ thống bảo mật. Đây là nền tảng vững chắc để phát triển các ứng dụng web phức tạp hơn trong tương lai.

---

**Từ khóa**: ASP.NET Core MVC, Entity Framework Core, SQL Server, Identity, Booking System, Service Management, Web Application, C#, .NET 9.0

---

**Ngày hoàn thành**: 25/11/2025  
**Phiên bản**: v2.0.0

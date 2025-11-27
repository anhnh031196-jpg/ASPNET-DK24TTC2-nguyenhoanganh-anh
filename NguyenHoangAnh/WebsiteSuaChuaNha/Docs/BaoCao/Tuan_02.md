# Báo cáo tiến độ - Tuần 2

**Họ và tên:** Nguyen Hoang Anh  
**MSSV:** DK24TTC2 - 170124155  
**Dự án:** Xây dựng website đặt dịch vụ sửa chữa nhà cửa (ASP.NET)  
**Thời gian:** 20/10/2025 – 26/10/2025  

---

## 1. Công việc đã hoàn thành

- Hoàn thành báo cáo lý do chọn đề tài và phân tích yêu cầu hệ thống.
- Thiết kế ERD (Entity Relationship Diagram) cho cơ sở dữ liệu.
- Tạo 4 Models chính: Booking, Review, PricingSetting, ApplicationUser.
- Cấu hình kết nối SQL Server LocalDB trong `appsettings.json`.
- Tạo ApplicationDbContext kế thừa từ IdentityDbContext.
- Viết tài liệu User Stories cho các chức năng chính.

---

## 2. Kế hoạch tuần tiếp theo

- Tạo Migration đầu tiên và cập nhật database.
- Triển khai ASP.NET Core Identity với 3 roles: Admin, Staff, Customer.
- Xây dựng Controller và View cho chức năng đăng ký/đăng nhập.
- Tạo trang chủ với giao diện Bootstrap.
- Viết Seed Data để tạo dữ liệu mẫu.

---

## 3. Khó khăn gặp phải

- Gặp khó khăn trong việc thiết kế quan hệ giữa các bảng.
- Chưa rõ cách cấu hình Identity với custom ApplicationUser.
- Connection string đến SQL Server LocalDB ban đầu bị lỗi.

---

## 4. Ghi chú

- Đã tham khảo tài liệu Microsoft Learn về Entity Framework Core Migrations.
- Cần học thêm về Data Annotations và Fluent API.
- Sẽ tạo diagram Use Case cho hệ thống trong tuần tới.

# Báo cáo tiến độ - Tuần 5

**Họ và tên:** Nguyen Hoang Anh  
**MSSV:** DK24TTC2 - 170124155  
**Dự án:** Xây dựng website đặt dịch vụ sửa chữa nhà cửa (ASP.NET)  
**Thời gian:** 10/11/2025 – 16/11/2025  

---

## 1. Công việc đã hoàn thành

- Xây dựng AdminController với Dashboard hiển thị thống kê tổng quan.
- Tạo trang quản lý đơn hàng (Admin/Bookings) với bảng danh sách và filter.
- Triển khai chức năng xem chi tiết đơn hàng (Admin/BookingDetails).
- Xây dựng chức năng cập nhật trạng thái đơn hàng (UpdateStatus).
- Tạo trang quản lý khách hàng (Admin/Customers).
- Thêm phân quyền [Authorize(Roles = "Admin,Staff")] cho tất cả action Admin.
- Tạo trang quản lý bảng giá (Admin/Pricing).

---

## 2. Kế hoạch tuần tiếp theo

- Xây dựng ReviewController với chức năng tạo đánh giá.
- Tạo form đánh giá với rating 1-5 sao.
- Triển khai chức năng quản lý đánh giá cho Admin.
- Xây dựng chức năng phản hồi đánh giá từ Admin.
- Thêm chức năng ẩn/hiện đánh giá công khai.

---

## 3. Khó khăn gặp phải

- Dashboard statistics query phức tạp, cần tối ưu.
- Chưa biết cách tạo biểu đồ thống kê (chart) trong ASP.NET MVC.
- Filter và search trong trang quản lý đơn hàng còn đơn giản.

---

## 4. Ghi chú

- Đã học được cách sử dụng LINQ để query dữ liệu phức tạp.
- Cần tìm hiểu về Chart.js hoặc ApexCharts để tạo biểu đồ.
- Sẽ refactor code để tách business logic ra khỏi Controller.

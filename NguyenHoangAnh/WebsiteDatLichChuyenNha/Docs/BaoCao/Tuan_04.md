# Báo cáo tiến độ - Tuần 4

**Họ và tên:** Nguyen Hoang Anh  
**MSSV:** DK24TTC2 - 170124155  
**Dự án:** Xây dựng website đặt dịch vụ sửa chữa nhà cửa (ASP.NET)  
**Thời gian:** 03/11/2025 – 09/11/2025  

---

## 1. Công việc đã hoàn thành

- Xây dựng BookingController với các action: Create, Success, Track, History.
- Tạo form đặt lịch với đầy đủ validation (Required, Phone, Date).
- Triển khai chức năng tra cứu đơn hàng bằng số điện thoại (không cần đăng nhập).
- Xây dựng trang lịch sử đơn hàng cho khách hàng đã đăng nhập.
- Tạo _Layout.cshtml với navbar responsive và footer.
- Thêm Google Fonts (Inter) để hỗ trợ tiếng Việt.
- Tạo 5 đơn đặt lịch mẫu trong Seed Data.

---

## 2. Kế hoạch tuần tiếp theo

- Xây dựng AdminController với Dashboard thống kê.
- Tạo trang quản lý đơn hàng cho Admin.
- Triển khai chức năng cập nhật trạng thái đơn hàng.
- Xây dựng trang quản lý khách hàng.
- Thêm phân quyền [Authorize(Roles = "Admin,Staff")].

---

## 3. Khó khăn gặp phải

- Validation ngày hẹn (ServiceDate) phải lớn hơn ngày hiện tại gặp lỗi timezone.
- Chưa biết cách hiển thị thông báo thành công/lỗi một cách đẹp mắt.
- Query để lọc đơn hàng theo số điện thoại còn chậm.

---

## 4. Ghi chú

- Đã học được cách sử dụng TempData để truyền thông báo giữa các action.
- Cần tối ưu query bằng cách thêm index cho cột PhoneNumber.
- Sẽ tìm hiểu về Toastr hoặc SweetAlert để hiển thị notification.

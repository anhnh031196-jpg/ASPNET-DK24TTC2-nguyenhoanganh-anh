# Báo cáo tiến độ - Tuần 6

**Họ và tên:** Nguyen Hoang Anh  
**MSSV:** DK24TTC2 - 170124155  
**Dự án:** Xây dựng website đặt dịch vụ sửa chữa nhà cửa (ASP.NET)  
**Thời gian:** 17/11/2025 – 23/11/2025  

---

## 1. Công việc đã hoàn thành

- Xây dựng ReviewController với các action: Create, MyReviews, Index.
- Tạo CreateReviewViewModel và form đánh giá với rating 1-5 sao.
- Triển khai chức năng tạo đánh giá cho đơn hàng đã hoàn thành.
- Xây dựng trang quản lý đánh giá cho Admin (Admin/Reviews).
- Triển khai chức năng phản hồi đánh giá từ Admin (ReplyReview).
- Thêm chức năng ẩn/hiện đánh giá công khai (ToggleReviewVisibility).
- Tạo 2 đánh giá mẫu trong Seed Data.
- Cải thiện giao diện với hiệu ứng fade-in và hover effects.

---

## 2. Kế hoạch tuần tiếp theo

- Hoàn thiện tài liệu README.md với hướng dẫn cài đặt chi tiết.
- Viết CHANGELOG.md để ghi lại lịch sử thay đổi.
- Tạo tài liệu USER_CREDENTIALS.md với thông tin đăng nhập demo.
- Kiểm tra và fix các bug còn tồn đọng.
- Tối ưu hiệu năng và bảo mật.
- Chuẩn bị demo và báo cáo cuối kỳ.

---

## 3. Khó khăn gặp phải

- Hiển thị rating dạng sao (★) gặp vấn đề về font encoding.
- Chưa biết cách ngăn khách hàng đánh giá nhiều lần cho cùng một đơn.
- Validation để chỉ cho phép đánh giá đơn đã hoàn thành còn thiếu.

---

## 4. Ghi chú

- Đã học được cách sử dụng Unicode emoji để hiển thị sao.
- Cần thêm unique constraint cho (BookingId, UserId) trong bảng Reviews.
- Sẽ viết Unit Test cho các chức năng quan trọng nếu có thời gian.

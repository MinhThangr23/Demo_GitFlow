## Restaurant App 🍽️

Dự án nhóm tại trường. Trong dự án này tôi chịu trách nhiệm:
- Xây dựng phần lớn giao diện UX/UI của bài
- Thiết kế giao diện bằng WinForms.
- Kết nối với cơ sở dữ liệu SQL Server.

## Công nghệ sử dụng
- C#
- SQL Server
- WinForms

## 📄 Hướng dẫn sửa đường dẫn báo cáo FastReport

### ✅ Mục đích
Thay thế đường dẫn **cố định** trong form `AdminCheckoutFrm` bằng đường dẫn **phù hợp với máy của bạn** đến file `ItemWiseReport.frx` nằm trong thư mục `Reports` của project.

---

### 🔧 Cách sửa

1. Mở file `AdminCheckoutFrm.cs`
2. Tìm dòng (khoảng dòng 78):

```csharp
report.Load("C:/Users/Phu/Desktop/.net project/Menu Management/Reports/ItemWiseReport.frx");
```

3. Thay thế đường dẫn bằng đường dẫn của file `ItemWiseReport.frx` trên máy của bạn. File này thường nằm trong thư mục `Reports` của project.




---

## 🍽️ Hướng dẫn thêm danh mục và món ăn vào CSDL

### ✅ Mục đích
Cung cấp dữ liệu mẫu cho hệ thống — bao gồm **danh mục món ăn (Categories)** và **món ăn (Dishes)** kèm hình ảnh — để hiển thị đúng trên ứng dụng.

---

### 🧱 Cách thực hiện

#### 1. Bật cấu hình cho phép đọc file ảnh từ máy tính

Trước tiên, bật quyền đọc file qua `OPENROWSET` bằng các lệnh SQL sau:

```sql
EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;
EXEC sp_configure 'Ad Hoc Distributed Queries', 1;
RECONFIGURE;

INSERT INTO Categories VALUES
  ('DESSRT','Dessert', (SELECT * FROM Openrowset(BULK 'C:\<đường-dẫn>\dessert.jpg', SINGLE_BLOB) AS Img)),
  ('DRINKS','Drinks', (SELECT * FROM Openrowset(BULK 'C:\<đường-dẫn>\drinks.jpg', SINGLE_BLOB) AS Img)),
  ('MAINCR','Main Course', (SELECT * FROM Openrowset(BULK 'C:\<đường-dẫn>\mainCourse.jpg', SINGLE_BLOB) AS Img)),
  ('SALADS','Salad', (SELECT * FROM Openrowset(BULK 'C:\<đường-dẫn>\salad.jpg', SINGLE_BLOB) AS Img));

```

Thay <đường-dẫn> bằng đường dẫn thật trên máy của bạn dẫn đến thư mục chứa ảnh.


## 🔐 Tài khoản đăng nhập mặc định

Hệ thống đã tạo sẵn 2 tài khoản mẫu trong CSDL:

| Loại tài khoản | Tên đăng nhập | Mật khẩu  |
|----------------|----------------|-----------|
| Admin          | `admin`        | `123456`  |
| Nhân viên      | `employee1`    | `123456`  |

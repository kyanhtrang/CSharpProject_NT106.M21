# CSharpProject_NT106.M21
Đề tài đồ án: Ứng dụng quản lý thời gian

Cả folder báo cáo (đã chỉnh sửa) tụi em cập nhật luôn ở git

Vì chưa thể xử lý hết xung đột của LAN và SQL nên tụi em tách ra làm 2 file 'ChessProject' và 'Local' để cô dễ đánh giá.
File 'ChessProject' bao gồm Client và Server, giao diện Menu, đăng nhập tới Ip local host, và truy xuất SQL (Chơi cờ chưa hoàn chỉnh)

Cách truy cập SQLserver:
- Cần cài đặt sa account để đăng nhập vào SQL, tham khảo link sau để kích hoạt tài khoản sa và tạo mật khẩu: https://sudeeptaganguly.wordpress.com/2010/04/20/how-to-enable-sa-account-in-sql-server/
- Vào SQL Server Configuration Manager trên máy tính bằng cách chọn đường dẫn file phù hợp với phiên bản hiện hành trong link tham khảo: https://docs.microsoft.com/en-us/sql/relational-databases/sql-server-configuration-manager?view=sql-server-ver16
- Sau khi đã mở Configuration Manager, tại mục "SQL Server Services", có các mục:
	+ SQL Server (SQLEXPRESS)
	+ SQL Server Agent
	+ SQL Server Browser
chuột phải "SQL Server (SQLEXPRESS)" (cái đầu tiên ạ) và restart.
- Đăng nhập vào SQL, tại Authentication chọn "SQL server authentication" và đăng nhập với login: "sa" và pasword vừa tạo và bấm connect là thành công.
- Chạy câu lệnh trong COVUA.SQL để có cơ sở dữ liệu.

Kết nối Server với SQL tại máy: lấy server name của máy, ví dụ: "DESKTOP-8PTOJHV\SQLEXPRESS" và mật khẩu ở trên và kết nối là thành công từ server đến SQL.
Tham khảo các thao tác của client ở video demo từ ... đến ...

File 'Local' bao gồm Client và Server, thực hiện chơi cờ vua ở mạng LAN 
Tham khảo video demo từ ... đến ...


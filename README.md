1. Giới thiệu

Xây dựng ứng dụng điều khiển nhà thông minh bằng C#, sử dụng ba Design Pattern:

- Factory Pattern
- Singleton Pattern
- Facade Pattern

Hệ thống quản lý ba loại thiết bị: SmartLight, SmartFan và SmartDoor.

2. Cấu trúc thiết kế

Factory Pattern

- Vị trí: `Factories/DeviceFactory.cs`.
- Chức năng: Tạo thiết bị dựa trên loại do người dùng lựa chọn.
- Lợi ích: Tách quá trình khởi tạo đối tượng khỏi client.
- Hạn chế: Khi bổ sung loại thiết bị mới, cần cập nhật Factory.

Singleton Pattern

- Vị trí: `Configurations/HomeConfiguration.cs`.
- Chức năng: Quản lý cấu hình chung của ngôi nhà.
- Lợi ích: Đảm bảo ứng dụng sử dụng chung một đối tượng cấu hình.
- Hạn chế: Tạo trạng thái toàn cục và gây khó khăn cho unit test.

Facade Pattern

- Vị trí: `Facades/SmartHomeFacade.cs`.
- Chức năng: Cung cấp hai chế độ GoToWork và GoToSleep.
- Lợi ích: Đơn giản hóa việc điều khiển nhiều thiết bị.
- Hạn chế: Facade có thể trở nên phức tạp nếu có quá nhiều chức năng điều khiển.

3. Kết quả kiểm thử

| Test | Nội dung | Kết quả |
|---|---|---|
| T1 | Tạo light, fan, door | Đúng kiểu đối tượng |
| T2 | Tạo camera chưa hỗ trợ | ArgumentException |
| T3 | Kiểm tra Singleton | True |
| T4 | GoToWork() | Đèn tắt, quạt tắt, cửa khóa |
| T5 | GoToSleep() | Quạt tắt, cửa khóa, đèn bật, hiện mức sáng |

4. Câu hỏi và trả lời

Câu 1. Factory đang che giấu quyết định thiết kế nào?

Factory che giấu quyết định lựa chọn lớp cụ thể và quá trình khởi tạo đối tượng. Client không cần biết constructor của từng thiết bị.

Câu 2. Singleton bảo đảm điều gì, nhưng tạo ra rủi ro nào?

Singleton đảm bảo sử dụng chung một thể hiện cấu hình. Tuy nhiên, nó tạo ra trạng thái toàn cục, làm giảm tính linh hoạt và gây khó khăn khi kiểm thử.

Câu 3. Facade khác Factory ở mục đích chính như thế nào?

Factory giải quyết vấn đề tạo đối tượng, còn Facade giải quyết vấn đề đơn giản hóa việc sử dụng một nhóm đối tượng.

Câu 4. Nếu bỏ SmartHomeFacade, client sẽ phải biết thêm những chi tiết nào?

Client phải biết từng thiết bị, các phương thức điều khiển và thứ tự gọi phương thức tương ứng cho từng chế độ hoạt động.


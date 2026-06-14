---
trigger: always_on
---

# Quy tắc phát triển dự án The Lamb (Roguelike Game)

## Phiên bản unity 6000.3.13f1

## 1. Tổng quan dự án
- **Thể loại**: Top-down Action Roguelike (Lấy cảm hứng từ Soul Knight, Cult of the Lamb).
- **Mục tiêu kiến trúc**: Mã nguồn phải có tính module hóa cao, dễ dàng mở rộng thêm nhân vật, vũ khí và kẻ địch (điều kiện cốt lõi của dòng game roguelike).

## 2. Tiêu chuẩn Kiến trúc (Architecture Standards)

### A. Quản lý trạng thái (State Pattern)
- Mọi logic hành vi phức tạp của nhân vật (Player, Enemy, Boss) bắt buộc phải triển khai theo **State Pattern**.
- Tránh sử dụng các khối lệnh `if/else` hoặc `switch/case` khổng lồ để kiểm tra hành động.
- Các trạng thái (State) như: `IdleState`, `MoveState`, `DashState`, `AttackState` phải là các lớp độc lập, được cô lập logic rõ ràng.

### B. Tiêm phụ thuộc (Dependency Injection - DI Pattern)
- Cấm lạm dụng Singleton cho mọi Manager và hạn chế gọi `GetComponent()` trong hàm `Update()`.
- Các hành vi (Behavior) và hệ thống (như quản lý vũ khí, di chuyển, trạng thái máu) phải được thiết kế theo **Dependency Injection Pattern**.
- Các lớp con không tự khởi tạo thành phần phụ thuộc mà phải nhận sự tiêm (inject) từ các hệ thống khởi tạo (Installer/Context) bên ngoài. Việc này đảm bảo tính đóng gói và dễ dàng thay thế logic, cũng như phục vụ tốt cho việc viết Unit Test.

### C. Hệ thống đầu vào (Input System)
- Bắt buộc tách biệt hoàn toàn logic nhận tín hiệu đầu vào (Input) ra khỏi logic thực thi hành động của nhân vật.
- Lớp Input chỉ chịu trách nhiệm nhận thao tác người dùng và phát ra các sự kiện (Event).
- Các State sẽ lắng nghe (Subscribe) các sự kiện này để phản hồi (ví dụ: `MoveState` lắng nghe tín hiệu trục di chuyển từ Input).

### D. Dữ liệu tĩnh (ScriptableObject)
- Sử dụng kiến trúc Data-Driven bằng ScriptableObject để lưu trữ các chỉ số gốc.
- Chỉ Đọc (Read-only), tuyệt đối Cấm Ghi (Write) vào ScriptableObject thông qua Code để tránh lỗi ghi đè file Asset khi chạy trên Unity Editor.

### E. Nguyên tắc Trách nhiệm Đơn (Single Responsibility Principle - SRP)
- Một lớp nghiệp vụ (Player, Enemy, Boss) chỉ nên biết và phụ thuộc vào những thứ nó trực tiếp sử dụng để thực hiện đúng trách nhiệm của mình.
- **Cấm** để `PlayerController` (hay bất kỳ lớp nghiệp vụ nào) giữ tham chiếu đến các hệ thống không liên quan đến logic của nó (ví dụ: `CameraFollow`, `UIManager`, v.v.) chỉ để làm cầu nối gọi một method khởi tạo.
- **Tầng Installer** (`GameInstaller`) là nơi duy nhất chịu trách nhiệm "nối dây" (wire) các dependency giữa các hệ thống với nhau. Nếu hệ thống A cần biết về B để khởi tạo, `Installer` là nơi gọi `B.SetTarget(A.transform)`, không phải bản thân A.
- **Ví dụ đúng**:
  ```csharp
  // GameInstaller.cs - noi duy nhat biet ve ca Player lan Camera
  activePlayer.Initialize(activeInput);
  cameraFollow.SetTarget(activePlayer.transform);
  ```
- **Ví dụ sai**:
  ```csharp
  // PlayerController.cs - Player khong nen biet ve Camera
  public CameraFollow cameraFollow { get; private set; }
  public void Initialize(...) { cameraFollow.SetTarget(transform); }
  ```

## 3. Quy chuẩn chung
- Áp dụng triệt để các kỹ năng thực tiễn từ thư mục ECC Framework khi gặp tác vụ tương ứng (viết test, refactor, review code).
- Tuyệt đối không dùng ký tự dải phân cách (như `// =========`) trong comment.
- Không sử dụng biểu tượng cảm xúc (emoji).
- **Lưu giữ Ngữ cảnh (Context Preservation)**: Khi kết thúc một phiên làm việc (hoặc khi chốt xong một tiến độ), tự động tổng hợp và ghi chú lại: công việc đã làm, công việc cần làm tiếp, các bug đang tồn đọng, và các phần mã cần test. Điều này đảm bảo tính kế thừa hoàn hảo cho mọi phiên làm việc tiếp theo.
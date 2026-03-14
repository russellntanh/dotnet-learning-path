# C# Learning Path — Lộ trình học C#.NET từ cơ bản đến thực chiến

> **Người học:** Russell — Lập trình viên & Quản lý dự án  
> **Mục tiêu:** C# from Intermediate to Confident (Code Review, Technical Issue)  
> **Thời gian:** ~1 tiếng/ngày, 5 ngày/tuần  
> **Công cụ:** Visual Studio 2022, .NET 8, GitHub

---

## Quy tắc làm việc

### Quy trình mỗi ngày (1 tiếng)

```
1. Mở chat với Claude → nói "bắt đầu ngày X"
2. Đọc đề bài + giải thích concept (15 phút)
3. Tự code trên Visual Studio (30 phút)
4. Commit + push lên GitHub
5. Paste code vào chat để Claude review (15 phút)
6. Sửa theo feedback → commit lại
```

### Quy tắc cam kết

| # | Quy tắc | Lý do |
|---|---------|-------|
| 1 | **Tự viết code bằng tay, không copy-paste từ AI** | Muscle memory — gõ code thì mới nhớ |
| 2 | **Chạy thử trước khi commit** | Đảm bảo code hoạt động, không commit code lỗi |
| 3 | **Mỗi ngày ít nhất 1 commit** | Duy trì thói quen, dù chỉ code 30 phút |
| 4 | **Commit message rõ ràng bằng tiếng Anh** | Tập thói quen chuyên nghiệp |
| 5 | **Khi không hiểu → hỏi ngay, không đoán** | Hiểu sai từ đầu sẽ sai cả chuỗi sau |
| 6 | **Hoàn thành bài trước mới qua bài sau** | Mỗi bài xây trên bài trước, không nhảy cóc |
| 7 | **Cuối mỗi tuần tự review lại code đầu tuần** | Thấy mình tiến bộ + phát hiện chỗ cần cải thiện |

### Quy ước commit message

```
Format: [day-XX] <mô tả ngắn>

Ví dụ:
[day-01] Create project and print team members
[day-01] Fix: add missing semicolon
[day-02] Add Developer class with properties
[day-02] Refactor: rename field to follow convention
```

### Cấu trúc thư mục

```
csharp-learning-path/
├── README.md                    ← File này
├── phase-a-fundamentals/
│   ├── week-01/
│   │   ├── day-01-variables/
│   │   │   └── TeamManager/    ← Console App project
│   │   ├── day-02-class-object/
│   │   ├── day-03-constructor/
│   │   ├── day-04-list-loop/
│   │   └── day-05-methods/
│   ├── week-02/
│   ├── week-03/
│   └── week-04/
├── phase-b-oop/
│   ├── week-05/
│   ├── week-06/
│   ├── week-07/
│   └── week-08/
├── phase-c-async-patterns/
│   ├── week-09/
│   ├── week-10/
│   ├── week-11/
│   └── week-12/
└── phase-d-real-project/
    ├── week-13/
    ├── week-14/
    ├── week-15/
    └── week-16/
```

---

## Giai đoạn A — Nền tảng C# (Tuần 1–4)

**Dự án xuyên suốt:** Quản lý danh sách nhân viên team (Console App)

> Giai đoạn này anh sẽ xây một app quản lý team developers từ zero.
> Mỗi ngày thêm 1 khả năng mới. Cuối giai đoạn A sẽ có app hoàn chỉnh:
> thêm/sửa/xóa developer, lưu file JSON, in báo cáo team.

### Tuần 1 — Biến, Class, List, Method

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 01 | Biến và kiểu dữ liệu | In danh sách 5 thành viên team ra console | `string`, `int`, `double`, `Console.WriteLine` |
| 02 | Class và Object | Tạo class `Developer` thay vì dùng biến rời | Class, object, field, tại sao cần đóng gói |
| 03 | Constructor và Properties | Khởi tạo Developer đúng cách | Constructor, `get/set`, access modifier |
| 04 | List và vòng lặp | Quản lý danh sách nhiều developers | `List<T>`, `foreach`, `for`, `while` |
| 05 | Method | Tách logic thành các hành động rõ ràng | Method, parameter, return, tại sao cần tách |

### Tuần 2 — Enum, LINQ, Dictionary

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 06 | Enum | Dùng enum cho Level và Role thay vì string | `enum`, type safety, tại sao không dùng string |
| 07 | LINQ cơ bản | Lọc và sắp xếp danh sách dev | `Where`, `OrderBy`, `Select`, `First` |
| 08 | LINQ nâng cao | Thống kê: đếm theo level, tính trung bình | `GroupBy`, `Count`, `Sum`, `Average` |
| 09 | Dictionary | Map developer → danh sách skills | `Dictionary<K,V>`, khi nào dùng, truy xuất |
| 10 | Tổng hợp tuần 2 | Mini report: phân bổ nhân sự theo level + role | Kết hợp LINQ + enum + dictionary |

### Tuần 3 — File I/O, JSON, Exception

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 11 | File I/O cơ bản | Lưu danh sách team ra file text, đọc lại | `File.WriteAllText`, `File.ReadAllLines` |
| 12 | JSON serialization | Lưu/đọc danh sách dạng JSON | `System.Text.Json`, `Serialize`, `Deserialize` |
| 13 | Exception handling | Xử lý lỗi: file không tồn tại, JSON sai format | `try/catch/finally`, loại exception |
| 14 | Validation | Kiểm tra dữ liệu đầu vào | Validate trước khi tạo object, defensive coding |
| 15 | Tổng hợp tuần 3 | App hoàn chỉnh: thêm/xóa/sửa dev, lưu file | Kết hợp tất cả tuần 1-3 |

### Tuần 4 — Clean Code & Refactoring

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 16 | Refactoring là gì | Xem lại code 3 tuần qua, tìm code smell | Code smell, tại sao code chạy đúng chưa đủ |
| 17 | Đặt tên và method nhỏ | Refactor: đổi tên biến/method cho rõ nghĩa | Clean Code chapter 1-2 |
| 18 | Tách class | Tách thành `DeveloperRepository` + `TeamReporter` | Mỗi class 1 trách nhiệm (SRP sơ khai) |
| 19 | Static vs Instance | Hiểu khi nào dùng static | `static` method, `static` class, utility |
| 20 | Review tổng giai đoạn A | Claude review toàn bộ code, cho feedback tổng thể | Self-review, code quality checklist |

**✅ Kết quả cuối giai đoạn A:**
- Console app quản lý team, lưu JSON, in report
- Hiểu vững: class, list, LINQ, file I/O, exception, clean code
- Sẵn sàng cho OOP nâng cao

---

## Giai đoạn B — Hướng đối tượng thực chiến (Tuần 5–8)

**Dự án xuyên suốt:** Hệ thống chấm điểm Code Review

> Giai đoạn này anh sẽ hiểu TẠI SAO cần interface, kế thừa, polymorphism
> thông qua việc xây hệ thống đánh giá code review cho team.

### Tuần 5 — Interface và Abstraction

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 21 | Vấn đề: code cứng nhắc | Viết code KHÔNG dùng interface, thấy vấn đề | Tight coupling, khó thay đổi |
| 22 | Interface là gì | Tạo `IScoreCalculator` interface | Interface, contract, implement |
| 23 | Nhiều implementation | 2 cách tính điểm: Simple và Weighted | Polymorphism qua interface |
| 24 | Dependency Injection thủ công | Truyền interface qua constructor | Constructor injection, loose coupling |
| 25 | Tổng hợp tuần 5 | So sánh code trước/sau khi dùng interface | Lợi ích thực tế của abstraction |

### Tuần 6 — Kế thừa và Polymorphism

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 26 | Kế thừa cơ bản | Tạo `ReviewItem` base → `BugFix`, `Feature` | `class B : A`, `base`, `override` |
| 27 | Abstract class vs Interface | Khi nào dùng cái nào | `abstract class`, so sánh với interface |
| 28 | Polymorphism | Xử lý danh sách `ReviewItem` đa hình | Gọi method qua base type |
| 29 | Khi nào KHÔNG nên kế thừa | Composition over Inheritance | Favor composition, tránh kế thừa sâu |
| 30 | Tổng hợp tuần 6 | Hệ thống review xử lý nhiều loại review item | Kết hợp interface + kế thừa |

### Tuần 7 — Generic và Collection nâng cao

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 31 | Generic class | Tạo `Repository<T>` dùng cho mọi entity | `class Repo<T>`, type parameter |
| 32 | Generic constraint | Giới hạn T phải implement interface | `where T : IEntity` |
| 33 | IEnumerable và yield | Hiểu lazy evaluation | `IEnumerable<T>`, `yield return` |
| 34 | Delegate và Lambda | Truyền hành vi như tham số | `Func<T>`, `Action<T>`, lambda `=>` |
| 35 | Tổng hợp tuần 7 | Generic repository + filter bằng lambda | Kết hợp generics + delegates |

### Tuần 8 — SOLID cơ bản qua thực hành

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 36 | Single Responsibility | Refactor: mỗi class 1 việc | SRP thực chiến |
| 37 | Open-Closed Principle | Thêm loại review mới mà không sửa code cũ | OCP, Strategy pattern sơ khai |
| 38 | Dependency Inversion | Tách data access khỏi business logic | DIP, interface ở đúng layer |
| 39 | DI Container cơ bản | Dùng `Microsoft.Extensions.DependencyInjection` | ServiceCollection, composition root |
| 40 | Review tổng giai đoạn B | Claude review toàn bộ, cho feedback | So sánh code ngày 21 vs ngày 40 |

**✅ Kết quả cuối giai đoạn B:**
- Hiểu interface, kế thừa, polymorphism qua project thật
- Viết được generic class, dùng delegate/lambda
- Hiểu SOLID principles đủ để review code
- Sẵn sàng cho async và design patterns

---

## Giai đoạn C — Async & Design Patterns (Tuần 9–12)

**Dự án xuyên suốt:** Tool đọc dữ liệu từ REST API

> Giai đoạn này anh sẽ học async/await, HttpClient, và các design patterns
> thường gặp — chuẩn bị cho việc kết nối Jira API ở giai đoạn D.

### Tuần 9 — Async/Await từ zero

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 41 | Tại sao cần async | Demo: UI bị treo khi gọi API đồng bộ | Blocking vs non-blocking |
| 42 | Task và async/await | Viết method async đầu tiên | `Task`, `async`, `await`, return type |
| 43 | Async với File I/O | Đọc/ghi file bất đồng bộ | `ReadAllTextAsync`, khi nào cần async |
| 44 | Xử lý lỗi trong async | Try/catch với async method | Exception trong Task, `AggregateException` |
| 45 | Tổng hợp tuần 9 | Đọc file JSON async + xử lý lỗi | Kết hợp async + exception handling |

### Tuần 10 — HttpClient và REST API

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 46 | HttpClient cơ bản | Gọi API public (JSONPlaceholder) | `HttpClient`, `GetAsync`, status code |
| 47 | Deserialize JSON response | Parse JSON thành C# object | `JsonSerializer.Deserialize<T>` |
| 48 | POST, PUT, DELETE | Gửi data lên API | `PostAsync`, `StringContent`, HTTP methods |
| 49 | HttpClient best practices | Tránh socket exhaustion | `IHttpClientFactory`, `using`, lifecycle |
| 50 | Tổng hợp tuần 10 | CRUD app hoàn chỉnh với REST API | Kết hợp HttpClient + async + JSON |

### Tuần 11 — Design Patterns thực chiến

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 51 | Strategy Pattern | Nhiều cách format output (Console, JSON, CSV) | IReportFormatter + implementations |
| 52 | Factory Pattern | Tạo object đúng loại dựa trên input | Factory method, tránh switch dài |
| 53 | Repository Pattern | Tách data access layer | IRepository, tại sao cần tách |
| 54 | Observer Pattern (sơ khai) | Event khi data thay đổi | `event`, `EventHandler`, subscribe |
| 55 | Tổng hợp tuần 11 | App dùng 3+ patterns | Kết hợp patterns một cách tự nhiên |

### Tuần 12 — Unit Testing

| Ngày | Chủ đề | Mục tiêu | Concept chính |
|------|--------|----------|---------------|
| 56 | xUnit cơ bản | Viết test đầu tiên: `[Fact]` | Test project, assert, chạy test |
| 57 | Arrange-Act-Assert | Cấu trúc test chuẩn | AAA pattern, test naming convention |
| 58 | Moq và Mock object | Mock dependency để test isolated | `Mock<T>`, `Setup`, `ReturnsAsync` |
| 59 | FluentAssertions | Viết assert dễ đọc | `.Should().Be()`, `.HaveCount()` |
| 60 | Review tổng giai đoạn C | Claude review, cho feedback | So sánh code giai đoạn A vs C |

**✅ Kết quả cuối giai đoạn C:**
- Viết async code thành thạo
- Gọi REST API, xử lý JSON
- Áp dụng 4 design patterns
- Viết unit test với mock
- SẴN SÀNG cho dự án Jira Dashboard

---

## Giai đoạn D — Dự án thực chiến: Jira Team Dashboard (Tuần 13–16)

**Dự án:** Kết nối Jira Server, tự động tạo weekly report

> Đây là lúc anh tổng hợp tất cả kiến thức từ 12 tuần trước
> vào một sản phẩm thật sự dùng được hàng ngày.

### Tuần 13 — Core Domain + Jira API

| Ngày | Chủ đề | Mục tiêu | Concept tổng hợp |
|------|--------|----------|-----------------|
| 61 | Phân tích yêu cầu | Xác định models cần thiết | Domain modeling |
| 62 | Tạo Models | Sprint, JiraIssue, MemberReport | Class design từ giai đoạn A |
| 63 | Tạo Interfaces | IJiraClient, IReportGenerator | Interface từ giai đoạn B |
| 64 | Kết nối Jira API | Implement JiraServerClient | HttpClient + async từ giai đoạn C |
| 65 | Test Jira connection | Viết test + thử gọi API thật | Unit test từ giai đoạn C |

### Tuần 14 — Business Logic + Report

| Ngày | Chủ đề | Mục tiêu | Concept tổng hợp |
|------|--------|----------|-----------------|
| 66 | SprintReportService | Logic tổng hợp data | SRP, DIP |
| 67 | ConsoleReportGenerator | Format output dạng text | Strategy pattern |
| 68 | JsonReportGenerator | Format output dạng JSON | OCP — thêm format mới |
| 69 | DI Container setup | Nối tất cả trong Program.cs | Composition root |
| 70 | End-to-end test | Chạy app với Jira thật | Integration testing |

### Tuần 15 — Nâng cấp + Error Handling

| Ngày | Chủ đề | Mục tiêu | Concept tổng hợp |
|------|--------|----------|-----------------|
| 71 | Pagination | Xử lý Jira trả về nhiều trang | Async loop, API pagination |
| 72 | Error handling nâng cao | Retry khi API lỗi, timeout | Exception handling nâng cao |
| 73 | Logging | Thêm logging có ý nghĩa | `ILogger`, log level |
| 74 | Configuration | appsettings.json, Options pattern | Configuration binding |
| 75 | Code review toàn bộ | Claude review toàn bộ project | Clean code, SOLID review |

### Tuần 16 — Hoàn thiện + Mở rộng

| Ngày | Chủ đề | Mục tiêu | Concept tổng hợp |
|------|--------|----------|-----------------|
| 76 | Refactor lần cuối | Clean up code, xóa duplication | Refactoring techniques |
| 77 | README + Documentation | Viết hướng dẫn sử dụng | Technical writing |
| 78 | Thêm tính năng: CRM alert | Cảnh báo issue critical chưa assign | Mở rộng không sửa code cũ |
| 79 | Thêm tính năng: so sánh sprint | So sánh sprint hiện tại vs trước | Data analysis |
| 80 | Tổng kết lộ trình | Review toàn bộ hành trình 16 tuần | Retrospective |

**✅ Kết quả cuối giai đoạn D:**
- Jira Team Dashboard chạy được thật
- Tự động tạo weekly report
- Code chất lượng, có test, có documentation
- Anh tự tin review code của team

---

## Theo dõi tiến độ

### Giai đoạn A — Nền tảng C#

| Ngày | Trạng thái | Ngày hoàn thành | Ghi chú | Tài liệu |
|------|-----------|-----------------|---------|---------|
| 01 | ✅ Hoàn thành | 2026-03-11 | Variable, Data type, string interpolation (nối chuỗi), ternary operator (toán tử 3 ngôi)| [Details](./notes/day-01-variables.md) |
| 02 | ✅ Hoàn thành | 2026-03-12 | Class, Object, Method | [Details](./notes/day-02-class-object.md) |
| 03 | ✅ Hoàn thành | 2026-03-12 | Field, Property, Constructor, Get/Set, Access Modifier | [Detail](./notes/day-03-constructor.md) |
| 04 | ✅ Hoàn thành | 2026-03-13 | List and Loop, Contains | [Detail](./notes/day-04-list-loop.md) |
| 05 | ✅ Hoàn thành | 2026-03-14 | Method and Return, Nullable | [Detail](./notes/day-05-methods.md) |
| 06 | ✅ Hoàn thành | 2026-03-14 | Enum | [Detail](./notes/day-06-enum.md) |
| 07 | ⬜ Chưa bắt đầu | | |
| 08 | ⬜ Chưa bắt đầu | | |
| 09 | ⬜ Chưa bắt đầu | | |
| 10 | ⬜ Chưa bắt đầu | | |
| 11 | ⬜ Chưa bắt đầu | | |
| 12 | ⬜ Chưa bắt đầu | | |
| 13 | ⬜ Chưa bắt đầu | | |
| 14 | ⬜ Chưa bắt đầu | | |
| 15 | ⬜ Chưa bắt đầu | | |
| 16 | ⬜ Chưa bắt đầu | | |
| 17 | ⬜ Chưa bắt đầu | | |
| 18 | ⬜ Chưa bắt đầu | | |
| 19 | ⬜ Chưa bắt đầu | | |
| 20 | ⬜ Chưa bắt đầu | | |

### Giai đoạn B — Hướng đối tượng

| Ngày | Trạng thái | Ngày hoàn thành | Ghi chú |
|------|-----------|-----------------|---------|
| 21 | ⬜ Chưa bắt đầu | | |
| 22 | ⬜ Chưa bắt đầu | | |
| 23 | ⬜ Chưa bắt đầu | | |
| 24 | ⬜ Chưa bắt đầu | | |
| 25 | ⬜ Chưa bắt đầu | | |
| 26 | ⬜ Chưa bắt đầu | | |
| 27 | ⬜ Chưa bắt đầu | | |
| 28 | ⬜ Chưa bắt đầu | | |
| 29 | ⬜ Chưa bắt đầu | | |
| 30 | ⬜ Chưa bắt đầu | | |
| 31 | ⬜ Chưa bắt đầu | | |
| 32 | ⬜ Chưa bắt đầu | | |
| 33 | ⬜ Chưa bắt đầu | | |
| 34 | ⬜ Chưa bắt đầu | | |
| 35 | ⬜ Chưa bắt đầu | | |
| 36 | ⬜ Chưa bắt đầu | | |
| 37 | ⬜ Chưa bắt đầu | | |
| 38 | ⬜ Chưa bắt đầu | | |
| 39 | ⬜ Chưa bắt đầu | | |
| 40 | ⬜ Chưa bắt đầu | | |

### Giai đoạn C — Async & Design Patterns

| Ngày | Trạng thái | Ngày hoàn thành | Ghi chú |
|------|-----------|-----------------|---------|
| 41 | ⬜ Chưa bắt đầu | | |
| 42 | ⬜ Chưa bắt đầu | | |
| 43 | ⬜ Chưa bắt đầu | | |
| 44 | ⬜ Chưa bắt đầu | | |
| 45 | ⬜ Chưa bắt đầu | | |
| 46 | ⬜ Chưa bắt đầu | | |
| 47 | ⬜ Chưa bắt đầu | | |
| 48 | ⬜ Chưa bắt đầu | | |
| 49 | ⬜ Chưa bắt đầu | | |
| 50 | ⬜ Chưa bắt đầu | | |
| 51 | ⬜ Chưa bắt đầu | | |
| 52 | ⬜ Chưa bắt đầu | | |
| 53 | ⬜ Chưa bắt đầu | | |
| 54 | ⬜ Chưa bắt đầu | | |
| 55 | ⬜ Chưa bắt đầu | | |
| 56 | ⬜ Chưa bắt đầu | | |
| 57 | ⬜ Chưa bắt đầu | | |
| 58 | ⬜ Chưa bắt đầu | | |
| 59 | ⬜ Chưa bắt đầu | | |
| 60 | ⬜ Chưa bắt đầu | | |

### Giai đoạn D — Jira Team Dashboard

| Ngày | Trạng thái | Ngày hoàn thành | Ghi chú |
|------|-----------|-----------------|---------|
| 61 | ⬜ Chưa bắt đầu | | |
| 62 | ⬜ Chưa bắt đầu | | |
| 63 | ⬜ Chưa bắt đầu | | |
| 64 | ⬜ Chưa bắt đầu | | |
| 65 | ⬜ Chưa bắt đầu | | |
| 66 | ⬜ Chưa bắt đầu | | |
| 67 | ⬜ Chưa bắt đầu | | |
| 68 | ⬜ Chưa bắt đầu | | |
| 69 | ⬜ Chưa bắt đầu | | |
| 70 | ⬜ Chưa bắt đầu | | |
| 71 | ⬜ Chưa bắt đầu | | |
| 72 | ⬜ Chưa bắt đầu | | |
| 73 | ⬜ Chưa bắt đầu | | |
| 74 | ⬜ Chưa bắt đầu | | |
| 75 | ⬜ Chưa bắt đầu | | |
| 76 | ⬜ Chưa bắt đầu | | |
| 77 | ⬜ Chưa bắt đầu | | |
| 78 | ⬜ Chưa bắt đầu | | |
| 79 | ⬜ Chưa bắt đầu | | |
| 80 | ⬜ Chưa bắt đầu | | |

---

## Ký hiệu trạng thái

- ⬜ Chưa bắt đầu
- 🟡 Đang làm
- ✅ Hoàn thành
- 🔄 Cần sửa lại (sau code review)

---

> **Bắt đầu:** Mở chat với Claude → nói "bắt đầu ngày 1"
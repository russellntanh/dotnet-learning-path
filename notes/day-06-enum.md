# Ngày 06 — Enum

## Key Points

### 1. Enum — tập giá trị cố định, có tên rõ ràng

```csharp
public enum Position
{
    Member,       // = 0
    TeamLeader,   // = 1
    Manager       // = 2
}

Position pos = Position.TeamLeader;  // ✅ Compiler kiểm tra
Position pos = Position.Manger;      // ❌ Lỗi compile — typo bị bắt ngay
```

### 2. String vs Enum

| Tiêu chí | `string` | `enum` |
|---|---|---|
| Typo | Compiler không báo | Báo lỗi ngay |
| So sánh | Phải cẩn thận hoa/thường | `==` luôn chính xác |
| Biết giá trị hợp lệ | Không | Nhìn vào enum definition |
| IntelliSense | Không gợi ý | Gợi ý đầy đủ |
| Thêm giá trị mới | Tìm/sửa mọi string trong code | Thêm 1 dòng trong enum |

### 3. Enum bên trong là số nguyên

```csharp
public enum DeveloperLevel
{
    Junior,   // = 0
    Mid,      // = 1
    Senior,   // = 2
    Lead      // = 3
}

// Giá trị mặc định của enum là 0 (phần tử đầu tiên)
DeveloperLevel level;  // = DeveloperLevel.Junior (không phải null)
```

### 4. Enum ↔ String chuyển đổi

```csharp
Position pos = Position.TeamLeader;

// Enum → String
string text = pos.ToString();  // "TeamLeader"

// String → Enum
Position parsed = Enum.Parse<Position>("Manager");

// String → Enum (an toàn, không crash nếu sai)
bool ok = Enum.TryParse<Position>("Invalid", out var result);  // ok = false
```

### 5. Không cần .ToString() trong string interpolation

```csharp
// Thừa — interpolation tự gọi ToString()
Console.WriteLine($"Position: {dev.TeamRole.ToString()}");

// Gọn hơn — kết quả giống hệt
Console.WriteLine($"Position: {dev.TeamRole}");
```

### 6. Enum không cần validation null/empty

Enum là value type (kiểu số), không bao giờ null (trừ khi dùng `Position?`). Không cần `IsNullOrEmpty` — compiler đã đảm bảo chỉ gán được giá trị hợp lệ.

```csharp
// String: phải validate
if (string.IsNullOrEmpty(position))
    throw new ArgumentNullException(...);

// Enum: không cần — compiler tự kiểm tra
TeamRole = position;  // Chỉ nhận Position.Member, Position.TeamLeader, Position.Manager
```

### 7. Mỗi enum nên nằm trong 1 file riêng

```
Position.cs         → chứa enum Position
DeveloperLevel.cs   → chứa enum DeveloperLevel
Developer.cs        → chỉ chứa class Developer
```

Convention C#: 1 type (class, enum, interface) = 1 file. Tên file = tên type.

### 8. Đặt tên enum — cụ thể, tránh mơ hồ

```csharp
// ❌ Mơ hồ — level của cái gì?
public enum Level { Junior, Mid, Senior }

// ✅ Rõ ràng
public enum DeveloperLevel { Junior, Mid, Senior }
```

Trong codebase lớn có thể có `LogLevel`, `AccessLevel`, `PriorityLevel` — tên cụ thể tránh nhầm lẫn.

### 9. So sánh enum dùng == trực tiếp

```csharp
// Enum: đơn giản, chính xác
if (dev.TeamRole == Position.Member)

// String: phải lo hoa/thường
if (dev.Position == "Member")              // OK
if (dev.Position == "member")              // Không khớp!
if (dev.Position.Equals("member", StringComparison.OrdinalIgnoreCase))  // Phải viết dài
```

## Ví dụ tổng hợp

```csharp
// Position.cs
public enum Position
{
    Member,
    TeamLeader,
    Manager
}

// DeveloperLevel.cs
public enum DeveloperLevel
{
    Junior,
    Mid,
    Senior,
    Lead
}

// Developer.cs
public class Developer
{
    public string Name { get; private set; }
    public int Age { get; set; }
    public Position TeamRole { get; set; }
    public DeveloperLevel Level { get; set; }
    public double YearOfExperience { get; set; }
    public bool IsFullTime { get; set; }

    public string DisplaySummary => $"{Name} - {TeamRole} ({YearOfExperience} Years)";

    public Developer(string name, int age, Position position)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name), "Name cannot be empty.");
        if (age < 18 || age > 65)
            throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 18 and 65.");

        Name = name;
        Age = age;
        TeamRole = position;
    }

    public string GetFullTimeStatus() => IsFullTime ? "Yes" : "No";
}

// Program.cs — tạo object dùng enum
var dev = new Developer("Khuong.Duong", 43, Position.TeamLeader)
{
    YearOfExperience = 20,
    IsFullTime = true,
    Level = DeveloperLevel.Lead
};

// Lọc theo position — so sánh enum bằng ==
static void FilterByPosition(List<Developer> team, Position position)
{
    foreach (var dev in team)
    {
        if (dev.TeamRole == position)
            Console.WriteLine($"- {dev.Name} ({dev.Level}, {dev.YearOfExperience} years)");
    }
}
```

## Câu hỏi kiểm tra

**Câu 1: Thêm position mới "TechLead" — sửa bao nhiêu chỗ với enum? So sánh với string.**

<details>
<summary>Đáp án</summary>

Enum: thêm 1 dòng `TechLead` trong enum `Position`. Nếu có `switch` statement nào xử lý Position mà quên case `TechLead`, compiler có thể warning. String: phải tìm tất cả chỗ hardcode rồi thêm logic — dễ bỏ sót, compiler không giúp gì.
</details>

**Câu 2: Tại sao enum không cần validation `IsNullOrEmpty`?**

<details>
<summary>Đáp án</summary>

Enum là value type (bên trong là `int`), giá trị mặc định là `0` (phần tử đầu tiên), không bao giờ null. Compiler đảm bảo chỉ gán được giá trị đã khai báo trong enum — không thể gán string rỗng hay null. Tuy nhiên `Position?` (nullable enum) thì có thể null, nhưng phải khai báo tường minh.
</details>

**Câu 3: `Position.Member == Position.Member` luôn đúng. `"Member" == "member"` thì sao?**

<details>
<summary>Đáp án</summary>

`"Member" == "member"` trả về `false` — C# string comparison phân biệt hoa thường. Phải dùng `string.Equals("member", StringComparison.OrdinalIgnoreCase)` để không phân biệt. Enum không có vấn đề này vì so sánh bằng giá trị số, không phải text. Đây là type safety — compiler đảm bảo chỉ có giá trị hợp lệ.
</details>

**Câu 4: Đoạn code sau in ra gì?**
```csharp
public enum Color { Red, Green, Blue }
Color c = Color.Green;
Console.WriteLine(c);
Console.WriteLine((int)c);
```

<details>
<summary>Đáp án</summary>

```
Green     ← ToString() tự động → in tên
1         ← Green = 1 (Red=0, Green=1, Blue=2)
```

Enum tự động gán số từ 0. Có thể ép kiểu `(int)` để lấy giá trị số bên trong.
</details>

**Câu 5: Đoạn code sau có vấn đề gì?**
```csharp
public enum Status { Active, Inactive }
public enum Priority { Low, Medium, High }

Status s = Priority.High;
```

<details>
<summary>Đáp án</summary>

Lỗi compile. Không thể gán `Priority.High` vào biến kiểu `Status` — dù cả hai đều là enum, chúng là 2 kiểu khác nhau. Compiler ngăn việc nhầm lẫn giữa các enum. Đây là lợi ích của type safety: nếu dùng `int` hoặc `string` thay enum, compiler không bắt được lỗi logic này.
</details>

---

[← Ngày 05](./day-05-methods.md) | [Về README](../README.md) | [Ngày 07 →](./day-07-linq-basic.md)

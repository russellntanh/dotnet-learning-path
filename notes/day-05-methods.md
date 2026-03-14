# Ngày 05 — Method

## Key Points

### 1. Tại sao cần tách method

`Main()` làm nhiều việc → dài, khó đọc, khó sửa. Tách mỗi việc thành 1 method → `Main()` đọc như mục lục.

```csharp
// ❌ Main() dài, làm mọi thứ
static void Main(string[] args)
{
    // 10 dòng tạo data
    // 7 dòng hiển thị
    // 2 dòng tổng
    // 12 dòng tìm kiếm
    // → 31 dòng, đọc phải cuộn lên cuộn xuống
}

// ✅ Main() ngắn, gọi methods
static void Main(string[] args)
{
    var team = CreateTeam();
    DisplayDeveloperInfo(team);

    Console.Write("Enter name to search: ");
    string keyword = Console.ReadLine();
    var result = FindDeveloperByName(team, keyword);
    DisplaySearchedDeveloperInfo(result, keyword);
}
```

### 2. Cấu trúc method

```csharp
static ReturnType MethodName(ParameterType paramName)
{
    // logic
    return result;  // nếu có return type
}
```

| Thành phần | Ý nghĩa | Ví dụ |
|---|---|---|
| `static` | Gọi được từ `Main()` mà không cần object | Giai đoạn B sẽ học khi nào bỏ static |
| Return type | Kiểu dữ liệu trả về | `void`, `Developer?`, `List<Developer>` |
| Parameters | Dữ liệu đầu vào | `(List<Developer> team, string keyword)` |

### 3. `void` vs có return — cách chọn

| Loại | Khi nào dùng | Ví dụ |
|---|---|---|
| `void` | Method **thực hiện hành động** (in, lưu, gửi) | `DisplayDeveloperInfo()` |
| Có return | Method **tìm kiếm / tính toán** và caller cần kết quả | `FindDeveloperByName()` |

**Quy tắc:** Hỏi "caller có cần nhận kết quả để làm gì tiếp không?" Có → return. Không → void.

### 4. `Developer?` — Nullable reference type

```csharp
Developer  dev1 = null;  // ⚠️ Warning — kiểu non-nullable mà gán null
Developer? dev2 = null;  // ✅ OK — dấu ? cho phép null
```

Dùng `?` khi method có thể không tìm thấy kết quả. Caller bắt buộc phải kiểm tra null trước khi dùng.

### 5. return trong vòng lặp — thoát method ngay

```csharp
static Developer? FindDeveloperByName(List<Developer> team, string keyword)
{
    foreach (var dev in team)
    {
        if (dev.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            return dev;    // Tìm thấy → trả về + thoát method luôn
    }
    return null;           // Hết vòng lặp, không thấy
}
```

Không cần biến `found`, không cần `break` — `return` thoát cả method, gọn hơn nhiều.

### 6. Đặt tên method — quy tắc

```csharp
// ✅ Tốt: động từ + danh từ, phản ánh đúng hành động + output
CreateTeam()                   // Tạo → trả về team
DisplayDeveloperInfo()         // Hiển thị thông tin
FindDeveloperByName()          // Tìm → trả về developer

// ❌ Tệ: mơ hồ, không biết làm gì
DoStuff()
Process()
HandleData()

// ⚠️ Chú ý số ít/số nhiều phản ánh output
CreateDeveloper()   // → nghe như trả về 1 Developer
CreateTeam()        // → rõ ràng trả về danh sách
```

### 7. Lesson learned: Luôn xử lý null

Khi method trả về nullable type, caller **phải** kiểm tra null trước khi dùng:

```csharp
// ❌ Quên kiểm tra null → crash
var result = FindDeveloperByName(team, keyword);
Console.WriteLine(result.Name);  // NullReferenceException nếu không tìm thấy

// ✅ Kiểm tra null trước
var result = FindDeveloperByName(team, keyword);
if (result != null)
    Console.WriteLine(result.Name);
else
    Console.WriteLine("Not found.");
```

### 8. Xóa biến không dùng

Khai báo biến mà không sử dụng (ví dụ `int totalMembers = 0;`) là code thừa. Visual Studio hiện warning cho biến không dùng — nên xóa ngay. Code thừa gây nhầm lẫn cho người đọc: "biến này dùng ở đâu?"

## Ví dụ tổng hợp

```csharp
internal class Program
{
    static void Main(string[] args)
    {
        var team = CreateTeam();
        DisplayDeveloperInfo(team);

        Console.Write("Enter name to search: ");
        string keyword = Console.ReadLine();
        var result = FindDeveloperByName(team, keyword);
        DisplaySearchedDeveloperInfo(result, keyword);
    }

    static List<Developer> CreateTeam()
    {
        return new List<Developer>
        {
            new Developer("Khuong.Duong", 43, "Team Leader") { YearOfExperience = 20, IsFullTime = true },
            new Developer("Jason.Duong", 27, "Member") { YearOfExperience = 3.0, IsFullTime = true },
        };
    }

    static void DisplayDeveloperInfo(List<Developer> team)
    {
        for (int i = 0; i < team.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {team[i].Name}");
            Console.WriteLine($"   Position: {team[i].Position}");
        }
        Console.WriteLine($"Total Members: {team.Count}");
    }

    static Developer? FindDeveloperByName(List<Developer> team, string keyword)
    {
        foreach (var dev in team)
        {
            if (dev.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                return dev;
        }
        return null;
    }

    static void DisplaySearchedDeveloperInfo(Developer? dev, string keyword)
    {
        if (dev != null)
            Console.WriteLine($"Found: {dev.DisplaySummary}");
        else
            Console.WriteLine($"Not found: {keyword}");
    }
}
```

## Câu hỏi kiểm tra

**Câu 1: Tại sao `FindDeveloperByName` trả về `Developer?` chứ không phải `Developer`?**

<details>
<summary>Đáp án</summary>

Vì có khả năng không tìm thấy developer nào khớp keyword. Khi đó method cần trả về `null` để báo "không có kết quả". Nếu dùng `Developer` (non-nullable), compiler sẽ warning khi `return null`, và caller có thể quên kiểm tra null → crash. Dấu `?` là cách nói rõ: "kết quả có thể không tồn tại, caller phải kiểm tra".
</details>

**Câu 2: Tại sao `DisplayDeveloperInfo` là `void` còn `FindDeveloperByName` có return?**

<details>
<summary>Đáp án</summary>

`DisplayDeveloperInfo` thực hiện hành động (in ra console) — caller không cần nhận kết quả gì để dùng tiếp. `FindDeveloperByName` tìm kiếm — caller cần nhận developer tìm được để hiển thị hoặc xử lý tiếp. Quy tắc: "Caller có cần kết quả để làm gì tiếp không?" Có → return type. Không → void.
</details>

**Câu 3: Nếu thêm tính năng "sắp xếp team theo tên", anh sửa ở đâu trong code ngày 5?**

<details>
<summary>Đáp án</summary>

Tạo 1 method mới, ví dụ `SortTeamByName(List<Developer> team)`, rồi thêm 1 dòng gọi trong `Main()` sau `CreateTeam()`:

```csharp
var team = CreateTeam();
SortTeamByName(team);        // ← Thêm 1 dòng
DisplayDeveloperInfo(team);
```

Không sửa `CreateTeam()`, không sửa `DisplayDeveloperInfo()`, không sửa `FindDeveloperByName()`. Mỗi method độc lập — thêm tính năng = thêm method mới + 1 dòng gọi trong Main. Đây là nền móng cho Single Responsibility Principle.
</details>

**Câu 4: Đoạn code sau có vấn đề gì?**
```csharp
static int GetTeamSize(List<Developer> team)
{
    Console.WriteLine($"Team size: {team.Count}");
    return team.Count;
}
```

<details>
<summary>Đáp án</summary>

Method vừa **hiển thị** (Console.WriteLine) vừa **trả về giá trị** (return) — làm 2 việc. Caller gọi `GetTeamSize()` để lấy số, nhưng không biết nó sẽ in ra console. Nên tách: `GetTeamSize()` chỉ return, `DisplayTeamSize()` chỉ in. Một method chỉ nên làm 1 việc.
</details>

**Câu 5: Đoạn code sau sẽ in ra gì?**
```csharp
static int Calculate(int x)
{
    if (x > 10) return x * 2;
    if (x > 5)  return x + 10;
    return x;
}

Console.WriteLine(Calculate(15));
Console.WriteLine(Calculate(8));
Console.WriteLine(Calculate(3));
```

<details>
<summary>Đáp án</summary>

```
30    ← 15 > 10 → return 15 * 2 = 30 (không chạy tiếp)
18    ← 8 không > 10, 8 > 5 → return 8 + 10 = 18
3     ← 3 không > 10, không > 5 → return 3
```

`return` thoát method ngay lập tức — các dòng phía dưới không chạy. Đây là cùng nguyên lý với guard clause và `return` trong vòng lặp tìm kiếm.
</details>

---

[← Ngày 04](./day-04-list-loop.md) | [Về README](../README.md) | [Ngày 06 →](./day-06-enum.md)

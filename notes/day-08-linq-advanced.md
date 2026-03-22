# Ngày 08 — LINQ nâng cao

## Key Points

### 1. GroupBy — nhóm dữ liệu giống SQL GROUP BY

```csharp
var groups = team.GroupBy(dev => dev.Role);

foreach (var group in groups)
{
    // group.Key = giá trị nhóm (VD: TeamRole.Member)
    // group = collection chứa các developer thuộc nhóm đó
    Console.WriteLine($"{group.Key}: {group.Count()} developers");
    foreach (var dev in group)
        Console.WriteLine($"  - {dev.Name}");
}
```

GroupBy trả về `IEnumerable<IGrouping<TKey, TElement>>` — mỗi group có `Key` và là collection các phần tử.

### 2. GroupBy linh hoạt hơn đếm thủ công

```csharp
// ❌ Đếm thủ công — thêm position mới = thêm 1 dòng
var leaderCount = team.Count(dev => dev.Role == TeamRole.Leader);
var memberCount = team.Count(dev => dev.Role == TeamRole.Member);
var managerCount = team.Count(dev => dev.Role == TeamRole.Manager);
// Thêm TechLead → phải thêm 1 dòng nữa

// ✅ GroupBy — thêm position mới không cần sửa code
var groups = team.GroupBy(dev => dev.Role);
foreach (var group in groups)
    Console.WriteLine($"{group.Key}: {group.Count()}");
// TechLead tự xuất hiện thành nhóm mới
```

### 3. GroupBy + thống kê trong nhóm

```csharp
foreach (var group in team.GroupBy(dev => dev.Level))
{
    Console.WriteLine($"{group.Key} ({group.Count()})");
    Console.WriteLine($"  Avg: {group.Average(d => d.YearOfExperience):F1} years");

    // Sắp xếp trong nhóm
    foreach (var dev in group.OrderByDescending(d => d.YearOfExperience))
        Console.WriteLine($"  - {dev.Name} ({dev.YearOfExperience} years)");
}
```

### 4. Anonymous Type — object tạm không cần class

```csharp
var stats = team.GroupBy(dev => dev.Level)
                .Select(group => new
                {
                    Level = group.Key,
                    Count = group.Count(),
                    AvgExp = group.Average(d => d.YearOfExperience)
                });
```

| Đặc điểm | Giải thích |
|---|---|
| Read-only | Không sửa được sau khi tạo |
| Chỉ dùng local | Không return ra ngoài method |
| Compiler tạo class ẩn | Anh không cần khai báo class |
| Khi nào dùng | Kết quả tạm trong LINQ query |

### 5. Sum, Min, Max, Average

```csharp
double totalExp = team.Sum(dev => dev.YearOfExperience);     // Tổng
double avgExp = team.Average(dev => dev.YearOfExperience);   // Trung bình
double minExp = team.Min(dev => dev.YearOfExperience);       // Nhỏ nhất
double maxExp = team.Max(dev => dev.YearOfExperience);       // Lớn nhất
```

### 6. Distinct — loại bỏ trùng lặp

```csharp
var uniqueRoles = team.Select(dev => dev.Role).Distinct();
// → [Leader, Member, Manager] — không trùng

int uniqueCount = team.Select(dev => dev.Role).Distinct().Count();
// → 3
```

### 7. Take / Skip — lấy N phần tử

```csharp
// Top 3 kinh nghiệm nhất
var top3 = team.OrderByDescending(dev => dev.YearOfExperience).Take(3);

// Bỏ qua 5 người đầu, lấy phần còn lại
var rest = team.Skip(5);
```

### 8. string.Join — nối danh sách thành chuỗi

```csharp
// ❌ Loop + dấu phẩy thừa
foreach (var role in roles) Console.Write($"{role}, ");
// Output: "Leader, Member, Manager, "  ← phẩy thừa

// ✅ string.Join — sạch
Console.WriteLine(string.Join(", ", roles));
// Output: "Leader, Member, Manager"
```

### 9. Lesson learned: Bug copy-paste

```csharp
var roles = team.Select(dev => dev.Role).Distinct();
Console.WriteLine($"Role: {string.Join(", ", roles)}");

var techLevels = team.Select(dev => dev.Level).Distinct();
Console.WriteLine($"Level: {string.Join(", ", roles)}");   // ← BUG: copy dòng trên, quên đổi roles → techLevels
```

Khi copy-paste code rồi sửa, **kiểm tra tất cả biến** trong dòng mới. Compiler không báo lỗi này vì cả 2 đều là kiểu hợp lệ. Chỉ phát hiện khi đọc output.

### 10. Sắp xếp methods theo flow Main

```csharp
// Đọc code từ trên xuống theo đúng thứ tự chương trình chạy
Main()
CreateTeam()
DisplayDeveloperInfo()
DisplayTeamSummary()
DisplayGroupByProject()
DisplayGroupByLevel()
DisplayGroupByRole()
DisplayTopExperienced()
```

## Ví dụ tổng hợp

```csharp
var team = CreateTeam();

// GroupBy Role
foreach (var group in team.GroupBy(dev => dev.Role))
{
    Console.WriteLine($"{group.Key} ({group.Count()}):");
    foreach (var dev in group)
        Console.WriteLine($"  - {dev.Name}");
}

// GroupBy Level + thống kê + sắp xếp trong nhóm
foreach (var group in team.GroupBy(dev => dev.Level))
{
    Console.WriteLine($"{group.Key}: Avg {group.Average(d => d.YearOfExperience):F1} years");
    foreach (var dev in group.OrderByDescending(d => d.YearOfExperience))
        Console.WriteLine($"  - {dev.Name} ({dev.YearOfExperience} years)");
}

// Summary
var roles = team.Select(d => d.Role).Distinct();
Console.WriteLine($"Roles: {string.Join(", ", roles)}");
Console.WriteLine($"Exp — Total: {team.Sum(d => d.YearOfExperience)} | Avg: {team.Average(d => d.YearOfExperience):F1}");

// Top 3
var top3 = team.OrderByDescending(d => d.YearOfExperience).Take(3);
foreach (var dev in top3)
    Console.WriteLine($"{dev.Name}: {dev.YearOfExperience} years");
```

## Câu hỏi kiểm tra

**Câu 1: `GroupBy` trả về kiểu gì? Mỗi group có gì bên trong?**

<details>
<summary>Đáp án</summary>

Trả về `IEnumerable<IGrouping<TKey, TElement>>`. Mỗi `IGrouping` có: `Key` (giá trị nhóm, ví dụ `TeamRole.Member`) và bản thân nó là một collection chứa các phần tử thuộc nhóm đó. Có thể dùng `group.Count()`, `group.Average()`, `foreach (var dev in group)` trên mỗi group.
</details>

**Câu 2: Đếm thủ công từng position vs GroupBy — cách nào linh hoạt hơn khi thêm position mới?**

<details>
<summary>Đáp án</summary>

`GroupBy` linh hoạt hơn. Thêm position mới (VD: TechLead): cách thủ công phải thêm 1 dòng `Count()`. Cách `GroupBy` không cần sửa code — nhóm mới tự xuất hiện trong kết quả. Đặc biệt hữu ích khi số lượng giá trị enum thay đổi thường xuyên.
</details>

**Câu 3: `new { Level = group.Key, Count = group.Count() }` — đây gọi là gì? Tại sao dùng được mà không cần tạo class?**

<details>
<summary>Đáp án</summary>

Đây là **anonymous type**. Compiler tự tạo class ẩn phía sau với các property read-only. Dùng được vì kết quả chỉ dùng tạm trong scope hiện tại — không cần return ra ngoài method hay truyền cho method khác. Khi cần dùng lại ở nhiều nơi thì nên tạo class/record thật.
</details>

**Câu 4: Đoạn code sau có vấn đề gì?**
```csharp
var groups = team.GroupBy(dev => dev.Role);
Console.WriteLine($"Total groups: {groups.Count()}");

foreach (var group in groups)
{
    Console.WriteLine($"{group.Key}: {group.Count()}");
}
```

<details>
<summary>Đáp án</summary>

Duyệt `groups` 2 lần — `Count()` duyệt 1 lần, `foreach` duyệt lần nữa. Vì `GroupBy` trả về `IEnumerable` (lazy), mỗi lần duyệt đều chạy lại GroupBy từ đầu. Nên `.ToList()` trước: `var groups = team.GroupBy(...).ToList();` rồi dùng `.Count` (property) và `foreach` trên list đã lưu.
</details>

**Câu 5: Viết LINQ: Nhóm developer theo Project, với mỗi project tính tổng kinh nghiệm và tìm người có kinh nghiệm cao nhất.**

<details>
<summary>Đáp án</summary>

```csharp
var projectStats = team.GroupBy(dev => dev.InvolvedProject)
                       .Select(group => new
                       {
                           Project = group.Key,
                           TotalExp = group.Sum(d => d.YearOfExperience),
                           TopDev = group.OrderByDescending(d => d.YearOfExperience).First()
                       });

foreach (var stat in projectStats)
{
    Console.WriteLine($"{stat.Project}: Total {stat.TotalExp} years");
    Console.WriteLine($"  Top: {stat.TopDev.Name} ({stat.TopDev.YearOfExperience} years)");
}
```

Kết hợp: GroupBy → Select với anonymous type → bên trong dùng Sum + OrderByDescending + First.
</details>

---

[← Ngày 07](./day-07-linq-basic.md) | [Về README](../README.md) | [Ngày 09 →](./day-09-dictionary.md)

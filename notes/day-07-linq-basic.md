# Ngày 07 — LINQ cơ bản

## Key Points

### 1. LINQ thay thế vòng lặp thủ công

```csharp
// ❌ Không có LINQ — 5 dòng
var members = new List<Developer>();
foreach (var dev in team)
{
    if (dev.TeamRole == Position.Member)
        members.Add(dev);
}

// ✅ Có LINQ — 1 dòng
var members = team.Where(dev => dev.TeamRole == Position.Member).ToList();
```

### 2. Lambda Expression — cú pháp `=>`

```csharp
dev => dev.Age > 30
//  ↑         ↑
//  tham số   điều kiện (trả về true/false)
```

Đọc là: "với mỗi dev, kiểm tra Age > 30."

### 3. Các LINQ method cơ bản

| Method | Chức năng | Ví dụ |
|---|---|---|
| `Where` | Lọc theo điều kiện | `team.Where(d => d.Age > 30)` |
| `OrderBy` | Sắp xếp tăng dần | `team.OrderBy(d => d.Name)` |
| `OrderByDescending` | Sắp xếp giảm dần | `team.OrderByDescending(d => d.YearOfExperience)` |
| `Select` | Chọn/biến đổi dữ liệu | `team.Select(d => d.Name)` |
| `First` | Phần tử đầu tiên (crash nếu rỗng) | `team.First(d => d.Age > 30)` |
| `FirstOrDefault` | Phần tử đầu tiên hoặc null | `team.FirstOrDefault(d => d.Age > 30)` |
| `Any` | Có phần tử nào khớp không | `team.Any(d => d.Age > 30)` |
| `Count` | Đếm có điều kiện | `team.Count(d => d.TeamRole == Position.Member)` |
| `Average` | Trung bình | `team.Average(d => d.YearOfExperience)` |

### 4. LINQ chaining — đọc như câu tiếng Anh

```csharp
var names = team
    .Where(dev => dev.YearOfExperience > 10)    // Lọc > 10 năm
    .OrderBy(dev => dev.Name)                    // Sắp theo tên
    .Select(dev => dev.Name);                    // Lấy tên

// Đọc: "Từ team, lọc > 10 năm, sắp theo tên, lấy tên"
```

Thứ tự phổ biến: **Where** (lọc) → **OrderBy** (sắp xếp) → **Select** (chọn dữ liệu).

### 5. First vs FirstOrDefault

| | `First` | `FirstOrDefault` |
|---|---|---|
| Tìm thấy | Trả về phần tử | Trả về phần tử |
| Không tìm thấy | Throw exception ❌ | Trả về null ✅ |
| Khi nào dùng | Chắc chắn 100% có kết quả | Có thể không có kết quả |

```csharp
// An toàn — trả null nếu không thấy
var result = team.FirstOrDefault(dev => dev.Name.Contains("Jason"));

// Nguy hiểm — crash nếu không thấy
var result = team.First(dev => dev.Name.Contains("Nobody"));
```

### 6. IEnumerable vs List — khi nào cần .ToList()

`Where`, `OrderBy`, `Select` trả về `IEnumerable<T>` — lazy, chưa thực thi ngay.

| Trường hợp | Cần `.ToList()` | Lý do |
|---|---|---|
| Dùng kết quả nhiều lần | ✅ | `IEnumerable` duyệt lại mỗi lần |
| Cần `.Count` property | ✅ | `IEnumerable` chỉ có `.Count()` method (chậm hơn) |
| Cần truy cập `[i]` | ✅ | `IEnumerable` không hỗ trợ index |
| Chỉ dùng 1 lần trong `foreach` | Không cần | Duyệt trực tiếp hiệu quả hơn |

```csharp
// Dùng nhiều lần → ToList() trước
var filtered = team.Where(dev => dev.TeamRole == Position.Member).ToList();
Console.WriteLine($"Count: {filtered.Count}");   // .Count property — nhanh
foreach (var dev in filtered) { ... }              // Duyệt trên list có sẵn

// Chỉ dùng 1 lần → không cần ToList()
foreach (var dev in team.Where(dev => dev.Age > 30))
{
    Console.WriteLine(dev.Name);
}
```

### 7. Lesson learned: Select chọn dữ liệu cần

```csharp
// Không có Select — trả về Developer object
var result = team.Where(dev => dev.YearOfExperience > 10);
// → IEnumerable<Developer>

// Có Select — trả về chỉ tên
var names = team.Where(dev => dev.YearOfExperience > 10)
                .Select(dev => dev.Name);
// → IEnumerable<string>

// Select tạo format tùy ý
var summaries = team.Select(dev => $"{dev.Name} ({dev.TeamRole})");
// → IEnumerable<string>: ["Khuong.Duong (TeamLeader)", ...]
```

### 8. Format số trong string interpolation

```csharp
double avg = 9.8333;
Console.WriteLine($"{avg}");      // "9.8333"
Console.WriteLine($"{avg:F1}");   // "9.8"    — 1 chữ số thập phân
Console.WriteLine($"{avg:F2}");   // "9.83"   — 2 chữ số thập phân
```

## Ví dụ tổng hợp

```csharp
var team = CreateTeam();

// Lọc Member
var members = team.Where(dev => dev.TeamRole == Position.Member).ToList();
Console.WriteLine($"Members: {members.Count}");

// Tìm developer
var found = team.FirstOrDefault(dev => dev.Name.Contains("Jason", StringComparison.OrdinalIgnoreCase));
if (found != null)
    Console.WriteLine($"Found: {found.DisplaySummary}");

// Sắp xếp theo tên
var sorted = team.OrderBy(dev => dev.Name);
foreach (var dev in sorted)
    Console.WriteLine($"{dev.Name} - {dev.TeamRole}");

// Thống kê
var avgExp = team.Average(dev => dev.YearOfExperience);
var mostExp = team.OrderByDescending(dev => dev.YearOfExperience).FirstOrDefault();
Console.WriteLine($"Average: {avgExp:F1} years");
Console.WriteLine($"Most Experienced: {mostExp?.Name}");

// Lấy tên developer > 10 năm kinh nghiệm, sắp theo tên
var seniorNames = team
    .Where(dev => dev.YearOfExperience > 10)
    .OrderBy(dev => dev.Name)
    .Select(dev => dev.Name);
```

## Câu hỏi kiểm tra

**Câu 1: `First()` vs `FirstOrDefault()` — khi nào dùng cái nào? Cái nào an toàn hơn?**

<details>
<summary>Đáp án</summary>

`FirstOrDefault` an toàn hơn — trả về `null` khi không tìm thấy. `First` throw `InvalidOperationException` khi không tìm thấy. Dùng `First` chỉ khi chắc chắn 100% có ít nhất 1 phần tử khớp (ví dụ sau khi đã kiểm tra `Any()`). Trong hầu hết trường hợp, dùng `FirstOrDefault`.
</details>

**Câu 2: Viết 1 dòng LINQ: lấy tên tất cả developer có kinh nghiệm > 10 năm, sắp xếp theo tên.**

<details>
<summary>Đáp án</summary>

```csharp
var names = team.Where(dev => dev.YearOfExperience > 10)
                .OrderBy(dev => dev.Name)
                .Select(dev => dev.Name);
```

Thứ tự: Where (lọc) → OrderBy (sắp xếp) → Select (chọn tên). Nếu chỉ viết `.Where().OrderBy()` mà không có `.Select(dev => dev.Name)` thì trả về `Developer` object chứ không phải tên.
</details>

**Câu 3: `.Where()` trả về `IEnumerable<T>` — tại sao cần `.ToList()` trong một số trường hợp?**

<details>
<summary>Đáp án</summary>

`IEnumerable<T>` là lazy — mỗi lần duyệt (foreach, Count()...) đều tính lại từ đầu. Cần `.ToList()` khi: (1) dùng kết quả nhiều lần — tránh tính lại, (2) cần `.Count` property thay vì `.Count()` method, (3) cần truy cập theo index `[i]`. Không cần `.ToList()` khi chỉ duyệt 1 lần trong `foreach`.
</details>

**Câu 4: Đoạn code sau có vấn đề gì?**
```csharp
var result = team.Where(dev => dev.TeamRole == Position.Member);
Console.WriteLine($"Count: {result.Count()}");
foreach (var dev in result) { Console.WriteLine(dev.Name); }
Console.WriteLine($"First: {result.First().Name}");
```

<details>
<summary>Đáp án</summary>

Duyệt `result` 3 lần (Count, foreach, First) — mỗi lần đều chạy lại `Where` từ đầu vì `result` là `IEnumerable`. Nên `.ToList()` trước: `var result = team.Where(...).ToList();` rồi dùng `.Count` (property), `foreach`, `.First()` trên list đã lưu. Ngoài ra `First()` có thể crash nếu không có Member — nên dùng `FirstOrDefault()`.
</details>

**Câu 5: Đoạn code sau in ra gì?**
```csharp
var numbers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6 };
var result = numbers.Where(n => n > 3)
                    .OrderBy(n => n)
                    .Select(n => n * 10);

foreach (var n in result)
    Console.Write($"{n} ");
```

<details>
<summary>Đáp án</summary>

```
40 50 60 90
```

Quá trình: Where lọc > 3 → {4, 5, 9, 6} → OrderBy sắp tăng → {4, 5, 6, 9} → Select nhân 10 → {40, 50, 60, 90}. LINQ chain thực thi từ trái sang phải, mỗi bước xử lý kết quả của bước trước.
</details>

---

[← Ngày 06](./day-06-enum.md) | [Về README](../README.md) | [Ngày 08 →](./day-08-linq-advanced.md)

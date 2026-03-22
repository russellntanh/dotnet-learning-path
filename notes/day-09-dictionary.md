# Ngày 09 — Dictionary

## Key Points

### 1. Dictionary — cấu trúc key-value, tra cứu nhanh

```csharp
var skillMap = new Dictionary<string, List<Developer>>
{
    { "WPF", new List<Developer> { dev1, dev4 } },
    { "C#", new List<Developer> { dev1, dev2, dev3 } }
};

// Truy cập qua key — O(1), rất nhanh
var wpfDevs = skillMap["WPF"];
```

### 2. List vs Dictionary

| Tiêu chí | `List<T>` | `Dictionary<TKey, TValue>` |
|---|---|---|
| Truy cập | Theo index `[0]` | Theo key `["WPF"]` |
| Tìm kiếm | Duyệt tuần tự O(n) | Trực tiếp qua key O(1) |
| Key trùng | Không áp dụng | Không được trùng |
| Khi nào dùng | Danh sách, duyệt tuần tự | Tra cứu nhanh theo key |

### 3. TryGetValue — truy cập an toàn

```csharp
// ❌ Crash nếu key không tồn tại
var devs = skillMap["Flutter"];  // KeyNotFoundException

// ✅ An toàn — kiểm tra trước
if (skillMap.TryGetValue("Flutter", out var devs))
    Console.WriteLine($"Found: {devs.Count}");
else
    Console.WriteLine("Not found.");
```

### 4. StringComparer — Dictionary không phân biệt hoa thường

```csharp
// Mặc định: phân biệt hoa thường
var map = new Dictionary<string, int>();
map["WPF"] = 1;
map.TryGetValue("wpf", out var val);  // false — không tìm thấy

// Thêm StringComparer: không phân biệt
var map = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
map["WPF"] = 1;
map.TryGetValue("wpf", out var val);  // true — tìm thấy!
```

Xử lý 1 lần khi tạo Dictionary, tất cả thao tác sau tự động đúng.

### 5. Reverse Mapping — pattern tra cứu ngược

Chuyển từ `Developer → List<Skills>` thành `Skill → List<Developers>`:

```csharp
static Dictionary<string, List<Developer>> BuildSkillDictionary(List<Developer> team)
{
    var skillMap = new Dictionary<string, List<Developer>>(StringComparer.OrdinalIgnoreCase);

    foreach (var dev in team)
    {
        foreach (var skill in dev.Skills)
        {
            string trimmed = skill.Trim();
            if (!skillMap.ContainsKey(trimmed))
                skillMap[trimmed] = new List<Developer>();

            skillMap[trimmed].Add(dev);
        }
    }
    return skillMap;
}
```

| Câu hỏi | Không có reverse mapping | Có reverse mapping |
|---|---|---|
| "Ai biết WPF?" | Duyệt 17 developer, kiểm tra từng người | `skillMap["WPF"]` → có ngay |
| Độ phức tạp | O(n × m) | O(1) |

### 6. Duyệt Dictionary

```csharp
// Cách 1: entry.Key, entry.Value
foreach (var entry in skillMap)
    Console.WriteLine($"{entry.Key}: {entry.Value.Count}");

// Cách 2: Deconstruction (gọn hơn)
foreach (var (skill, developers) in skillMap)
    Console.WriteLine($"{skill}: {developers.Count}");
```

### 7. ToDictionary — chuyển List thành Dictionary

```csharp
// Key = Name, Value = Developer
var devByName = team.ToDictionary(dev => dev.Name);

// ⚠️ CRASH nếu có 2 developer cùng tên
// Cách an toàn khi có thể trùng key:
var devByName = team.GroupBy(dev => dev.Name)
                    .ToDictionary(g => g.Key, g => g.ToList());
```

### 8. Dictionary + LINQ

```csharp
// Tìm skill có nhiều developer nhất
var topSkill = skillMap.OrderByDescending(s => s.Value.Count).First();
Console.WriteLine($"Most common: {topSkill.Key} ({topSkill.Value.Count})");

// Lấy tên developer từ skill map
var wpfNames = skillMap["WPF"].Select(d => d.Name);
Console.WriteLine($"WPF: {string.Join(", ", wpfNames)}");
```

### 9. Lesson learned: Bug thiếu else (lặp lại)

```csharp
// ❌ Thiếu else — luôn in "Cannot find" dù đã tìm thấy
if (skillMap.TryGetValue(skill, out var devs))
{
    Console.WriteLine($"Found: {devs.Count}");
}
Console.WriteLine("Cannot find.");  // Luôn chạy!

// ✅ Có else
if (skillMap.TryGetValue(skill, out var devs))
{
    Console.WriteLine($"Found: {devs.Count}");
}
else
{
    Console.WriteLine("Cannot find.");
}
```

Đây là lỗi lặp lại từ ngày 3 và ngày 4. Quy tắc: khi có 2 nhánh loại trừ nhau (tìm thấy / không tìm thấy), **luôn dùng if-else**, không để code chạy tiếp sau if.

### 10. Trim() input từ user

```csharp
Console.Write("Enter skill: ");
string skill = Console.ReadLine().Trim();  // Loại khoảng trắng đầu/cuối
```

Luôn `Trim()` input từ user — người dùng thường vô tình thêm khoảng trắng.

## Ví dụ tổng hợp

```csharp
var team = CreateTeam();

// Build reverse mapping
var skillMap = BuildSkillDictionary(team);

// Hiển thị skill matrix — sắp theo phổ biến nhất
foreach (var skill in skillMap.OrderByDescending(s => s.Value.Count))
{
    var names = skill.Value.Select(d => d.Name);
    Console.WriteLine($"{skill.Key} ({skill.Value.Count}): {string.Join(", ", names)}");
}

// Tìm theo skill
Console.Write("Enter skill: ");
string input = Console.ReadLine().Trim();

if (skillMap.TryGetValue(input, out var developers))
{
    Console.WriteLine($"Found {developers.Count} developers with {input}:");
    foreach (var dev in developers)
        Console.WriteLine($"  - {dev.Name} ({dev.InvolvedProject}, {dev.Level})");
}
else
{
    Console.WriteLine($"No developer found with skill: {input}");
}

// Số skill mỗi developer — sắp giảm dần
foreach (var dev in team.OrderByDescending(d => d.Skills.Count))
    Console.WriteLine($"{dev.Name}: {dev.Skills.Count} skills ({string.Join(", ", dev.Skills)})");
```

## Câu hỏi kiểm tra

**Câu 1: `skillMap["WPF"]` vs `skillMap.TryGetValue("WPF", out var devs)` — khác nhau thế nào?**

<details>
<summary>Đáp án</summary>

`skillMap["WPF"]` crash (`KeyNotFoundException`) nếu key không tồn tại. `TryGetValue` trả về `false` và `devs = null` — không crash. Luôn dùng `TryGetValue` khi không chắc chắn key có tồn tại hay không.
</details>

**Câu 2: Dictionary key phải unique — `team.ToDictionary(dev => dev.Name)` xảy ra gì nếu 2 developer cùng tên?**

<details>
<summary>Đáp án</summary>

Crash — throw `ArgumentException: An item with the same key has already been added`. Cách xử lý: dùng `GroupBy` trước rồi `ToDictionary`: `team.GroupBy(d => d.Name).ToDictionary(g => g.Key, g => g.ToList())` — nhóm developer cùng tên vào 1 list.
</details>

**Câu 3: Reverse mapping từ `Developer → Skills` thành `Skill → Developers` — lợi ích thực tế là gì?**

<details>
<summary>Đáp án</summary>

Tốc độ tra cứu ngược. Câu hỏi "Ai biết WPF?" — không có reverse mapping phải duyệt 17 developer kiểm tra từng người (O(n×m)). Có reverse mapping thì `skillMap["WPF"]` trả về ngay danh sách (O(1)). Giống cách search engine index: thay vì đọc mọi trang web để tìm từ khóa, index sẵn từ khóa → danh sách trang. Pattern này rất phổ biến trong production code.
</details>

**Câu 4: Đoạn code sau có vấn đề gì?**
```csharp
var map = new Dictionary<string, int>();
map["C#"] = 5;
map["c#"] = 3;
Console.WriteLine(map.Count);
Console.WriteLine(map["C#"]);
```

<details>
<summary>Đáp án</summary>

In ra `2` và `5`. Dictionary mặc định **phân biệt hoa thường** — `"C#"` và `"c#"` là 2 key khác nhau. `map.Count` = 2. `map["C#"]` = 5 (không bị ghi đè bởi `"c#"` = 3). Nếu muốn không phân biệt, tạo Dictionary với `StringComparer.OrdinalIgnoreCase` — khi đó `"c#" = 3` sẽ ghi đè `"C#" = 5`, Count = 1.
</details>

**Câu 5: Tại sao nên dùng `StringComparer.OrdinalIgnoreCase` khi tạo Dictionary thay vì xử lý hoa/thường khi tìm?**

<details>
<summary>Đáp án</summary>

Xử lý 1 lần tại nguồn (khi tạo Dictionary) thay vì xử lý ở mọi chỗ gọi `TryGetValue` hay `ContainsKey`. Lợi ích: (1) không thể quên xử lý ở chỗ tìm mới, (2) hiệu năng tốt hơn — hash table tự xử lý thay vì duyệt Keys, (3) code gọn hơn — `TryGetValue("wpf", ...)` hoạt động đúng mà không cần thêm logic.
</details>

---

[← Ngày 08](./day-08-linq-advanced.md) | [Về README](../README.md) | [Ngày 10 →](./day-10-review-week2.md)

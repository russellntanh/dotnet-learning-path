# Ngày 04 — List và vòng lặp

## Key Points

### 1. List\<T\> — danh sách có kiểu

`List<T>` chứa nhiều object cùng kiểu. Thay thế việc khai báo nhiều biến riêng lẻ.

```csharp
// ❌ Biến riêng lẻ — thêm người = thêm biến + thêm block hiển thị
var dev1 = new Developer(...);
var dev2 = new Developer(...);

// ✅ List — thêm người = thêm 1 dòng vào list
var team = new List<Developer>
{
    new Developer("Khuong.Duong", 43, "Team Leader") { YearOfExperience = 20, IsFullTime = true },
    new Developer("Jimmii.Nguyen", 37, "Member") { YearOfExperience = 3.0, IsFullTime = true },
};
```

### 2. Các thao tác cơ bản với List

```csharp
team.Count          // Số phần tử (property, không phải method)
team[0]             // Phần tử đầu tiên (index từ 0)
team[team.Count-1]  // Phần tử cuối cùng
team.Add(newDev)    // Thêm vào cuối
team.Remove(dev)    // Xóa phần tử cụ thể
team.RemoveAt(0)    // Xóa theo index
```

### 3. Vòng lặp `for` — khi cần số thứ tự

```csharp
for (int i = 0; i < team.Count; i++)
{
    Console.WriteLine($"{i + 1}. {team[i].Name}");
    //                  ^^^^^ i bắt đầu từ 0, nên +1 để hiển thị từ 1
}
```

**Lưu ý:** dùng `i < team.Count` (không phải `<=`) vì index từ 0 đến Count-1.

### 4. Vòng lặp `foreach` — khi chỉ cần đọc từng phần tử

```csharp
foreach (var dev in team)
{
    Console.WriteLine($"{dev.Name} - {dev.Position}");
}
```

| | `for` | `foreach` |
|---|---|---|
| Biết index | Có (`i`) | Không |
| Cú pháp | Dài hơn | Gọn hơn |
| Khi nào dùng | Cần số thứ tự | Chỉ cần đọc từng phần tử |

### 5. Flag Pattern — tìm kiếm đúng cách

```csharp
// ❌ SAI: kiểm tra từng phần tử → in "Not found" nhiều lần
foreach (var dev in team)
{
    if (!dev.Name.Contains(searchName))
        Console.WriteLine("Not found");  // In 4 lần nếu chỉ 1 người khớp!
    else
        Console.WriteLine($"Found: {dev.Name}");
}

// ✅ ĐÚNG: dùng flag, duyệt hết rồi mới kết luận
bool found = false;
foreach (var dev in team)
{
    if (dev.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"Found: {dev.DisplaySummary}");
        found = true;
        break;  // Tìm thấy rồi, dừng
    }
}
if (!found)
    Console.WriteLine($"Not found: {searchName}");
```

**Lesson learned:** Khi tìm kiếm trong vòng lặp, KHÔNG kết luận "Not found" bên trong vòng lặp. Phải duyệt hết toàn bộ list rồi mới biết có tìm thấy hay không.

### 6. Contains vs Equals

```csharp
// Equals: khớp chính xác toàn bộ chuỗi
"Jason.Duong".Equals("Jason")        // false
"Jason.Duong".Equals("Jason.Duong")  // true

// Contains: tìm chuỗi con
"Jason.Duong".Contains("Jason")      // true — "Jason" nằm trong "Jason.Duong"
"Jason.Duong".Contains("jason")      // false — phân biệt hoa/thường

// Contains không phân biệt hoa/thường
"Jason.Duong".Contains("jason", StringComparison.OrdinalIgnoreCase)  // true
```

### 7. .Count (property) vs .Count() (LINQ method)

```csharp
team.Count      // Property của List<T> — nhanh, đọc giá trị có sẵn
team.Count()    // LINQ extension method — chậm hơn, duyệt để đếm
```

Với `List<T>` luôn dùng `.Count` (property). `.Count()` thuộc LINQ, sẽ học ở ngày 7.

### 8. Console.ReadLine() — đọc input từ user

```csharp
Console.Write("Enter name: ");     // Write (không xuống dòng) — user gõ cùng dòng
string input = Console.ReadLine();  // Đọc 1 dòng text user nhập
```

## Ví dụ tổng hợp

```csharp
var team = new List<Developer>
{
    new Developer("Khuong.Duong", 43, "Team Leader") { YearOfExperience = 20, IsFullTime = true },
    new Developer("Jason.Duong", 27, "Member") { YearOfExperience = 3.0, IsFullTime = true },
};

// Hiển thị với số thứ tự
for (int i = 0; i < team.Count; i++)
{
    Console.WriteLine($"{i + 1}. {team[i].Name}");
    Console.WriteLine($"   Position: {team[i].Position}");
}
Console.WriteLine($"Total: {team.Count}");

// Tìm kiếm với flag pattern
Console.Write("Search: ");
string keyword = Console.ReadLine();

bool found = false;
foreach (var dev in team)
{
    if (dev.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"Found: {dev.DisplaySummary}");
        found = true;
        break;
    }
}
if (!found)
    Console.WriteLine("Not found.");
```

## Câu hỏi kiểm tra

**Câu 1: Đoạn code sau có lỗi gì?**
```csharp
var list = new List<int> { 10, 20, 30 };
for (int i = 0; i <= list.Count; i++)
{
    Console.WriteLine(list[i]);
}
```

<details>
<summary>Đáp án</summary>

`IndexOutOfRangeException` ở vòng lặp cuối cùng. `list.Count` = 3, nhưng index hợp lệ là 0, 1, 2. Khi `i = 3`, `list[3]` vượt ngoài phạm vi. Sửa: `i < list.Count` (dùng `<` thay `<=`).
</details>

**Câu 2: So sánh — thêm developer thứ 6 vào team: cách ngày 3 (biến riêng lẻ) phải sửa bao nhiêu chỗ? Cách ngày 4 (List + vòng lặp) phải sửa bao nhiêu chỗ?**

<details>
<summary>Đáp án</summary>

Ngày 3: thêm 1 block khai báo biến + 1 block `Console.WriteLine` hiển thị + sửa `totalMembers` = 3 chỗ. Ngày 4: thêm 1 object vào List = 1 chỗ duy nhất. Vòng lặp tự xử lý hiển thị, `team.Count` tự cập nhật. Đây là lợi ích lớn nhất của List + vòng lặp.
</details>

**Câu 3: Tại sao tìm kiếm cần dùng flag pattern (biến `bool found`) thay vì in "Not found" bên trong vòng lặp?**

<details>
<summary>Đáp án</summary>

Vì vòng lặp duyệt từng phần tử — nếu in "Not found" bên trong, mỗi phần tử không khớp đều in 1 lần. List có 5 người, tìm 1 người → in "Not found" 4 lần rồi mới thấy kết quả. Flag pattern: duyệt hết, đánh dấu nếu tìm thấy, kết thúc vòng lặp rồi mới kết luận 1 lần duy nhất.
</details>

**Câu 4: `break` trong vòng lặp làm gì? Nếu bỏ `break` trong đoạn tìm kiếm thì chuyện gì xảy ra?**

<details>
<summary>Đáp án</summary>

`break` thoát khỏi vòng lặp ngay lập tức. Nếu bỏ `break`, vòng lặp tiếp tục duyệt các phần tử còn lại dù đã tìm thấy. Nếu có 2 người tên chứa "Nguyen" thì sẽ in cả 2 — có thể là mong muốn hoặc không. Với yêu cầu "tìm 1 người" thì nên có `break` để dừng sớm, tiết kiệm thời gian (quan trọng khi list có hàng nghìn phần tử).
</details>

**Câu 5: Đoạn code sau in ra gì?**
```csharp
var numbers = new List<int> { 5, 12, 3, 8, 1 };
int max = numbers[0];
for (int i = 1; i < numbers.Count; i++)
{
    if (numbers[i] > max)
        max = numbers[i];
}
Console.WriteLine($"Max: {max}");
```

<details>
<summary>Đáp án</summary>

In ra `Max: 12`. Đoạn code tìm giá trị lớn nhất trong list bằng cách: giả sử phần tử đầu tiên là lớn nhất (`max = 5`), rồi duyệt từ phần tử thứ 2 — nếu phần tử nào lớn hơn `max` thì cập nhật `max`. Quá trình: 5 → so với 12 (cập nhật max=12) → so với 3 (giữ nguyên) → so với 8 (giữ nguyên) → so với 1 (giữ nguyên) → kết quả 12. Đây là pattern "tìm min/max" rất phổ biến.
</details>

---

[← Ngày 03](./day-03-constructor.md) | [Về README](../README.md) | [Ngày 05 →](./day-05-methods.md)

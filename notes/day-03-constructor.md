# Ngày 03 — Constructor và Properties

## Key Points

### 1. Constructor — bắt buộc cung cấp dữ liệu khi tạo object

Constructor là method đặc biệt: cùng tên class, không có return type, chạy tự động khi `new`.

```csharp
public class Developer
{
    public string Name { get; private set; }

    // Constructor
    public Developer(string name)
    {
        Name = name;
    }
}

var dev = new Developer("Khuong.Duong");  // ✅ Bắt buộc có tên
var dev = new Developer();                 // ❌ Lỗi compile
```

**Khi tự viết constructor, C# xóa constructor mặc định (không tham số).**

### 2. Property thay vì Field — chuẩn C#

```csharp
// ❌ Public field — không kiểm soát được
public string Name;

// ✅ Property — kiểm soát đọc/ghi
public string Name { get; set; }
```

**Quy tắc: tất cả public data nên là Property, không phải Field.**

### 3. Các loại Property

```csharp
// Read-write: đọc/ghi tự do
public string Position { get; set; }

// Read-only từ bên ngoài: chỉ gán trong constructor hoặc nội bộ class
public string Name { get; private set; }

// Computed property: tính từ data khác, không lưu trữ
public string DisplaySummary => $"{Name} - {Position}";
```

**Cách chọn:**

| Loại | Khi nào dùng | Ví dụ |
|---|---|---|
| `{ get; set; }` | Data có thể thay đổi sau khi tạo | Position (thăng chức) |
| `{ get; private set; }` | Data gán 1 lần, không đổi từ bên ngoài | Name (tên không đổi) |
| `=> expression` | Giá trị tính toán từ data khác | DisplaySummary |

### 4. Guard Clause — kiểm tra lỗi đầu tiên, gán sau

```csharp
// ❌ If/else lồng nhau — dễ thiếu else, khó đọc
if (!string.IsNullOrEmpty(name))
{
    Name = name;
}
else throw new ArgumentNullException("...");

// ✅ Guard clause — kiểm tra lỗi trước, gán sau
if (string.IsNullOrEmpty(name))
    throw new ArgumentNullException(nameof(name), "Name cannot be empty.");

Name = name;  // Chỉ chạy đến đây nếu hợp lệ
```

**Lợi ích:** đọc từ trên xuống biết ngay điều kiện lỗi, tránh bug thiếu `else`.

### 5. Naming Convention — tham số vs property

```csharp
// Tham số: camelCase
// Property: PascalCase
public Developer(string name, int age)  // camelCase
{
    Name = name;   // PascalCase = camelCase → rõ ràng, không cần this.
    Age = age;
}
```

### 6. Constructor + Object Initializer kết hợp

```csharp
// Constructor cho field bắt buộc, initializer cho field tùy chọn
var dev = new Developer("Khuong.Duong", 43, "Team Leader")
{
    YearOfExperience = 20,   // Tùy chọn
    IsFullTime = true         // Tùy chọn
};
```

### 7. Chọn đúng loại Exception

```csharp
// Giá trị null hoặc rỗng
throw new ArgumentNullException(nameof(name), "Name cannot be empty.");

// Giá trị ngoài phạm vi hợp lệ
throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 18 and 65.");

// Giá trị sai logic chung
throw new ArgumentException("Invalid value.");
```

## Ví dụ tổng hợp

```csharp
public class Developer
{
    public string Name { get; private set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public double YearOfExperience { get; set; }
    public bool IsFullTime { get; set; }

    public string DisplaySummary => $"{Name} - {Position} ({YearOfExperience} Years)";

    public Developer(string name, int age, string position)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name), "Name cannot be empty.");
        if (age < 18 || age > 65)
            throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 18 and 65.");
        if (string.IsNullOrEmpty(position))
            throw new ArgumentNullException(nameof(position), "Position cannot be empty.");

        Name = name;
        Age = age;
        Position = position;
    }

    public string GetFullTimeStatus()
    {
        return IsFullTime ? "Yes" : "No";
    }
}
```

## Câu hỏi kiểm tra

**Câu 1: Sự khác biệt giữa Field và Property? Tại sao public data nên là Property?**

<details>
<summary>Đáp án</summary>

Field là biến đơn thuần (`public string Name;`), bên ngoài đọc/ghi trực tiếp mà không kiểm soát được. Property (`public string Name { get; set; }`) có `get`/`set` accessor cho phép thêm logic kiểm tra, giới hạn quyền đọc/ghi (ví dụ `private set`), hoặc tính toán giá trị. Public data nên là Property vì: (1) có thể thêm validation sau mà không sửa code bên ngoài, (2) có thể giới hạn chỉ đọc hoặc chỉ ghi, (3) đây là convention chuẩn của C# — các framework như data binding, serialization đều dựa vào Property.
</details>

**Câu 2: Đoạn code sau có lỗi gì?**
```csharp
public Developer(string Name, int Age)
{
    Name = Name;
}
```

<details>
<summary>Đáp án</summary>

Tham số `Name` trùng tên property `Name`. Dòng `Name = Name;` gán tham số cho chính nó — property không được gán. Phải dùng `this.Name = Name;` hoặc tốt hơn: đổi tham số sang camelCase `public Developer(string name, int age)` rồi viết `Name = name;` — rõ ràng, không nhầm lẫn.
</details>

**Câu 3: Tại sao dùng guard clause tốt hơn if/else? Lỗi gì có thể xảy ra với if/else mà guard clause tránh được?**

<details>
<summary>Đáp án</summary>

Guard clause kiểm tra điều kiện lỗi ngay đầu method, loại bỏ sớm bằng `throw` hoặc `return`. Lợi ích: (1) Đọc từ trên xuống thấy ngay tất cả điều kiện lỗi, (2) Code phía dưới luôn chạy trong trạng thái hợp lệ, (3) Tránh bug thiếu `else` — như bug ngày 3 anh gặp: dùng if/else mà quên `else` trước `throw` cuối cùng khiến code luôn crash. Guard clause không có `else` nên không thể mắc lỗi này.
</details>

**Câu 4: Đoạn code sau có chạy được không? Tại sao?**
```csharp
var dev = new Developer("Test", 25, "Member");
dev.Name = "New Name";
```

<details>
<summary>Đáp án</summary>

Lỗi compile ở dòng 2. `Name` có `{ get; private set; }` — `private set` nghĩa là chỉ code bên trong class `Developer` mới gán được. Code bên ngoài (Program.cs) chỉ đọc được `dev.Name` chứ không ghi được. Dòng 1 chạy bình thường vì constructor nằm bên trong class.
</details>

**Câu 5: Nếu thêm field `Salary` cho Developer, anh sẽ dùng `{ get; set; }` hay `{ get; private set; }`? Giải thích lý do từ góc độ thực tế.**

<details>
<summary>Đáp án</summary>

Nên dùng `{ get; private set; }`. Lương là dữ liệu nhạy cảm, không nên cho bên ngoài class tùy ý thay đổi. Thay đổi lương nên đi qua một method có kiểm soát, ví dụ: `public void UpdateSalary(double newSalary, string approvedBy)` — để có thể validate (lương không âm, không vượt trần) và ghi log ai duyệt. Nếu dùng `{ get; set; }`, bất kỳ đoạn code nào cũng có thể viết `dev.Salary = -1000;` mà không ai biết.
</details>

---

[← Ngày 02](./day-02-class-object.md) | [Về README](../README.md) | [Ngày 04 →](./day-04-list-loop.md)

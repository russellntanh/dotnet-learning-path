# Ngày 02 — Class và Object

## Key Points

### 1. Class = bản thiết kế, Object = sản phẩm cụ thể

```csharp
// Class — định nghĩa 1 lần
class Developer
{
    public string Name;
    public int Age;
}

// Object — tạo nhiều lần từ cùng 1 class
Developer dev1 = new Developer();  // Object thứ 1
Developer dev2 = new Developer();  // Object thứ 2, data khác
```

| | Class | Object |
|---|---|---|
| Là gì | Bản thiết kế | Thực thể cụ thể |
| Khi nào tồn tại | Viết code | Runtime (khi `new`) |
| Ví dụ | Bản vẽ máy AOI | Máy AOI cụ thể ở nhà máy |

### 2. Field — biến bên trong class

```csharp
class Developer
{
    public string Name;              // field
    public int Age;                  // field
    public double YearOfExperience;  // field
}
```

### 3. Object Initializer — cách tạo object gọn gàng

```csharp
// Cách dài
var dev = new Developer();
dev.Name = "Khuong.Duong";
dev.Age = 43;

// Object initializer — gọn hơn, recommend
var dev = new Developer
{
    Name = "Khuong.Duong",
    Age = 43,
    YearOfExperience = 20
};
```

### 4. `var` — compiler tự suy ra kiểu

```csharp
var dev = new Developer { ... };  // Compiler biết dev là Developer
var name = "Hello";               // Compiler biết name là string
var age = 25;                     // Compiler biết age là int
```

`var` chỉ dùng được khi vế phải rõ kiểu. Không phải "dynamic type" — kiểu vẫn cố định sau khi khai báo.

### 5. Mỗi class nên nằm trong 1 file riêng

Convention: tên file = tên class + `.cs`

```
Developer.cs   → chứa class Developer
Program.cs     → chứa class Program
```

### 6. Method trong class — đóng gói hành vi

```csharp
class Developer
{
    public bool IsFullTime;

    public string GetFullTimeStatus()
    {
        return IsFullTime ? "Yes" : "No";
    }
}

// Gọi method qua object
Console.WriteLine(dev.GetFullTimeStatus());  // "Yes" hoặc "No"
```

## Ví dụ tổng hợp

```csharp
// Developer.cs
public class Developer
{
    public string Name;
    public int Age;
    public string Position;
    public double YearOfExperience;
    public bool IsFullTime;

    public string GetFullTimeStatus()
    {
        return IsFullTime ? "Yes" : "No";
    }
}

// Program.cs
var dev = new Developer
{
    Name = "Khuong.Duong",
    Age = 43,
    Position = "Team Leader",
    YearOfExperience = 20,
    IsFullTime = true
};

Console.WriteLine($"{dev.Name} - {dev.Position}");
Console.WriteLine($"Fulltime: {dev.GetFullTimeStatus()}");
```

## Câu hỏi kiểm tra

**Câu 1: Đoạn code sau có lỗi gì?**
```csharp
var dev = new Developer();
Console.WriteLine(dev.Name.Length);
```

<details>
<summary>Đáp án</summary>

Lỗi runtime: `NullReferenceException`. Khi tạo `new Developer()` mà không gán `Name`, giá trị mặc định của `string` là `null`. Gọi `.Length` trên `null` sẽ crash. Đây chính là lý do ngày 3 học Constructor — bắt buộc phải gán giá trị khi tạo object.
</details>

**Câu 2: Class và Object khác nhau thế nào? Cho ví dụ ngoài lập trình.**

<details>
<summary>Đáp án</summary>

Class là bản thiết kế, Object là sản phẩm cụ thể tạo từ bản thiết kế đó. Ví dụ: class = bản vẽ kỹ thuật máy SPI, object = chiếc máy SPI cụ thể đang chạy ở nhà máy Samsung. Một bản vẽ có thể sản xuất ra nhiều máy (nhiều object), mỗi máy có serial number khác nhau (data khác nhau) nhưng cùng cấu trúc.
</details>

**Câu 3: Nếu team có 30 người, cách dùng biến rời (ngày 1) cần bao nhiêu biến? Cách dùng class (ngày 2) cần bao nhiêu object?**

<details>
<summary>Đáp án</summary>

Biến rời: 30 người × 5 field = 150 biến. Class: 30 object, mỗi object chứa 5 field bên trong. Số field không giảm, nhưng chúng được đóng gói gọn gàng — `dev1.Name` luôn đi cùng `dev1.Age`, không thể gán nhầm.
</details>

**Câu 4: Muốn thêm field `Email` cho Developer — cách biến rời phải sửa bao nhiêu chỗ? Cách class phải sửa bao nhiêu chỗ?**

<details>
<summary>Đáp án</summary>

Biến rời: thêm 30 biến `emailX` + sửa 30 chỗ hiển thị = khoảng 60 chỗ. Class: thêm 1 field `public string Email;` trong `Developer.cs` + gán giá trị ở 30 object + sửa phần hiển thị. Điểm khác biệt: với class, nếu quên gán Email cho 1 object, tất cả field vẫn thuộc cùng 1 object nên dễ phát hiện. Biến rời thì quên 1 trong 150 biến rất khó tìm.
</details>

**Câu 5: `var dev = new Developer { ... }` và `Developer dev = new Developer { ... }` — hai cách này có khác nhau về kết quả không? Khi nào nên dùng `var`?**

<details>
<summary>Đáp án</summary>

Không khác nhau về kết quả — cả hai đều tạo biến kiểu `Developer`. `var` chỉ là cú pháp rút gọn, compiler tự suy ra kiểu từ vế phải. Nên dùng `var` khi vế phải đã rõ kiểu (ví dụ `new Developer(...)` — ai cũng thấy đây là Developer). Không nên dùng `var` khi kiểu không rõ ràng (ví dụ `var result = GetData();` — không biết result là kiểu gì).
</details>

---

[← Ngày 01](./day-01-variables.md) | [Về README](../README.md) | [Ngày 03 →](./day-03-constructor.md)

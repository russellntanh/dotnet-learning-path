# Ngày 01 — Biến và kiểu dữ liệu

## Key Points

### 1. Mỗi biến đều có kiểu (type)

C# là ngôn ngữ **strongly typed** — phải khai báo kiểu trước khi dùng. Compiler kiểm tra kiểu tại thời điểm build, không phải lúc chạy.

```csharp
string name = "Khuong.Duong";   // Văn bản
int age = 43;                    // Số nguyên
double experience = 3.5;         // Số thập phân
bool isFullTime = true;          // Đúng/Sai
```

### 2. String Interpolation — cách nối chuỗi chuẩn trong C#

Dùng `$"..."` với `{biến}` bên trong — dễ đọc hơn nhiều so với nối bằng `+`.

```csharp
// ❌ Nối chuỗi bằng + — khó đọc khi nhiều biến
Console.WriteLine("Name: " + name + ", Age: " + age);

// ✅ String interpolation — đọc tự nhiên
Console.WriteLine($"Name: {name}, Age: {age}");
```

### 3. Ternary Operator — rút gọn if/else thành 1 dòng

```csharp
// Cú pháp: điều_kiện ? giá_trị_nếu_đúng : giá_trị_nếu_sai
string status = isFullTime ? "Yes" : "No";
```

### 4. Console.WriteLine() vs Console.WriteLine("\n")

```csharp
Console.WriteLine();      // In 1 dòng trống
Console.WriteLine("\n");  // In 2 dòng trống (thừa 1)
```

### 5. Tránh hardcode "magic number"

```csharp
// ❌ Hardcode — nếu thêm/xóa người phải nhớ sửa
Console.WriteLine("Total: 5");

// ✅ Dùng biến — sửa 1 chỗ
int totalMembers = 5;
Console.WriteLine($"Total: {totalMembers}");
```

## Ví dụ tổng hợp

```csharp
string name = "Khuong.Duong";
int age = 43;
double yearOfExperience = 20.0;
bool isFullTime = true;

string status = isFullTime ? "Yes" : "No";
Console.WriteLine($"{name}");
Console.WriteLine($"   Age: {age} | Experience: {yearOfExperience} years | Fulltime: {status}");
```

## Câu hỏi kiểm tra

**Câu 1: `int` và `double` khác nhau thế nào? Khi nào dùng `int`, khi nào dùng `double`?**

<details>
<summary>Đáp án</summary>

`int` chứa số nguyên (1, 2, -5), `double` chứa số thập phân (3.5, 10.0). Dùng `int` khi giá trị chắc chắn là số nguyên (tuổi, số lượng người). Dùng `double` khi có thể có phần thập phân (số năm kinh nghiệm 3.5 năm, điểm số 8.7).
</details>

**Câu 2: Đoạn code sau in ra gì?**
```csharp
int x = 7;
int y = 2;
Console.WriteLine($"Result: {x / y}");
```

<details>
<summary>Đáp án</summary>

In ra `Result: 3` — không phải 3.5. Vì `int / int = int`, phần thập phân bị cắt bỏ. Nếu muốn kết quả 3.5, cần ép kiểu: `(double)x / y` hoặc khai báo `double x = 7.0;`.
</details>

**Câu 3: Đoạn code sau có vấn đề gì?**
```csharp
string age = 25;
Console.WriteLine($"Age: {age}");
```

<details>
<summary>Đáp án</summary>

Lỗi compile. Không thể gán số `25` (kiểu `int`) vào biến kiểu `string`. Phải sửa thành `int age = 25;` hoặc `string age = "25";` (nhưng dùng string cho tuổi là không hợp lý vì không tính toán được).
</details>

**Câu 4: `$"Hello {name}"` và `"Hello " + name` — cả 2 đều cho cùng kết quả. Tại sao nên dùng cách đầu?**

<details>
<summary>Đáp án</summary>

String interpolation (`$"..."`) dễ đọc hơn khi có nhiều biến, ít lỗi hơn (không quên dấu `+` hay khoảng trắng), và dễ thấy rõ cấu trúc chuỗi kết quả. Ví dụ: `$"Name: {name}, Age: {age}, Exp: {exp}"` rõ ràng hơn rất nhiều so với `"Name: " + name + ", Age: " + age + ", Exp: " + exp`.
</details>

**Câu 5: Viết 1 dòng code dùng ternary operator: nếu `age >= 18` thì in "Adult", ngược lại in "Minor".**

<details>
<summary>Đáp án</summary>

```csharp
string category = age >= 18 ? "Adult" : "Minor";
Console.WriteLine(category);

// Hoặc gọn hơn, viết trực tiếp trong interpolation:
Console.WriteLine($"{(age >= 18 ? "Adult" : "Minor")}");
```
</details>

---

[← Về README](../README.md) | [Ngày 02 →](./day-02-class-object.md)

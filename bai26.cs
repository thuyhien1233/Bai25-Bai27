using System;

// Lớp trừu tượng Person
abstract class Person
{
    // Các thuộc tính
    public string Name { get; set; }
    public int Age { get; set; }

    // Hàm khởi tạo
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Phương thức trừu tượng
    public abstract override string ToString();
}

// Lớp Student kế thừa từ Person
class Student : Person
{
    // Thuộc tính Major
    public string Major { get; set; }

    // Hàm khởi tạo
    public Student(string name, int age, string major) : base(name, age)
    {
        Major = major;
    }

    // Ghi đè phương thức ToString
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}";
    }
}

// Lớp Program chứa hàm Main
class bai26
{
    static void Main(string[] args)
    {
        // Tạo đối tượng Student
        Student student = new Student("Nguyen Tien Dung", 20, "CNTT&TT");

        // Sử dụng phương thức ToString để hiển thị thông tin đối tượng
        Console.WriteLine(student.ToString());
    }
}

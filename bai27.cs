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

// Giao diện KPI
interface KPI
{
    double CalculateKPI();
}

// Lớp Student kế thừa từ Person và cài đặt KPI
class Student : Person, KPI
{
    // Thuộc tính Major và GPA
    public string Major { get; set; }
    public float GPA { get; set; }

    // Hàm khởi tạo
    public Student(string name, int age, string major, float gpa) : base(name, age)
    {
        Major = major;
        GPA = gpa;
    }

    // Ghi đè phương thức ToString
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}, GPA: {GPA}";
    }

    // Cài đặt phương thức CalculateKPI
    public double CalculateKPI()
    {
        return GPA;
    }
}

// Lớp Teacher kế thừa từ Person và cài đặt KPI
class Teacher : Person, KPI
{
    // Thuộc tính Major và Publications
    public string Major { get; set; }
    public int Publications { get; set; }

    // Hàm khởi tạo
    public Teacher(string name, int age, string major, int publications) : base(name, age)
    {
        Major = major;
        Publications = publications;
    }

    // Ghi đè phương thức ToString
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}, Publications: {Publications}";
    }

    // Cài đặt phương thức CalculateKPI
    public double CalculateKPI()
    {
        return 1.5 * Publications;
    }
}

// Lớp Program chứa hàm Main
class bai27
{
    static void Main(string[] args)
    {
        // Tạo đối tượng Student
        Student student = new Student("Nguyen Tien Dung", 20, "CNTT&TT", 3.8f);

        // Tạo đối tượng Teacher
        Teacher teacher = new Teacher("Vu Duc Viet", 38, "CNTT&TT", 5);

        // Hiển thị thông tin và KPI của đối tượng Student
        Console.WriteLine(student.ToString());
        Console.WriteLine($"KPI: {student.CalculateKPI()}");

        // Hiển thị thông tin và KPI của đối tượng Teacher
        Console.WriteLine(teacher.ToString());
        Console.WriteLine($"KPI: {teacher.CalculateKPI()}");
    }
}


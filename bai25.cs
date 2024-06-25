using System;
using System.Collections.Generic;

abstract class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    protected string BankAccount { get; set; }

    public Person(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public abstract string GetRole();
}

interface KPIEvaluator
{
    double CalculateKPI();
}

class TeachingAssistant : Person, KPIEvaluator
{
    public string EmployeeID { get; set; }
    private int NumberOfCourses { get; set; }

    public TeachingAssistant(string name, int age, string gender, string employeeID, int numberOfCourses)
        : base(name, age, gender)
    {
        EmployeeID = employeeID;
        NumberOfCourses = numberOfCourses;
    }

    public override string GetRole()
    {
        return "Teaching Assistant";
    }

    public double CalculateKPI()
    {
        return NumberOfCourses * 5;
    }
}

class Lecturer : Person, KPIEvaluator
{
    public string EmployeeID { get; set; }
    private int NumberOfPublications { get; set; }

    public Lecturer(string name, int age, string gender, string employeeID, int numberOfPublications)
        : base(name, age, gender)
    {
        EmployeeID = employeeID;
        NumberOfPublications = numberOfPublications;
    }

    public override string GetRole()
    {
        return "Lecturer";
    }

    public double CalculateKPI()
    {
        return NumberOfPublications * 7;
    }
}

sealed class Professor : Lecturer
{
    public static int CountProfessors = 0;
    private int NumberOfProjects { get; set; }

    public Professor(string name, int age, string gender, string employeeID, int numberOfPublications, int numberOfProjects)
        : base(name, age, gender, employeeID, numberOfPublications)
    {
        NumberOfProjects = numberOfProjects;
        CountProfessors++;
    }

    public override string GetRole()
    {
        return "Professor";
    }

    public new double CalculateKPI()
    {
        return base.CalculateKPI() + NumberOfProjects * 10;
    }
}

class bai25
{
    static void Main(string[] args)
    {
        // Tạo một số đối tượng mẫu
        TeachingAssistant ta = new TeachingAssistant("John Doe", 25, "Male", "TA123", 4);
        Lecturer lec = new Lecturer("Jane Smith", 40, "Female", "LE456", 10);
        Professor prof = new Professor("Dr. Brown", 55, "Male", "PR789", 20, 5);

        // Sử dụng phương thức getRole() và calculateKPI() để in thông tin
        Console.WriteLine($"{ta.Name}: Role = {ta.GetRole()}, KPI = {ta.CalculateKPI()}");
        Console.WriteLine($"{lec.Name}: Role = {lec.GetRole()}, KPI = {lec.CalculateKPI()}");
        Console.WriteLine($"{prof.Name}: Role = {prof.GetRole()}, KPI = {prof.CalculateKPI()}");

        // Nhập và hiển thị mảng đối tượng
        List<Person> persons = InputPersons();
        DisplayPersons(persons);

        // Hiển thị số lượng Professor
        Console.WriteLine($"Total number of Professors: {Professor.CountProfessors}");
    }

    static List<Person> InputPersons()
    {
        List<Person> persons = new List<Person>();
        int n;

        do
        {
            Console.Write("Enter the number of persons (2-10): ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 2 || n > 10);

        for (int i = 0; i < n; i++)
        {
            Person person = null;
            string type;

            do
            {
                Console.Write("Enter the type of person (ta, lec, gs): ");
                type = Console.ReadLine().ToLower();
            } while (type != "ta" && type != "lec" && type != "gs");

            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter gender: ");
            string gender = Console.ReadLine();

            switch (type)
            {
                case "ta":
                    Console.Write("Enter employee ID: ");
                    string taEmployeeID = Console.ReadLine();
                    Console.Write("Enter number of courses: ");
                    int numberOfCourses = int.Parse(Console.ReadLine());
                    person = new TeachingAssistant(name, age, gender, taEmployeeID, numberOfCourses);
                    break;
                case "lec":
                    Console.Write("Enter employee ID: ");
                    string lecEmployeeID = Console.ReadLine();
                    Console.Write("Enter number of publications: ");
                    int numberOfPublications = int.Parse(Console.ReadLine());
                    person = new Lecturer(name, age, gender, lecEmployeeID, numberOfPublications);
                    break;
                case "gs":
                    Console.Write("Enter employee ID: ");
                    string profEmployeeID = Console.ReadLine();
                    Console.Write("Enter number of publications: ");
                    int profNumberOfPublications = int.Parse(Console.ReadLine());
                    Console.Write("Enter number of projects: ");
                    int numberOfProjects = int.Parse(Console.ReadLine());
                    person = new Professor(name, age, gender, profEmployeeID, profNumberOfPublications, numberOfProjects);
                    break;
            }

            persons.Add(person);
        }

        return persons;
    }

    static void DisplayPersons(List<Person> persons)
    {
        foreach (var person in persons)
        {
            string role = person.GetRole();
            double kpi = ((KPIEvaluator)person).CalculateKPI();
            Console.WriteLine($"{person.Name}: Role = {role}, KPI = {kpi}");
        }
    }
}


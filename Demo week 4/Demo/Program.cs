using System;                     // .NET library for basic classes
using System.Data;                // For DataTable
using System.IO;                  // For File Operations
using System.Globalization;       // For Date formatting


namespace CSharpFundamentalsWeek3
{
    public enum UserRole
    {
        Admin,
        Manager,
        Developer,
        Guest
    }


    public class Person
    {
        public string Name;         // Accessible everywhere
        private int age;            // Accessible only inside class
        protected string Address;   // Accessible in this & derived classes
        internal string Email;      // Accessible within same assembly
        protected internal string Phone; // Accessible within assembly & derived classes

        public Person(string name, int age, string address, string email, string phone)
        {
            this.Name = name;
            this.age = age;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {age}, Address: {Address}, Email: {Email}, Phone: {Phone}");
        }
    }

    // Derived class to show "protected" usage
    public class Employee : Person
    {
        public UserRole Role;

        public Employee(string name, int age, string address, string email, string phone, UserRole role)
            : base(name, age, address, email, phone)
        {
            this.Role = role;
        }

        public void ShowEmployeeDetails()
        {
            // Can access protected Address from base class
            Console.WriteLine($"Employee: {Name}, Role: {Role}, Address: {Address}");
        }
    }


    // Main Program

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# Fundamentals Week 3 Demo ===");

            // 1. Enum Demo
            Employee emp = new Employee("Heer", 22, "Ahmedabad", "heer@example.com", "1234567890", UserRole.Developer);
            emp.ShowInfo();
            emp.ShowEmployeeDetails();

            // 2. DataTable Demo
            DataTable dt = new DataTable("Employees");
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Role", typeof(string));
            dt.Rows.Add(1, "Heer", "Developer");
            dt.Rows.Add(2, "Raj", "Manager");

            Console.WriteLine("\n--- DataTable Example ---");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}, Role: {row["Role"]}");
            }

            // 3. Date / String / Math Demo
            Console.WriteLine("\n--- Date / String / Math Example ---");
            DateTime now = DateTime.Now;
            Console.WriteLine("Current Date: " + now.ToString("dd-MMM-yyyy hh:mm tt", CultureInfo.InvariantCulture));

            string fullName = "  heer gupta  ";
            Console.WriteLine("Trimmed Name: " + fullName.Trim().ToUpper());

            double number = 25.7;
            Console.WriteLine($"Square Root of {number}: {Math.Sqrt(number)}");
            Console.WriteLine($"Power (2^3): {Math.Pow(2, 3)}");
            Console.WriteLine($"Round of {number}: {Math.Round(number)}");


            // Reading and Writing to file
            string filePath = @"C:\DemoFolder\sample.txt";

            // Ensure directory exists
            Directory.CreateDirectory(@"C:\DemoFolder");

            // Write text to file
            File.WriteAllText(filePath, "Hello, C#!\nWelcome to File Handling.");

            Console.WriteLine("File created and written successfully.");

            string content = File.ReadAllText(@"C:\DemoFolder\sample.txt");
            Console.WriteLine("File Content:\n" + content);




        }
    }
}



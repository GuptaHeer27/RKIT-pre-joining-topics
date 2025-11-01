using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Week_5
{
    internal class LINQList
    {

        public static void RunLINQList()
        {
            List<Student> students = new List<Student>()
            {new Student { Id = 1, Name = "abc", Age = 21, Course = "C#", Marks = 85 },
                new Student { Id = 2, Name = "def", Age = 22, Course = "Java", Marks = 75 },
                new Student { Id = 3, Name = "ghi", Age = 20, Course = "C#", Marks = 90 },
                new Student { Id = 4, Name = "jkl", Age = 23, Course = "Python", Marks = 70 },
                new Student { Id = 5, Name = "mno", Age = 21, Course = "C#", Marks = 60 }
            };


            // Filtering Students who has marks more than 70
            var highScorers = students.Where(s => s.Marks > 70);  // Here instead of var we can use IEnumerable<Student> and List<Student>
            Console.WriteLine("Students with Marks > 70:");
            foreach (var s in highScorers)
                Console.WriteLine($"{s.Name} - {s.Marks}");


            // Order By
            var SortedStudents= students.OrderByDescending(s => s.Marks);
            Console.WriteLine("Students Students sorted by Marks (Descending):");
            foreach (var s in SortedStudents) Console.WriteLine($"{s.Name} - {s.Marks}");

            //Projection 
            var StuName = students.Select(s => s.Name);
            Console.WriteLine("List of students Name");
            foreach(var s in StuName) Console.WriteLine(s);


            // Group By
            var groupedByCourse = students.GroupBy(s => s.Course);
            Console.WriteLine("Students grouped by Course:");
            foreach (var group in groupedByCourse)
            {
                Console.WriteLine($"\nCourse: {group.Key}");
                foreach (var s in group)
                    Console.WriteLine($"  {s.Name} - Marks: {s.Marks}");
            }


            //  Aggregate Functions
            var averageMarks = students.Average(s => s.Marks);
            var maxMarks = students.Max(s => s.Marks);
            var minMarks = students.Min(s => s.Marks);
            Console.WriteLine($"Average Marks: {averageMarks}");
            Console.WriteLine($"Highest Marks: {maxMarks}");
            Console.WriteLine($"Lowest Marks: {minMarks}");


            // Quantifiers
            bool anyFailed = students.Any(s => s.Marks < 40);
            bool allPassed = students.All(s => s.Marks > 40);
            Console.WriteLine($"Any student failed (<40)? {anyFailed}");
            Console.WriteLine($"All students passed (>40)? {allPassed}");

            // Element
            var firstStudent = students.First(); // First element
            var lastStudent = students.Last();   // Last element
            Console.WriteLine($"First student: {firstStudent.Name}");
            Console.WriteLine($"Last student: {lastStudent.Name}");

           
           


        }
    }
}

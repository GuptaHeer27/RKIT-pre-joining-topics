using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Week_5
{
    internal class LinqDataTableDemo
    {

        public static void RunDataTableDemo()
        {
            Console.WriteLine("\n LINQ DEMO WITH DATA TABLE ");

            //  Create DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Marks", typeof(int));
            dt.Columns.Add("Course", typeof(string));

            //  Add rows
            dt.Rows.Add(1, "pqr", 85, "C#");
            dt.Rows.Add(2, "stu", 75, "Java");
            dt.Rows.Add(3, "vwx", 90, "C#");
            dt.Rows.Add(4, "yza", 70, "Python");
            dt.Rows.Add(5, "bcd", 60, "C#");

            // 3 LINQ Query: Filter students with Marks > 70
            var highScorers = dt.AsEnumerable()
                                 .Where(row => row.Field<int>("Marks") > 70);

            Console.WriteLine("\nStudents with Marks > 70:");
            foreach (var row in highScorers)
                Console.WriteLine($"{row.Field<string>("Name")} - {row.Field<int>("Marks")}");

            //  LINQ Query: Order by Marks descending
            var sorted = dt.AsEnumerable()
                           .OrderByDescending(row => row.Field<int>("Marks"));

            Console.WriteLine("\nStudents sorted by Marks (Descending):");
            foreach (var row in sorted)
                Console.WriteLine($"{row.Field<string>("Name")} - {row.Field<int>("Marks")}");

            //  LINQ Query: Select only Names
            var names = dt.AsEnumerable()
                          .Select(row => row.Field<string>("Name"));

            Console.WriteLine("\nAll Student Names:");
            Console.WriteLine(string.Join(", ", names));

            //  LINQ Query: Group by Course
            var grouped = dt.AsEnumerable()
                            .GroupBy(row => row.Field<string>("Course"));

            Console.WriteLine("\nStudents grouped by Course:");
            foreach (var group in grouped)
            {
                Console.WriteLine($"Course: {group.Key}");
                foreach (var row in group)
                    Console.WriteLine($"  {row.Field<string>("Name")} - {row.Field<int>("Marks")}");
            }

            //  Aggregate Example
            var averageMarks = dt.AsEnumerable().Average(row => row.Field<int>("Marks"));
            var maxMarks = dt.AsEnumerable().Max(row => row.Field<int>("Marks"));
            Console.WriteLine($"\nAverage Marks: {averageMarks}");
            Console.WriteLine($"Highest Marks: {maxMarks}");
        }

    }
}
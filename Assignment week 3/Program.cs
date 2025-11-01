using System;
using System.Data;
using System.IO;

namespace LibraryCheckIn.Domain
{
    public enum BookCondition
    {
        New,
        Good,
        Worn,
        Damage
    }

    /// <summary>
    /// 
    /// </summary>
    public class Book
    {
       public int Id { get; set; } // public as it can be accessed from anywhere
        public string Title { get; set; }
        public string Author { get; set; }
        public BookCondition Condition { get; set; }
       
        // Constructor
        public Book(int id, string title, string author, BookCondition condition)
        {
            Id = id;
            Title = title;
            Author = author;
            Condition = condition;
        }
        public override string ToString()
        {
            return $"{Title} by {Author} [{Condition}]";
        }


    }


}


namespace LibraryCheckIn.IO
{
    using LibraryCheckIn.Domain;
    using static System.Reflection.Metadata.BlobBuilder;

    public class LibraryProcessor
    {
        public DataTable LoadCSV(String filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("CSV file not found!");
            }
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Author", typeof(string));
            table.Columns.Add("Condition", typeof(string));

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // skip header
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    table.Rows.Add(
                        int.Parse(parts[0]),
                        parts[1],
                        parts[2],
                        parts[3]
                    );
                }
            }
            return table;
        }

        public List<Book> MapToBooks(DataTable table)
        {
            var book=new List<Book>();
            foreach(DataRow row in table.Rows)
            {
                try
                {
                    BookCondition cond = Enum.Parse<BookCondition>(row["Condition"].ToString(), true);
                    book.Add(new Book(
                        Convert.ToInt32(row["Id"]),
                        row["Title"].ToString(),
                        row["Author"].ToString(),
                        cond
                    ));
                }
                catch
                {
                    Console.WriteLine("Invalid row skipped.");
                }
            }
            return book;
        }

       
        
            public static int GetPenalty(BookCondition condition)
            {
                if (condition == BookCondition.New)
                    return -1;
                else if (condition == BookCondition.Good)
                    return 0;
                else if (condition == BookCondition.Worn)
                    return 3;
                else if (condition == BookCondition.Damage)
                    return 10;
                else
                    return 0; // default
            }
        

        // Generate Report
        public void GenerateReport(List<Book> books, string outputPath)
        {
            string dateStr = DateTime.Now.ToString("yyyyMMdd");
            string reportFile = Path.Combine(outputPath, $"daily_summary_{dateStr}.txt");

            using (StreamWriter sw = new StreamWriter(reportFile))
            {
                sw.WriteLine($"Date Processed: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                sw.WriteLine($"Total Returns: {books.Count}");

                // Count by Condition
                var grouped = books.GroupBy(b => b.Condition)
                                   .Select(g => $"{g.Key}: {g.Count()}");
                sw.WriteLine("Condition Counts:");
                foreach (var line in grouped) sw.WriteLine("  " + line);

                // Compute penalties
                var bookScores = books.Select(b => new
                {
                    b.Title,
                    b.Author,
                    Penalty = Math.Clamp(GetPenalty(b.Condition), 0, 100)
                });

                // Top 5 titles by penalty
                var top5 = bookScores.OrderByDescending(b => b.Penalty).Take(5);
                sw.WriteLine("\nTop 5 Titles by Penalty:");
                foreach (var b in top5)
                {
                    sw.WriteLine($"{b.Title} by {b.Author} => Penalty {b.Penalty}");
                }
            }

            Console.WriteLine($"Report generated: {reportFile}");

        }

        }
}

namespace LibraryCheckIn
{
    using LibraryCheckIn.IO;
    using LibraryCheckIn.Domain;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Library Check-In Utility ===");

            string inputCsv = "input.csv"; // Example CSV filename
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                               .Parent.Parent.Parent.FullName;

            string outputDir = Path.Combine(projectDir, "out");
            Directory.CreateDirectory(outputDir);


            try
            {
                LibraryProcessor processor = new LibraryProcessor();

                // Step 1: Load CSV -> DataTable
                DataTable dt = processor.LoadCSV(inputCsv);

                // Step 2: Map to Book objects
                List<Book> books = processor.MapToBooks(dt);

                // Step 3: Generate Report
                processor.GenerateReport(books, outputDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("=== End ===");
        }
    }
}




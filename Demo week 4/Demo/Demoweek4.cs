using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;



namespace Demo
{
   // Abstraction
   abstract class Payment
    {
        public abstract void Pay(Decimal amount);

        public void ShowReceipt()
        {
            Console.WriteLine("Transaction Completed");

        }
    }
    class newPayment : Payment
    {
        public override void Pay(Decimal amount)
        {
            throw new NotImplementedException();

        }
    }
    class CreditCardPayment : Payment
    {
        public override void Pay(Decimal amount)
        {
            Console.WriteLine("Paid" + amount + "via credit card");
        }
    }

        class UpiPayment : Payment
        {
            public override void Pay(Decimal amount)
            {
                Console.WriteLine("Paid" + amount + "via upi");
            }
        }

    // Sealed class
    public class Account
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }

        public virtual void Withdraw(double amount)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount}, remaining balance: {Balance}");
        }
    }
    public class SavingsAccount : Account
    {
        public override void Withdraw(double amount)
        {
            if (Balance - amount < 1000)
                Console.WriteLine("Minimum balance limit reached!");
            else
                base.Withdraw(amount);
        }
    }

    public sealed class FinalAccountStatement
    {
        public string AccountNumber { get; set; }
        public string Month { get; set; }

        public void GenerateStatement()
        {
            Console.WriteLine($"Generating final statement for {AccountNumber} for month {Month}");
        }
    }

    //  The following would cause an error:
    // public class CustomStatement : FinalAccountStatement { }


    // Interface
    interface ICallable
    {
        void MakeCall(string number);
    }

    // Interface for browsing capability
    interface IBrowsable
    {
        void Browse(string url);
    }

    // Smartphone implements both interfaces
    class Smartphone : ICallable, IBrowsable
    {
        public void MakeCall(string number)
        {
            Console.WriteLine($"Smartphone is calling {number}...");
        }

        public void Browse(string url)
        {
            Console.WriteLine($"Smartphone is browsing {url}...");
        }
    }

    // Landline implements only calling
    class Landline : ICallable
    {
        public void MakeCall(string number)
        {
            Console.WriteLine($"Landline is calling {number}...");
        }
    }

    // WiFiTablet implements only browsing
    class WiFiTablet : IBrowsable
    {
        public void Browse(string url)
        {
            Console.WriteLine($"WiFiTablet is browsing {url}...");
        }
    }


    // Generics
    class GenericList<T>
    {
        private T[] items = new T[10];
        private int count = 0;

        public void Add(T item)
        {
            items[count++] = item;
        }

        public T Get(int index)
        {
            return items[index];
        }
    }




    class Pro
    {
        //  Generic Method
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

    }
    // Serialization
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }

    }

    class Program
            {
                static void Main(string[] args) {

            



            ICallable phone = new Smartphone();
            phone.MakeCall("1234567890");

            IBrowsable browser = new Smartphone();
            browser.Browse("www.example.com");

            ICallable landline = new Landline();
            landline.MakeCall("0987654321");

            IBrowsable tablet = new WiFiTablet();
            tablet.Browse("www.google.com");


            GenericList<int> intList = new GenericList<int>();
            intList.Add(10);
            intList.Add(20);
            Console.WriteLine(intList.Get(0));  // Output: 10

            GenericList<string> stringList = new GenericList<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            Console.WriteLine(stringList.Get(1)); // Output: World


            int x = 10, y = 20;
            Console.WriteLine($"Before Swap: x = {x}, y = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"After Swap:  x = {x}, y = {y}\n");

          //  File operations:


            string filePath = @"C:\DemoFolder\sample.txt";

            // Ensure directory exists
            Directory.CreateDirectory(@"C:\DemoFolder");

            // Write text to file
            File.WriteAllText(filePath, "Hello, C#!\nWelcome to File Handling.");

            Console.WriteLine("File created and written successfully.");


            string content = File.ReadAllText(@"C:\DemoFolder\sample.txt");  // Reading from file
            Console.WriteLine("File Content:\n" + content);


            File.AppendAllText(@"C:\DemoFolder\sample.txt", "\nAppended line at: " + "Appended");



            string source = @"C:\DemoFolder\sample.txt";
            string copy = @"C:\DemoFolder\copy_sample.txt";
            string moved = @"C:\DemoFolder\Moved\sample.txt";

            // Copy
            File.Copy(source, copy, true); // true allows overwrite
            Console.WriteLine("File copied.");

            // Move
            Directory.CreateDirectory(@"C:\DemoFolder\Moved");
            File.Move(source, moved);
            Console.WriteLine("File moved.");

            // Delete
            File.Delete(copy);
            Console.WriteLine("Copied file deleted.");


            //FileInfo fi = new FileInfo(@"C:\DemoFolder\Moved\sample.txt");

            if (fi.Exists)
            {
                Console.WriteLine($"File Name: {fi.Name}");
                Console.WriteLine($"Extension: {fi.Extension}");
                Console.WriteLine($"Size: {fi.Length} bytes");
                Console.WriteLine($"Created: {fi.CreationTime}");
                Console.WriteLine($"Last Accessed: {fi.LastAccessTime}");
            }

            using (StreamWriter sw = new StreamWriter(@"C:\DemoFolder\data.txt"))
            {
                sw.WriteLine("Line 1");
                sw.WriteLine("Line 2");
                sw.WriteLine("End of file.");
            }
            Console.WriteLine("Data written using StreamWriter.");

            using (StreamReader sr = new StreamReader(@"C:\DemoFolder\data.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }


            // Collections
            ArrayList list = new ArrayList();

                        // Add elements
                        list.Add(10);
                        list.Add(20);
                        list.Add("Heer");
                        Console.WriteLine("After Add():");
                        foreach (var item in list) Console.WriteLine(item);

                        // AddRange()
                        list.AddRange(new int[] { 30, 40 });
                        Console.WriteLine("\nAfter AddRange():");
                        foreach (var item in list) Console.WriteLine(item);

                        // Insert()
                        list.Insert(2, "Inserted");
                        Console.WriteLine("\nAfter Insert():");
                        foreach (var item in list) Console.WriteLine(item);

                        // Contains()
                        Console.WriteLine("\nContains(\"Heer\"): " + list.Contains("Heer"));

                        // IndexOf()
                        Console.WriteLine("IndexOf(20): " + list.IndexOf(20));

                        // Remove()
                        list.Remove("Heer");
                        Console.WriteLine("\nAfter Remove(\"Heer\"):");
                        foreach (var item in list) Console.WriteLine(item);

                        // RemoveAt()
                        list.RemoveAt(0);
                        Console.WriteLine("\nAfter RemoveAt(0):");
                        foreach (var item in list) Console.WriteLine(item);

                        // Sort() (only works if all elements are comparable)
                        ArrayList nums = new ArrayList() { 5, 2, 9, 1 };                    //// What if one value is String
                        list.Sort();
                        Console.WriteLine("\nSorted ArrayList:");                           //// Arraylist having two values new value at index 5 what will be count
                        foreach (var item in nums) Console.WriteLine(item);

                        // Reverse()
                        nums.Reverse();
                        Console.WriteLine("\nReversed ArrayList:");                         //// when to use which type of generic collections (2 cases)
                        foreach (var item in nums) Console.WriteLine(item);

                        // Count
                        Console.WriteLine("\nCount: " + list.Count);

                        // Clear()
                        list.Clear();
                        Console.WriteLine("After Clear(): Count = " + list.Count);





          /



            Stack stack = new Stack();

            // Push()
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            Console.WriteLine("After Push():");
            foreach (var item in stack) Console.WriteLine(item); // C, B, A

            // Peek()
            Console.WriteLine("\nPeek(): " + stack.Peek());

            // Pop()
            Console.WriteLine("Pop(): " + stack.Pop());
            Console.WriteLine("After Pop():");
            foreach (var item in stack) Console.WriteLine(item); // B, A

            // Contains()
            Console.WriteLine("\nContains(\"A\"): " + stack.Contains("A"));

            // Count
            Console.WriteLine("Count: " + stack.Count);

            // Clear()
            stack.Clear();
            Console.WriteLine("After Clear(): Count = " + stack.Count);





            Queue queue = new Queue();

            // Enqueue()
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            Console.WriteLine("After Enqueue():");
            foreach (var item in queue) Console.WriteLine(item); // First, Second, Third

            // Peek()
            Console.WriteLine("\nPeek(): " + queue.Peek());

            // Dequeue()
            Console.WriteLine("Dequeue(): " + queue.Dequeue());
            Console.WriteLine("After Dequeue():");
            foreach (var item in queue) Console.WriteLine(item); // Second, Third

            // Contains()
            Console.WriteLine("\nContains(\"Second\"): " + queue.Contains("Second"));

            // Count
            Console.WriteLine("Count: " + queue.Count);

            // Clear()
            queue.Clear();
            Console.WriteLine("After Clear(): Count = " + queue.Count);




            Dictionary<int, string> dict = new Dictionary<int, string>();

            //  Add key-value pairs
            dict.Add(1, "Apple");
            dict.Add(2, "Banana");
            dict.Add(3, "Cherry");

            //  Access value by key
            Console.WriteLine("Value of key 2: " + dict[2]);

            //  Check if key or value exists
            Console.WriteLine("Contains key 3? " + dict.ContainsKey(3));
            Console.WriteLine("Contains value 'Mango'? " + dict.ContainsValue("Mango"));

            //  Iterate through all key-value pairs
            Console.WriteLine("\nAll key-value pairs:");
            foreach (var kvp in dict)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            //  Remove a key
            dict.Remove(1);
            Console.WriteLine("\nAfter removing key 1:");
            foreach (var kvp in dict)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            //  Safe access using TryGetValue
            if (dict.TryGetValue(2, out string value))
            {
                Console.WriteLine("\nTryGetValue for key 2: " + value);
            }

            //  Count
            Console.WriteLine("\nTotal items in dictionary: " + dict.Count);







            Person person = new Person { name = "Heer", age = 21 };

            string jsonString = JsonSerializer.Serialize(person);
            Console.WriteLine("Serialized JSON: " + jsonString);

            Person deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
            Console.WriteLine($"Name: {deserializedPerson.name}, Age: {deserializedPerson.age}");

            // By using NewtonSoft
            string jsonString = JsonConvert.SerializeObject(person, Formatting.Indented);

            Person personObj = JsonConvert.DeserializeObject<Person>(jsonString);



            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, person);
                string xmlString = writer.ToString();
                Console.WriteLine("Serialized XML:\n" + xmlString);

                // Deserialize from XML
                using (StringReader reader = new StringReader(xmlString))
                {
                    Person deserializedPerson = (Person)serializer.Deserialize(reader);
                    Console.WriteLine($"Name: {deserializedPerson.name}, Age: {deserializedPerson.age}");
                }
            }


            Lambda Functions:
            // Func<int,int> : takes int, returns int
            Func<int, int> square = x => x * x;

            Console.WriteLine("Square of 5: " + square(5)); // Output: 25

            // Func<int,int,int> : takes two ints, returns int
            Func<int, int, int> multiply = (a, b) => a * b;
            Console.WriteLine("Multiply 4 * 6: " + multiply(4, 6)); // Output: 24


            // Action<string> : takes string, returns void
            Action<string> greet = name => Console.WriteLine("Hello, " + name);

            greet("Heer"); // Output: Hello, Heer

            // Action with multiple statements
            Action<int, int> addAndPrint = (a, b) =>
            {
                int sum = a + b;
                Console.WriteLine("Sum: " + sum);
            };

            addAndPrint(10, 20); // Output: Sum: 30

            // Predicate<int> : check if number is even
            Predicate<int> isEven = n => n % 2 == 0;

            Console.WriteLine("10 is even? " + isEven(10)); // True
            Console.WriteLine("7 is even? " + isEven(7));   // False






        }
    }
        }       

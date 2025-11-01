// See https://aka.ms/new-console-template for more information

using CustomSerializer;
namespace week_4_Extra_task
{
    class Program
    {
        static void Main()
        {
            string inputPath = @"C:\Users\heerd\source\repos\week 4 Extra task\colors.json";
          // new File
            string outputPath = @"C:\Users\heerd\source\repos\week 4 Extra task\new_colors.json"; // File to be created

            // Step 1: Load JSON data from file using custom library
            string jsonData = Serializer.LoadFromFile(inputPath);

            // Step 2: Deserialize JSON string to List<ColorItem>
            List<ColorItem> colors = Serializer.DeserializeFromJson<List<ColorItem>>(jsonData);

         

            // Step 3: Serialize it again into a JSON string
            string newJsonString = Serializer.SerializeToJson(colors);

            // Step 4: Print JSON string to console
            Console.WriteLine("\n🔸 Serialized JSON String:");
            Console.WriteLine(newJsonString);

            // Step 5: Save it as a new JSON file
            Serializer.SaveToFile(outputPath, newJsonString);

            Console.WriteLine($"\n✅ New JSON file created successfully at: {outputPath}");
        }
    }
}
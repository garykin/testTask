using System;
using System.IO;

namespace test_task
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath;

            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Console.WriteLine("There is no file path within args.");
                Console.WriteLine("Please specify the path of the file to read:");

                filePath = Console.ReadLine();

                while (!File.Exists(filePath))
                {
                    Console.WriteLine("File does not exist. Try again:");
                    filePath = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine($"File path specified within args: {args[0]}");
                filePath = args[0];
            }

            var result = FileParser.ParseFile(filePath);
            FileParser.PrintResult(result);

            Console.ReadLine();
        }
    }
}
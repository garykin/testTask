using System;
using System.IO;
using System.Linq;

namespace test_task
{
    public class FileParser
    {
        public static ParsingResultDto ParseFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException(nameof(filePath));
            }

            ParsingResultDto result = new ParsingResultDto();

            Console.WriteLine($"Reading the file: {filePath}");

            // List<int> incorrectLinesNumbers = new List<int>();
            // int maxSumLineNumber = 0;
            // double maxSum = 0;

            var lines = File.ReadLines(filePath).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                double lineSum = 0;
                bool lineIsIncorrect = false;
                var numbersInLine = lines[i].Split(',').ToList();

                foreach (var stringValue in numbersInLine)
                {
                    double value;

                    if (double.TryParse(stringValue, out value))
                    {
                        lineSum += value;
                    }
                    else
                    {
                        lineIsIncorrect = true;
                        result.IncorrectLinesNumbers.Add(i + 1);
                        break;
                    }
                }

                if (lineIsIncorrect)
                {
                    continue;
                }

                if (result.MaxSum <= lineSum)
                {
                    result.MaxSum = lineSum;
                    result.MaxSumLineNumber = i + 1;
                }
            }


            //if (result.MaxSumLineNumber == 0)
            //{
            //    Console.WriteLine("All lines includes incorrect values.");
            //}
            //else
            //{
            //    Console.WriteLine($"Line number with max sum of elements of {result.MaxSum} is {result.MaxSumLineNumber}");
            //}

            //Console.Write($"Lines numbers with incorrect values: {string.Join(", ", result.IncorrectLinesNumbers)}");

            return result;
        }

        public static void PrintResult(ParsingResultDto result)
        {
            if (result.MaxSumLineNumber == 0)
            {
                Console.WriteLine("All lines includes incorrect values.");
            }
            else
            {
                Console.WriteLine($"Line number with max sum of elements of {result.MaxSum} is {result.MaxSumLineNumber}");
            }

            Console.Write($"Lines numbers with incorrect values: {string.Join(", ", result.IncorrectLinesNumbers)}");
        }
    }
}

using System;
using System.Globalization;
using NumberToWords.Services;

namespace NumberToWordsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestConvertN2WByConsole();
        }

        static void TestConvertN2WByConsole()
        {
            var convertN2WService = new ConvertNumberToWords();

            while (true)
            {
                Console.WriteLine("\nEnter a number to convert to words (or type 'exit' to quit):");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "exit")
                {
                    break;
                }

                if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal number))
                {
                    string result = convertN2WService.Convert(number);
                    Console.WriteLine($"\nNumber: {number}, Words: {result}");
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter a valid number.");
                }
            }
        }
    }
}

using System;
using System.IO;
using System.Linq;
using Bank_OCR.Services;
using Bank_OCR.Services.Interfaces;

namespace Bank_OCR
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please input file path with account numbers");
                var filePath = Console.ReadLine();

                if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                {
                    Console.WriteLine("File does not exists");
                    Console.ReadKey();
                    continue;
                }

                using (var streamReader = new StreamReader(filePath))
                {
                    var data = streamReader.ReadToEnd();

                    IOCRService parser = new OCRService();
                    var accountNumbers = parser.ParseNumbers(data);
                    foreach (var accountNumber in accountNumbers)
                    {
                        Console.WriteLine($"Number: {accountNumber.Number}, Validation Status: {accountNumber.ValidationStatus}");
                    }
                }
            }
        }
    }
}

using System;
using System.IO;

namespace bulk_sequence_file_renamer
{
    class Program
    { 
        static void Main(string[] args)
        {
            FileProcessor fileProcessor = new FileProcessor(); 
            
            Console.Write("Give path name (ex. E:\\test): ");
            var path = Console.ReadLine();
            
            Console.Write("Sub directories (y = yes): ");
            var subDirectories = Console.ReadLine();
            
            Console.Write("File name prefix: ");
            var fileNamePrefix = Console.ReadLine();

            Console.Write("Total digits (ex. 5 = 00001): ");
            var totalDigits = Console.ReadLine();
            
            Console.Write("Starting digit: ");
            var startingDigit = Console.ReadLine();
            
            fileProcessor.FindFile(path, subDirectories, fileNamePrefix, totalDigits, startingDigit);
        }
    }
}
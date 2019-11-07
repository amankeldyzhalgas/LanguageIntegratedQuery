using BinarySearchTreeLibrary;
using LINQLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using static LINQLibrary.ResultExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = ConfigurationManager.AppSettings["sourceFilePath"];

            var service = new ResultService(path);
            var results = service.Results;
            
            ResultExtension.Sort(ref results, r => r.TestName, SortDirection.Ascending, 3);
            Console.WriteLine();
            DisplayData(results, "STA");
            Console.WriteLine();
            DisplayData(results, "STD");
            Console.ReadLine();
        }

        private static void DisplayData(IEnumerable<Result> results, string format)
        {
            foreach (var item in results)
            {
                Console.WriteLine(value: item.ToString(format));
            }
        }        
    }
}

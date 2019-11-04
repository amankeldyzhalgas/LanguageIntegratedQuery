using BinarySearchTreeLibrary;
using LINQLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = ConfigurationManager.AppSettings["sourceFilePath"];

            /*
            List<Result> list = new List<Result>(){
                new Result("H", ".NET", DateTime.Today, 4),
                new Result("E", ".JAVA", new DateTime(2019,11,1), 5),
                new Result("O", "PHP", new DateTime(2019,10,30), 3),
                new Result("M", ".NET", new DateTime(2019,11,1), 3),
                new Result("P", "PHP", new DateTime(2019,10,30), 5),
                new Result("B", "JAVA", new DateTime(2019,11,1), 4),
            };
            WriteToFile(list.ToList(), path);
            */

            var results = new BinarySearchTree<Result>(GetData(path));
            //DisplayData(results, null);
            DisplayData(results, "STA");

            Console.ReadLine();
        }

        private static void DisplayData(BinarySearchTree<Result> results, string format)
        {
            foreach (var item in results.Inorder())
            {
                Console.WriteLine(value: item.ToString(format));
            }
        }

        private static List<Result> GetData(string filePath)
        {
            List<Result> results = new List<Result>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();
                        string testName = reader.ReadString();
                        DateTime date = DateTime.Parse(reader.ReadString());
                        int assessment = reader.ReadInt32();

                        results.Add(new Result(name, testName, date, assessment));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return results;
        }


        private static void WriteToFile(List<Result> results, string filePath)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
                {
                    foreach (Result result in results)
                    {
                        writer.Write(result.StudentName);
                        writer.Write(result.TestName);
                        writer.Write(result.Date.ToShortDateString());
                        writer.Write(result.Assessment);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

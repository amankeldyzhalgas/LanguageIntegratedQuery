// <copyright file="ResultService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LINQLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// .
    /// </summary>
    public class ResultService
    {
        /// <summary>
        /// Gets Results.
        /// </summary>
        public List<Result> Results { get; private set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultService"/> class.
        /// </summary>
        /// <param name="filePath">sourcePath.</param>
        public ResultService(string filePath)
        {
            this.FilePath = filePath;
            this.Results = this.LoadData();
        }

        /// <summary>
        /// Add result to list.
        /// </summary>
        /// <param name="result">New result.</param>
        public void Add(Result result)
        {
            this.Results.Add(result);
            this.SaveData();
        }

        /// <summary>
        /// Remove result from list.
        /// </summary>
        /// <param name="result">Removable result.</param>
        public void Remove(Result result)
        {
            if (this.Results.Contains(result))
            {
                this.Results.Remove(result);
            }

            this.SaveData();
        }

        /// <summary>
        /// Reads results from the file.
        /// </summary>
        /// <returns>Return list of Results.</returns>
        private List<Result> LoadData()
        {
            List<Result> results = new List<Result>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(this.FilePath, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        results.Add(
                            new Result(
                                reader.ReadString(),
                                reader.ReadString(),
                                DateTime.Parse(reader.ReadString()),
                                reader.ReadInt32()));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return results;
        }

        /// <summary>
        /// Writes results to the file.
        /// </summary>
        private void SaveData()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(this.FilePath, FileMode.OpenOrCreate)))
                {
                    foreach (Result result in this.Results)
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

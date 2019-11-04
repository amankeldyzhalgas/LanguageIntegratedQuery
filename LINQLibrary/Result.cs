using System;
using System.Collections.Generic;
using System.Text;

namespace LINQLibrary
{
    public class Result : IComparable<Result>
    {
        public Result(string studentName, string testName, DateTime date, int assessment)
        {
            StudentName = studentName;
            TestName = testName;
            Date = date;
            Assessment = assessment;
        }

        public string StudentName { get; set; }
        public string TestName { get; set; }
        public DateTime Date { get; set; }
        public int Assessment { get; set; }

        public int CompareTo(Result other)
        {
            return StudentName.CompareTo(other.StudentName);
        }
    }
}

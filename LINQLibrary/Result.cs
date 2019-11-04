using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LINQLibrary
{
    public class Result : IFormattable, IComparable, IComparable<Result>
    {
        public Result(string studentName, string testName, DateTime date, int assessment)
        {
            StudentName = studentName;
            TestName = testName;
            Date = date;
            Assessment = assessment;
        }

        public string StudentName { get; private set; }
        public string TestName { get; private set; }
        public DateTime Date { get; private set; }
        public int Assessment { get; private set; }

        public int CompareTo(object obj)
        {
            if(obj is null)
            {
                throw new ArgumentNullException($"{obj} can't be bull");
            }

            if(!(obj is Result))
            {
                throw new InvalidCastException($"Current {obj} is not a Result");
            }

            return CompareTo((Result)obj);
        }

        public int CompareTo(Result other)
        {
            return StudentName.CompareTo(other.StudentName);
        }

        public override string ToString()
        {
            return this.ToString(null);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "F";
            }

            if (formatProvider is null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpper())
            {
                case "F":
                    return $"Student name:\t{this.StudentName} \nTest name:\t{this.TestName} \nDate:\t{this.Date.ToShortDateString()} \nAssessment:\t{this.Assessment}";
                case "STD":
                    return $"Student name:\t{this.StudentName} \nTest name:\t{this.TestName} \nDate:\t{this.Date.ToShortDateString()} ";
                case "STA":
                    return $"Student name:\t{this.StudentName} \nTest name:\t{this.TestName} \nAssessment:\t{this.Assessment}";
                default:
                    throw new FormatException($"The {format} format string isn't supported");
            }
        }
    }
}

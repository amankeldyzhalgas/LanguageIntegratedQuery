// <copyright file="Result.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LINQLibrary
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Result class.
    /// </summary>
    public class Result : IFormattable, IComparable<Result>, IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="studentName">StudentName.</param>
        /// <param name="testName">TestName.</param>
        /// <param name="date">Date.</param>
        /// <param name="assessment">Assessment.</param>
        public Result(string studentName, string testName, DateTime date, int assessment)
        {
            this.Id = ++id;
            this.StudentName = studentName;
            this.TestName = testName;
            this.Date = date;
            this.Assessment = assessment;
        }

        /// <summary>
        /// Gets StudentName.
        /// </summary>
        public string StudentName { get; private set; }

        /// <summary>
        /// Gets TestName.
        /// </summary>
        public string TestName { get; private set; }

        /// <summary>
        /// Gets Date.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Gets Assessment.
        /// </summary>
        public int Assessment { get; private set; }

        private static int id;

        private int Id { get; set; }

        /// <summary>
        /// Returns int result of the comparisons.
        /// </summary>
        /// <param name="obj">Comparable object.</param>
        /// <returns>Returns 0 if books are equal, 1 if first result bigger than second, -1 in other cases.</returns>
        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{obj} can't be bull");
            }

            if (!(obj is Result))
            {
                throw new InvalidCastException($"Current {obj} is not a Result");
            }

            return this.CompareTo((Result)obj);
        }

        /// <summary>
        /// Returns int result of the comparisons.
        /// </summary>
        /// <param name="other">Comparable result.</param>
        /// <returns>Returns 0 if books are equal, 1 if first result bigger than second, -1 in other cases.</returns>
        public int CompareTo(Result other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (other is null)
            {
                return 1;
            }

            return this.StudentName.CompareTo(other.StudentName);
        }

        /// <summary>
        /// Checks if books equal.
        /// </summary>
        /// <param name="obj">Other object.</param>
        /// <returns>Returns true if results are equal. False - don't equal.</returns>
        public override bool Equals(object obj)
        {
            return obj is null || !(obj is Result) ? false : ReferenceEquals(this, (Result)obj);
        }

        /// <summary>
        /// Checks if results equal.
        /// </summary>
        /// <param name="other">Other result.</param>
        /// <returns>Returns true if results are equal. False - don't equal.</returns>
        public bool Equals(Result other)
        {
            return other is null ? false : ReferenceEquals(this, other) ? true : Equals(this.Id, other.Id);
        }

        /// <summary>
        /// Get  hash code.
        /// </summary>
        /// <returns>Returns hash code.</returns>
        public override int GetHashCode()
        {
            return this.StudentName.GetHashCode() + this.TestName.GetHashCode()
                + this.Date.GetHashCode() + this.Assessment + this.Id.GetHashCode();
        }

        /// <summary>
        /// Returns information about result.
        /// </summary>
        /// <returns>String Representation of the result.</returns>
        public override string ToString()
        {
            return this.ToString(null);
        }

        /// <summary>
        /// Returns information about Result.
        /// </summary>
        /// <param name="format">Letter of the format.</param>
        /// <returns>String Representation of the result.</returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns information about Result.
        /// </summary>
        /// <param name="format">Letter of the format.</param>
        /// <param name="formatProvider">IFormatProvider.</param>
        /// <returns>String Representation of the result.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
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
                    return $" Student name: {this.StudentName} \t Test name: {this.TestName} \t Date: {this.Date.ToShortDateString()} \tAssessment: {this.Assessment}";
                case "STD":
                    return $" Student name: {this.StudentName} \t Test name: {this.TestName} \t Date: {this.Date.ToShortDateString()}";
                case "STA":
                    return $" Student name: {this.StudentName} \t Test name: {this.TestName} \t Assessment: {this.Assessment}";
                default:
                    throw new FormatException($"The {format} format string isn't supported");
            }
        }
    }
}

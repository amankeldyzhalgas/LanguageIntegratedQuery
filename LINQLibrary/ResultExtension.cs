// <copyright file="ResultExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LINQLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// .
    /// </summary>
    public static class ResultExtension
    {
        /// <summary>
        /// Enum SortDirection.
        /// </summary>
        public enum SortDirection
        {
            Ascending,
            Descending,
        }

        /// <summary>
        /// .
        /// </summary>
        /// <typeparam name="TKey">Is the generic type of the "key".</typeparam>
        /// <param name="list">List of results.</param>
        /// <param name="sorter">Lambda delegate.</param>
        /// <param name="direction">Sort Direction.</param>
        /// <param name="rowCount">Row count.</param>
        public static void Sort<TKey>(ref List<Result> list, Func<Result, TKey> sorter,
                               SortDirection direction, int rowCount)
        {
            if (direction == SortDirection.Ascending)
            {
                list = list.OrderBy(sorter).Take(rowCount).ToList();
            }
            else
            {
                list = list.OrderByDescending(sorter).Take(rowCount).ToList();
            }
        }
    }
}
